using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Domain.Models.ProjectContractType;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Repositories
{
    public class ProjectContractTypeRepository : IProjectContractTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectContractTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<ProjectContractTypeEntity> Data, int TotalCount)> GetAllAsync(
            string language, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.ProjectContractTypes
                .Include(p => p.Localizations)
                .AsNoTracking()
                .OrderByDescending(p => p.Id);

            int totalCount = await query.CountAsync();

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize > 0 ? pageSize : totalCount)
                .ToListAsync();

            return (data, totalCount);
        }

        public async Task<ProjectContractTypeEntity?> GetByIdAsync(long id)
        {
            return await _context.ProjectContractTypes
                .Include(p => p.Localizations)
                .Include(p => p.Audits)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ProjectContractTypeEntity> CreateAsync(ProjectContractTypeEntity entity, int userId, string language)
        {
            _context.ProjectContractTypes.Add(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Create");

            return entity;
        }

        public async Task<int> CreateBulkAsync(IEnumerable<ProjectContractTypeEntity> entities, int userId, string language)
        {
            _context.ProjectContractTypes.AddRange(entities);
            await _context.SaveChangesAsync();

            foreach (var entity in entities)
                await AddAuditAsync(entity.Id, userId, "CreateBulk");

            return entities.Count();
        }

        public async Task<bool> UpdateAsync(ProjectContractTypeEntity entity, int userId, string language)
        {
            var existing = await _context.ProjectContractTypes
                .Include(p => p.Localizations)
                .FirstOrDefaultAsync(p => p.Id == entity.Id);

            if (existing == null)
                return false;

           
            existing.Name = entity.Name;
            existing.Description = entity.Description;
        
            existing.IsDefault = entity.IsDefault;

            if (entity.Localizations != null)
            {
                _context.ProjectContractTypeLocalizations.RemoveRange(existing.Localizations);
                await _context.ProjectContractTypeLocalizations.AddRangeAsync(entity.Localizations);
            }

            await _context.SaveChangesAsync();
            await AddAuditAsync(existing.Id, userId, "Update");
            return true;
        }

        public async Task<bool> DeleteAsync(long id, int userId, string language)
        {
            var entity = await _context.ProjectContractTypes
                .Include(p => p.Localizations)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (entity == null)
                return false;

            _context.ProjectContractTypes.Remove(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Delete");
            return true;
        }

        public async Task<IEnumerable<ProjectContractTypeEntity>> GetTemplateDataAsync()
        {
            return await _context.ProjectContractTypes
                
                
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllGalleryAsync()
        {
            return new List<string>();
        }

        public async Task<IEnumerable<ProjectContractTypeAudit>> GetAllAuditsAsync(long projectContractTypeId)
        {
            return await _context.ProjectContractTypeAudits
             
                
                .ToListAsync();
        }

        private async Task AddAuditAsync(long projectContractTypeId, int userId, string actionTypeName)
        {
            var entity = await _context.ProjectContractTypes.FindAsync(projectContractTypeId);
            if (entity == null)
                throw new Exception($"ProjectContractType with Id {projectContractTypeId} not found.");

            var audit = new ProjectContractTypeAudit
            {
                ProjectContractTypeId = (int) projectContractTypeId,
                ActionUserId = userId,
               
                IsDefault = entity.IsDefault,
             
            };

            _context.ProjectContractTypeAudits.Add(audit);
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
