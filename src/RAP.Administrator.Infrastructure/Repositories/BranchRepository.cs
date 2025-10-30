using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Domain.Models.Branches;

namespace RAP.Administrator.Infrastructure.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly ApplicationDbContext _context;

        public BranchRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<BranchEntity> Data, int TotalCount)> GetAllAsync(
            string language, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.MSDBranches
                .Include(b => b.Localizations)
                .AsNoTracking()
                .OrderByDescending(b => b.Id);

            int totalCount = await query.CountAsync();

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize > 0 ? pageSize : totalCount)
                .ToListAsync();

            return (data, totalCount);
        }

        public async Task<BranchEntity?> GetByIdAsync(int id)
        {
            return await _context.MSDBranches
                .Include(b => b.Localizations)
                .Include(b => b.Audits)
                .Include(b => b.Exports)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<BranchEntity> CreateAsync(BranchEntity entity, int userId, string language)
        {
            _context.MSDBranches.Add(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Create");
            return entity;
        }

        public async Task<int> CreateBulkAsync(IEnumerable<BranchEntity> entities, int userId, string language)
        {
            _context.MSDBranches.AddRange(entities);
            await _context.SaveChangesAsync();

            foreach (var entity in entities)
                await AddAuditAsync(entity.Id, userId, "CreateBulk");

            return entities.Count();
        }

        public async Task<bool> UpdateAsync(BranchEntity entity, int userId, string language)
        {
            var existing = await _context.MSDBranches
                .Include(b => b.Localizations)
                .FirstOrDefaultAsync(b => b.Id == entity.Id);

            if (existing == null)
                return false;

            // Update main fields
            existing.BranchName = entity.BranchName;
            existing.BranchArabic = entity.BranchArabic;
            existing.VATNumber = entity.VATNumber;
            existing.Website = entity.Website;
            existing.Phone = entity.Phone;
            existing.CurrencySymbol = entity.CurrencySymbol;
            existing.City = entity.City;
            existing.State = entity.State;
            existing.PostCode = entity.PostCode;
            existing.PrintFormat = entity.PrintFormat;

            existing.CompanyId = entity.CompanyId;
            existing.CurrencyId = entity.CurrencyId;
            existing.CountryId = entity.CountryId;
            existing.BankId = entity.BankId;
            existing.InvoiceId = entity.InvoiceId;

            // Update localizations
            if (entity.Localizations != null)
            {
                _context.BranchesLocalizations.RemoveRange(existing.Localizations);
                await _context.BranchesLocalizations.AddRangeAsync(entity.Localizations);
            }

            await _context.SaveChangesAsync();
            await AddAuditAsync(existing.Id, userId, "Update");
            return true;
        }

        public async Task<bool> DeleteAsync(int id, int userId, string language)
        {
            var entity = await _context.MSDBranches
                .Include(b => b.Localizations)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (entity == null)
                return false;

            _context.MSDBranches.Remove(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Delete");
            return true;
        }

        public async Task<IEnumerable<BranchEntity>> GetTemplateDataAsync()
        {
            return await _context.MSDBranches
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllGalleryAsync()
        {
            return new List<string>();
        }

        public async Task<IEnumerable<BranchAuditEntity>> GetAllAuditsAsync(int branchId)
        {
            return await _context.BranchesAudits
                .AsNoTracking()
                .Where(a => a.BranchId == branchId)
                .OrderByDescending(a => a.Id)
                .ToListAsync();
        }

        private async Task AddAuditAsync(int branchId, int userId, string actionTypeName)
        {
            var branch = await _context.MSDBranches.FindAsync(branchId);
            if (branch == null)
                throw new Exception($"Branch with Id {branchId} not found.");

            var audit = new BranchAuditEntity
            {
                BranchId = branchId,
                ActionUserId = userId,
               
            };

            _context.BranchesAudits.Add(audit);
            await _context.SaveChangesAsync();
        }
    }
}
