using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Domain.Models.Retirement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Repositories
{
    public class RetirementRepository : IRetirementRepository
    {
        private readonly ApplicationDbContext _context;

        public RetirementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<RetirementEntity> Data, int TotalCount)> GetAllAsync(
            string language, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.Retirements
                .Include(r => r.Localizations)
                .Include(r => r.Audits)
                .AsNoTracking()
                .OrderByDescending(r => r.Id);

            int totalCount = await query.CountAsync();

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize > 0 ? pageSize : totalCount)
                .ToListAsync();

            return (data, totalCount);
        }

        public async Task<RetirementEntity?> GetByIdAsync(long id)
        {
            return await _context.Retirements
                .Include(r => r.Localizations)
                .Include(r => r.Audits)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<RetirementEntity> CreateAsync(RetirementEntity entity, int userId, string language)
        {
            _context.Retirements.Add(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Create");
            return entity;
        }

        public async Task<int> CreateBulkAsync(IEnumerable<RetirementEntity> entities, int userId, string language)
        {
            _context.Retirements.AddRange(entities);
            await _context.SaveChangesAsync();

            foreach (var entity in entities)
                await AddAuditAsync(entity.Id, userId, "CreateBulk");

            return entities.Count();
        }

        public async Task<bool> UpdateAsync(RetirementEntity entity, int userId, string language)
        {
            var existing = await _context.Retirements
                .Include(r => r.Localizations)
                .FirstOrDefaultAsync(r => r.Id == entity.Id);

            if (existing == null)
                return false;

            existing.Retirement = entity.Retirement;
            existing.EmployeeId = entity.EmployeeId;
            existing.Date = entity.Date;
            existing.Description = entity.Description;
            existing.Status = entity.Status;
            existing.IsDefault = entity.IsDefault;
            existing.Draft = entity.Draft;
            existing.Branch = entity.Branch;

            if (entity.Localizations != null)
            {
                _context.RetirementLocalizations.RemoveRange(existing.Localizations);
                await _context.RetirementLocalizations.AddRangeAsync(entity.Localizations);
            }

            await _context.SaveChangesAsync();

            await AddAuditAsync(existing, userId, "Update");

            return true;
        }

        public async Task<bool> DeleteAsync(long id, int userId, string language)
        {
            var entity = await _context.Retirements
                .Include(r => r.Localizations)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (entity == null)
                return false;

            await AddAuditAsync(entity, userId, "Delete");

            _context.Retirements.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        private async Task AddAuditAsync(RetirementEntity entity, int userId, string actionTypeName)
        {
            var audit = new RetirementAudit
            {
                RetirementId = entity.Id,
                ActionUserId = userId,
                ActionDate = DateTime.UtcNow,  
                ActionType = actionTypeName,
               
                Date = entity.Date,
                Description = entity.Description,
                Status = entity.Status,
               
            };

            _context.RetirementAudits.Add(audit);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<RetirementEntity>> GetTemplateDataAsync()
        {
            return await _context.Retirements
                .AsNoTracking()
                .Where(r => r.IsDefault == true)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllGalleryAsync()
        {
            return new List<string>();
        }

        public async Task<IEnumerable<RetirementAudit>> GetAllAuditsAsync(long retirementId)
        {
            return await _context.RetirementAudits
                .AsNoTracking()
                .Where(a => a.RetirementId == retirementId)
                .OrderByDescending(a => a.ActionDate)
                .ToListAsync();
        }

        private async Task AddAuditAsync(int retirementId, int userId, string actionTypeName)
        {
            var retirement = await _context.Retirements.FindAsync(retirementId);
            if (retirement == null)
                throw new Exception($"Retirement with Id {retirementId} not found.");

            var audit = new RetirementAudit
            {
                RetirementId = retirementId,
                ActionUserId = userId,
                ActionType = actionTypeName,
                ActionDate = DateTime.UtcNow,

                EmployeeName = retirement.EmployeeId.HasValue ? "" : null,
                Date = retirement.Date,
                Description = retirement.Description,
                Status = retirement.Status
            };

            _context.RetirementAudits.Add(audit);
            await _context.SaveChangesAsync();
        }
    }
}
