using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Domain.Models.Loan;


namespace RAP.Administrator.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly ApplicationDbContext _context;

        public LoanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<LoanEntity> Data, int TotalCount)> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.Loans
                .Include(l => l.Localizations)
                .Include(l => l.Authority)
                .AsNoTracking()
                .OrderByDescending(l => l.Id);

            int totalCount = await query.CountAsync();

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize > 0 ? pageSize : totalCount)
                .ToListAsync();

            return (data, totalCount);
        }

        public async Task<LoanEntity?> GetByIdAsync(long id)
        {
            return await _context.Loans
                .Include(l => l.Localizations)
                .Include(l => l.Audits)
                .Include(l => l.Exports)
                .Include(l => l.Authority)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<LoanEntity> CreateAsync(LoanEntity entity, int userId, string language)
        {
           
            entity.Id = 0; 

            _context.Loans.Add(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Create");
            return entity;
        }
        public async Task<int> CreateBulkAsync(IEnumerable<LoanEntity> entities, int userId, string language)
        {
           
            foreach (var entity in entities)
                entity.Id = 0;

            _context.Loans.AddRange(entities);
            await _context.SaveChangesAsync();

            foreach (var entity in entities)
                await AddAuditAsync(entity.Id, userId, "CreateBulk");

            return entities.Count();
        }



        public async Task<bool> UpdateAsync(LoanEntity entity, int userId, string language)
        {
            var existing = await _context.Loans
                .Include(l => l.Localizations)
                .FirstOrDefaultAsync(l => l.Id == entity.Id);

            if (existing == null)
                return false;

            existing.IqmaId = entity.IqmaId;
            existing.Date = entity.Date;
            existing.Amount = entity.Amount;
            existing.Branch = entity.Branch;
            existing.LoanDetails = entity.LoanDetails;
            existing.LoanStatus = entity.LoanStatus;
            existing.PermittedById = entity.PermittedById;
            
            existing.IsDefault = entity.IsDefault;

            if (entity.Localizations != null)
            {
                _context.LoanLocalizations.RemoveRange(existing.Localizations);
                await _context.LoanLocalizations.AddRangeAsync(entity.Localizations);
            }

            await _context.SaveChangesAsync();
            await AddAuditAsync(existing.Id, userId, "Update");
            return true;
        }

        public async Task<bool> DeleteAsync(long id, int userId, string language)
        {
            var entity = await _context.Loans
                .Include(l => l.Localizations)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (entity == null)
                return false;

            _context.Loans.Remove(entity);
            await _context.SaveChangesAsync();
            await AddAuditAsync(entity.Id, userId, "Delete");
            return true;
        }

        public async Task<IEnumerable<LoanEntity>> GetTemplateDataAsync()
        {
            return await _context.Loans
                                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllGalleryAsync()
        {
            return new List<string>();
        }

        public async Task<IEnumerable<LoanAudit>> GetAllAuditsAsync(int loanId)
        {
            return await _context.LoanAudits
                .AsNoTracking()
                .Where(a => a.LoanId == loanId)              
                .ToListAsync();
        }

        private async Task AddAuditAsync(int loanId, int userId, string actionTypeName)
        {
            var loan = await _context.Loans.FindAsync(loanId);
            if (loan == null)
                throw new Exception($"Loan with Id {loanId} not found.");

            var audit = new LoanAudit
            {
                LoanId = loanId,
                ActionUserId = userId,
                ActionTypeId = MapActionType(actionTypeName),
                IsDefault = loan.IsDefault,
                ActionUserAt = DateTime.UtcNow
            };

            _context.LoanAudits.Add(audit);
            await _context.SaveChangesAsync();
        }


        private short MapActionType(string action) => action switch
        {
            "Create" => 1,
            "CreateBulk" => 2,
            "Update" => 3,
            "Delete" => 4,
            _ => 0
        };
    }
}
