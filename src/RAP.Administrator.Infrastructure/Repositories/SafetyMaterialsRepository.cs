using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Domain.Models.SafetyMaterials;

namespace RAP.Administrator.Infrastructure.Repositories
{
    public class SafetyMaterialsRepository : ISafetyMaterialsRepository
    {
        private readonly ApplicationDbContext _context;

        public SafetyMaterialsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<SafetyMaterialsEntity> Data, int TotalCount)> GetAllAsync(
            string language, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.SafetyMaterials
                .Include(s => s.Localizations)
                .Include(s => s.Employee)
                .Include(s => s.Duration)
                .AsNoTracking()
                .OrderByDescending(s => s.Id);

            int totalCount = await query.CountAsync();

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize > 0 ? pageSize : totalCount)
                .ToListAsync();

            return (data, totalCount);
        }

        public async Task<SafetyMaterialsEntity?> GetByIdAsync(int id)
        {
            return await _context.SafetyMaterials
                .Include(s => s.Localizations)
                .Include(s => s.Audits)
                .Include(s => s.Exports)
                .Include(s => s.Employee)
                .Include(s => s.Duration)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<SafetyMaterialsEntity> CreateAsync(SafetyMaterialsEntity entity, int userId, string language)
        {
            _context.SafetyMaterials.Add(entity);
            await _context.SaveChangesAsync();
            await AddAuditAsync(entity.Id, userId, "Create");
            return entity;
        }

        public async Task<int> CreateBulkAsync(IEnumerable<SafetyMaterialsEntity> entities, int userId, string language)
        {
            _context.SafetyMaterials.AddRange(entities);
            await _context.SaveChangesAsync();

            foreach (var e in entities)
                await AddAuditAsync(e.Id, userId, "CreateBulk");

            return entities.Count();
        }

        public async Task<bool> UpdateAsync(SafetyMaterialsEntity entity, int userId, string language)
        {
            var existing = await _context.SafetyMaterials
                .Include(s => s.Localizations)
                .FirstOrDefaultAsync(s => s.Id == entity.Id);

            if (existing == null)
                return false;

            existing.Date = entity.Date;
            existing.EmployeeId = entity.EmployeeId;
         
            existing.Amount = entity.Amount;
            existing.DurationId = entity.DurationId;
            existing.NextDate = entity.NextDate;
            existing.Note = entity.Note;

            if (entity.Localizations != null)
            {
                _context.SafetyMaterialsLocalizations.RemoveRange(existing.Localizations);
                await _context.SafetyMaterialsLocalizations.AddRangeAsync(entity.Localizations);
            }

            await _context.SaveChangesAsync();
            await AddAuditAsync(existing.Id, userId, "Update");
            return true;
        }

        public async Task<bool> DeleteAsync(int id, int userId, string language)
        {
            var entity = await _context.SafetyMaterials
                .Include(s => s.Localizations)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (entity == null)
                return false;

            _context.SafetyMaterials.Remove(entity);
            await _context.SaveChangesAsync();
            await AddAuditAsync(id, userId, "Delete");
            return true;
        }

        public async Task<IEnumerable<SafetyMaterialsEntity>> GetTemplateDataAsync()
        {
            return await _context.SafetyMaterials
                .AsNoTracking()
                .Where(s => s.EmployeeId > 0)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllGalleryAsync()
        {
            return new List<string>();
        }

        public async Task<IEnumerable<SafetyMaterialsAuditEntity>> GetAllAuditsAsync(int safetyMaterialsId)
        {
            return await _context.SafetyMaterialsAudits
                .AsNoTracking()
                .Where(a => a.SafetyMaterialsId == safetyMaterialsId)
                .OrderByDescending(a => a.ActionUserAt)
                .ToListAsync();
        }

        private async Task AddAuditAsync(int safetyMaterialsId, int userId, string actionTypeName)
        {
            var material = await _context.SafetyMaterials.FindAsync(safetyMaterialsId);
            if (material == null)
                throw new Exception($"SafetyMaterial with Id {safetyMaterialsId} not found.");

            var audit = new SafetyMaterialsAuditEntity
            {
                SafetyMaterialsId = safetyMaterialsId,
                ActionUserId = userId,
                ActionUserAt = DateTime.UtcNow,
                ActionTypeId = MapActionType(actionTypeName),
                IsDefault = false,
                StatusId = true,
                Code = "SM-" + safetyMaterialsId
            };

            _context.SafetyMaterialsAudits.Add(audit);
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
