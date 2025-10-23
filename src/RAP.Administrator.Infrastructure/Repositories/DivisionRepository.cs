using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Domain.Models;

namespace RAP.Administrator.Infrastructure.Repositories
{
    public class DivisionRepository : IDivisionRepository
    {
        private readonly ApplicationDbContext _context;

        public DivisionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<(IEnumerable<Division> Data, int TotalCount)> GetAllAsync(
            string language, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.Divisions
                .Include(d => d.Localizations)
                .AsNoTracking()
                .OrderByDescending(d => d.Id);

            int totalCount = await query.CountAsync();

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize > 0 ? pageSize : totalCount)
                .ToListAsync();

            return (data, totalCount);
        }

       
        public async Task<Division?> GetByIdAsync(long id)
        {
            return await _context.Divisions
                .Include(d => d.Localizations)
                .Include(d => d.Audits)
                .Include(d => d.Exports)
                .FirstOrDefaultAsync(d => d.Id == id);
        }


        public async Task<Division> CreateAsync(Division entity, int userId, string language)
        {
            // Add Division
            _context.Divisions.Add(entity);
            await _context.SaveChangesAsync();

            // Add Audit
            await AddAuditAsync(entity.Id, userId, "Create");

            return entity;
        }



        public async Task<int> CreateBulkAsync(IEnumerable<Division> entities, int userId, string language)
        {
            _context.Divisions.AddRange(entities);
            await _context.SaveChangesAsync();

            foreach (var entity in entities)
                await AddAuditAsync(entity.Id, userId, "CreateBulk");

            return entities.Count();
        }

        
        public async Task<bool> UpdateAsync(Division entity, int userId, string language)
        {
            var existing = await _context.Divisions
                .Include(d => d.Localizations)
                .FirstOrDefaultAsync(d => d.Id == entity.Id);

            if (existing == null)
                return false;

            
            existing.Code = entity.Code;
            existing.DivisionName = entity.DivisionName;
            existing.Region = entity.Region;
            existing.Description = entity.Description;
            existing.StatusTypeId = entity.StatusTypeId;
            existing.IsDefault = entity.IsDefault;

            
            if (entity.Localizations != null)
            {
                _context.DivisionLocalizations.RemoveRange(existing.Localizations);
                await _context.DivisionLocalizations.AddRangeAsync(entity.Localizations);
            }

            await _context.SaveChangesAsync();
            await AddAuditAsync(existing.Id, userId, "Update");
            return true;
        }

       
        public async Task<bool> DeleteAsync(long id, int userId, string language)
        {
            var entity = await _context.Divisions
                .Include(d => d.Localizations)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (entity == null)
                return false;

            _context.Divisions.Remove(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Delete");
            return true;
        }

       
        public async Task<IEnumerable<Division>> GetTemplateDataAsync()
        {
            return await _context.Divisions
                .AsNoTracking()
                .Where(d => d.StatusTypeId == 1)
                .ToListAsync();
        }

       
        public async Task<IEnumerable<string>> GetAllGalleryAsync()
        {
            return new List<string>();
        }

        
        public async Task<IEnumerable<DivisionAudit>> GetAllAuditsAsync(long divisionId)
        {
            return await _context.DivisionAudits
                .AsNoTracking()
                .Where(a => a.DivisionId == divisionId)
                .OrderByDescending(a => a.ActionAt)
                .ToListAsync();
        }



        private async Task AddAuditAsync(long divisionId, int userId, string actionTypeName)
        {
            var division = await _context.Divisions.FindAsync(divisionId);
            if (division == null)
                throw new Exception($"Division with Id {divisionId} not found.");

            var audit = new DivisionAudit
            {
                DivisionId = divisionId,
                ActionUserId = userId,
                ActionAt = DateTime.UtcNow,
                ActionTypeName = actionTypeName, 
                IsDefault = division.IsDefault,
                StatusTypeId = division.StatusTypeId
            };

            _context.DivisionAudits.Add(audit);
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
