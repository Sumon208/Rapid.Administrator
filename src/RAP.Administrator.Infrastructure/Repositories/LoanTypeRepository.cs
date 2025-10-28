using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Domain.Models.LoanType;

namespace RAP.Administrator.Infrastructure.Repositories
{
    public class LoanTypeRepository : ILoanTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public LoanTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<LoanTypeEntity> Data, int TotalCount)> GetAllAsync(
            string language, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.LoanTypes
                .Include(l => l.Localizations)
                .AsNoTracking()
                .OrderByDescending(l => l.Id);

            int totalCount = await query.CountAsync();

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize > 0 ? pageSize : totalCount)
                .ToListAsync();

            return (data, totalCount);
        }

        public async Task<LoanTypeEntity?> GetByIdAsync(long id)
        {
            return await _context.LoanTypes
                .Include(l => l.Localizations)
                .Include(l => l.Audits)
                .Include(l => l.Exports)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<LoanTypeEntity> CreateAsync(LoanTypeEntity entity, int userId, string language)
        {
            _context.LoanTypes.Add(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Create");
            return entity;
        }

        public async Task<int> CreateBulkAsync(IEnumerable<LoanTypeEntity> entities, int userId, string language)
        {
            _context.LoanTypes.AddRange(entities);
            await _context.SaveChangesAsync();

            foreach (var entity in entities)
                await AddAuditAsync(entity.Id, userId, "CreateBulk");

            return entities.Count();
        }

        public async Task<bool> UpdateAsync(LoanTypeEntity entity, int userId, string language)
        {
            var existing = await _context.LoanTypes
                .Include(l => l.Localizations)
                .FirstOrDefaultAsync(l => l.Id == entity.Id);

            if (existing == null)
                return false;

            existing.LoanTypeText = entity.LoanTypeText;
            existing.Description = entity.Description;
            existing.IsDefault = entity.IsDefault;
            existing.Draft = entity.Draft;

            if (entity.Localizations != null)
            {
                _context.LoanTypeLocalizations.RemoveRange(existing.Localizations);
                await _context.LoanTypeLocalizations.AddRangeAsync(entity.Localizations);
            }

            await _context.SaveChangesAsync();
            await AddAuditAsync(existing.Id, userId, "Update");
            return true;
        }

        public async Task<bool> DeleteAsync(long id, int userId, string language)
        {
            var entity = await _context.LoanTypes
                .Include(l => l.Localizations)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (entity == null)
                return false;

            _context.LoanTypes.Remove(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Delete");
            return true;
        }

        public async Task<IEnumerable<LoanTypeEntity>> GetTemplateDataAsync()
        {
            return await _context.LoanTypes
                .AsNoTracking()
                .Where(l => l.IsDefault == true)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllGalleryAsync()
        {
            return new List<string>();
        }

        public async Task<IEnumerable<LoanTypeAudit>> GetAllAuditsAsync(long loanTypeId)
        {
            return await _context.LoanTypeAudits
                .AsNoTracking()
                .Where(a => a.LoanTypeId == loanTypeId)
                .OrderByDescending(a => a.ActionUserAt)
                .ToListAsync();
        }

        private async Task AddAuditAsync(long loanTypeId, int userId, string actionTypeName)
        {
            var loanType = await _context.LoanTypes.FindAsync((int)loanTypeId);

            if (loanType == null)
                throw new Exception($"LoanType with Id {loanTypeId} not found.");

            var audit = new LoanTypeAudit
            {
               
                ActionUserId = userId,
                ActionUserAt = DateTime.UtcNow,
                ActionTypeId = MapActionType(actionTypeName),
                LoanTypeText = loanType.LoanTypeText,
                Description = loanType.Description,
                IsDefault = loanType.IsDefault,
                Draft = loanType.Draft
            };

            _context.LoanTypeAudits.Add(audit);
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
