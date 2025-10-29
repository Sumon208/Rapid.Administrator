using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Domain.Models.ProjectContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Repositories
{
    public class ProjectContractRepository : IProjectContractRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectContractRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<ProjectContractEntity> Data, int TotalCount)> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.ProjectContracts
                .Include(pc => pc.Localizations)
                .AsNoTracking()
                .OrderByDescending(pc => pc.Id);

            int totalCount = await query.CountAsync();

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize > 0 ? pageSize : totalCount)
                .ToListAsync();

            return (data, totalCount);
        }

        public async Task<ProjectContractEntity?> GetByIdAsync(long id)
        {
            return await _context.ProjectContracts
                .Include(pc => pc.Localizations)
                .Include(pc => pc.Audits)
                .Include(pc => pc.Exports)
                .FirstOrDefaultAsync(pc => pc.Id == id);
        }

        public async Task<ProjectContractEntity> CreateAsync(ProjectContractEntity entity, int userId, string language)
        {
            _context.ProjectContracts.Add(entity);
            await _context.SaveChangesAsync();
            await AddAuditAsync(entity.Id, userId, "Create");
            return entity;
        }

        public async Task<int> CreateBulkAsync(IEnumerable<ProjectContractEntity> entities, int userId, string language)
        {
            _context.ProjectContracts.AddRange(entities);
            await _context.SaveChangesAsync();

            foreach (var entity in entities)
                await AddAuditAsync(entity.Id, userId, "CreateBulk");

            return entities.Count();
        }

        public async Task<bool> UpdateAsync(ProjectContractEntity entity, int userId, string language)
        {
            var existing = await _context.ProjectContracts
                .Include(pc => pc.Localizations)
                .FirstOrDefaultAsync(pc => pc.Id == entity.Id);

            if (existing == null) return false;

            existing.ContractTypeId = entity.ContractTypeId;
            existing.Subject = entity.Subject;
            existing.StartDate = entity.StartDate;
            existing.EndDate = entity.EndDate;
            existing.Description = entity.Description;
            existing.Customer = entity.Customer;
            existing.ContractValue = entity.ContractValue;
            existing.IsDefault = entity.IsDefault;
            existing.Draft = entity.Draft;

            if (entity.Localizations != null)
            {
                _context.ProjectContractLocalizations.RemoveRange(existing.Localizations);
                await _context.ProjectContractLocalizations.AddRangeAsync(entity.Localizations);
            }

            await _context.SaveChangesAsync();
            await AddAuditAsync(existing.Id, userId, "Update");
            return true;
        }

        public async Task<bool> DeleteAsync(long id, int userId, string language)
        {
            var entity = await _context.ProjectContracts
                .Include(pc => pc.Localizations)
                .FirstOrDefaultAsync(pc => pc.Id == id);

            if (entity == null) return false;

            _context.ProjectContracts.Remove(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Delete");
            return true;
        }

        public async Task<IEnumerable<ProjectContractEntity>> GetTemplateDataAsync()
        {
            return await _context.ProjectContracts
                .AsNoTracking()
                .Where(pc => pc.Draft == false)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllGalleryAsync()
        {
            return new List<string>();
        }

        public async Task<IEnumerable<ProjectContractAudit>> GetAllAuditsAsync(long projectContractId)
        {
            return await _context.ProjectContractAudits
                .AsNoTracking()
                .Where(a => a.ProjectContractId == projectContractId)
                .OrderByDescending(a => a.ActionUserAt)
                .ToListAsync();
        }

        private async Task AddAuditAsync(long projectContractId, int userId, string actionTypeName)
        {
            var entity = await _context.ProjectContracts.FindAsync(projectContractId);
            if (entity == null) throw new Exception($"ProjectContract with Id {projectContractId} not found.");

            var audit = new ProjectContractAudit
            {
                ProjectContractId = (int) projectContractId,
                ActionUserId = userId,
                ActionUserAt = DateTime.UtcNow,
                ActionTypeId = MapActionType(actionTypeName),
                Description = entity.Description
            };

            _context.ProjectContractAudits.Add(audit);
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
