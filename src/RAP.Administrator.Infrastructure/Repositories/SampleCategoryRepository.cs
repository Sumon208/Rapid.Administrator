using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Domain.Models.SampleCategory;

namespace RAP.Administrator.Infrastructure.Repositories
{
    public class SampleCategoryRepository : ISampleCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public SampleCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<SampleCategoryEntity> Data, int TotalCount)> GetAllAsync(
            string language, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.SampleCategories
                .Include(c => c.Localizations)
                .AsNoTracking()
                .OrderByDescending(c => c.Id);

            int totalCount = await query.CountAsync();

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize > 0 ? pageSize : totalCount)
                .ToListAsync();

            return (data, totalCount);
        }

        public async Task<SampleCategoryEntity?> GetByIdAsync(int id)
        {
            return await _context.SampleCategories
                .Include(c => c.Localizations)
                .Include(c => c.Audits)
                .Include(c => c.Exports)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<SampleCategoryEntity> CreateAsync(SampleCategoryEntity entity, int userId, string language)
        {
            _context.SampleCategories.Add(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Create");
            return entity;
        }

        public async Task<int> CreateBulkAsync(IEnumerable<SampleCategoryEntity> entities, int userId, string language)
        {
            _context.SampleCategories.AddRange(entities);
            await _context.SaveChangesAsync();

            foreach (var entity in entities)
                await AddAuditAsync(entity.Id, userId, "CreateBulk");

            return entities.Count();
        }

        public async Task<bool> UpdateAsync(SampleCategoryEntity entity, int userId, string language)
        {
            var existing = await _context.SampleCategories
                .Include(c => c.Localizations)
                .FirstOrDefaultAsync(c => c.Id == entity.Id);

            if (existing == null)
                return false;

            existing.CategoryName = entity.CategoryName;
            existing.Description = entity.Description;
            existing.StatusTypeId = entity.StatusTypeId;
            existing.ActionTypeId = entity.ActionTypeId;

            if (entity.Localizations != null)
            {
                _context.SampleCategoryLocalizations.RemoveRange(existing.Localizations);
                await _context.SampleCategoryLocalizations.AddRangeAsync(entity.Localizations);
            }

            await _context.SaveChangesAsync();
            await AddAuditAsync(existing.Id, userId, "Update");
            return true;
        }

        public async Task<bool> DeleteAsync(int id, int userId, string language)
        {
          
            var entity = await _context.SampleCategories
                .Include(x => x.Localizations)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                throw new Exception($"SampleCategory with Id {id} not found.");

           
            await AddAuditAsync(entity, userId, "Delete");

       
            _context.SampleCategories.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }


        private async Task AddAuditAsync(SampleCategoryEntity entity, int userId, string actionType)
        {
            var audit = new SampleCategoryAudit
            {
                CategoryId = entity.Id,
                ActionUserId = userId,
              
            
                ActionUserAt = DateTime.UtcNow
            };

            await _context.SampleCategoryAudits.AddAsync(audit);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SampleCategoryEntity>> GetTemplateDataAsync()
        {
            return await _context.SampleCategories
                .AsNoTracking()
                .Where(c => c.StatusTypeId == 1)
                .ToListAsync();
        }

        public async Task<IEnumerable<SampleCategoryAudit>> GetAllAuditsAsync(int categoryId)
        {
            return await _context.SampleCategoryAudits
                .AsNoTracking()
                .Where(a => a.CategoryId == categoryId)
                .OrderByDescending(a => a.ActionUserAt)
                .ToListAsync();
        }

        private async Task AddAuditAsync(int categoryId, int userId, string actionTypeName)
        {
            var category = await _context.SampleCategories.FindAsync(categoryId);
            if (category == null)
                throw new Exception($"SampleCategory with Id {categoryId} not found.");

            var audit = new SampleCategoryAudit
            {
                CategoryId = categoryId,
                ActionUserId = userId,
                ActionUserAt = DateTime.UtcNow,
                ActionTypeId = MapActionType(actionTypeName)
            };

            _context.SampleCategoryAudits.Add(audit);
            await _context.SaveChangesAsync();
        }

        private int MapActionType(string action) => action switch
        {
            "Create" => 1,
            "CreateBulk" => 2,
            "Update" => 3,
            "Delete" => 4,
            _ => 0
        };
    }
}
