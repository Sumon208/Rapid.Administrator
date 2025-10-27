using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Domain.Models.JobLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Repositories
{
    public class JobLocationRepository : IJobLocationRepository
    {
        private readonly ApplicationDbContext _context;

        public JobLocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<JobLocationEntity> Data, int TotalCount)> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.JobLocations
                .Include(j => j.Localizations)
                .Include(j => j.Audits)
                .AsNoTracking()
                .OrderByDescending(j => j.Id);

            int totalCount = await query.CountAsync();

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize > 0 ? pageSize : totalCount)
                .ToListAsync();

            return (data, totalCount);
        }

        public async Task<JobLocationEntity?> GetByIdAsync(long id)
        {
            return await _context.JobLocations
                .Include(j => j.Localizations)
                .Include(j => j.Audits)
                .FirstOrDefaultAsync(j => j.Id == id);
        }

        public async Task<JobLocationEntity> CreateAsync(JobLocationEntity entity, int userId, string language)
        {
            _context.JobLocations.Add(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Create");
            return entity;
        }

        public async Task<int> CreateBulkAsync(IEnumerable<JobLocationEntity> entities, int userId, string language)
        {
            _context.JobLocations.AddRange(entities);
            await _context.SaveChangesAsync();

            foreach (var entity in entities)
                await AddAuditAsync(entity.Id, userId, "CreateBulk");

            return entities.Count();
        }

        public async Task<bool> UpdateAsync(JobLocationEntity entity, int userId, string language)
        {
            var existing = await _context.JobLocations
                .Include(j => j.Localizations)
                .FirstOrDefaultAsync(j => j.Id == entity.Id);

            if (existing == null)
                return false;

            existing.JobLocation = entity.JobLocation;
            existing.CountryId = entity.CountryId;
            existing.Descriptions = entity.Descriptions;
            existing.IsDefault = entity.IsDefault;
            existing.IsDraft = entity.IsDraft;
            existing.IsActive = entity.IsActive;
            existing.UpdatedAt = DateTime.UtcNow;
            existing.UpdatedBy = userId;

            if (entity.Localizations != null)
            {
                _context.JobLocationLocalizations.RemoveRange(existing.Localizations);
                await _context.JobLocationLocalizations.AddRangeAsync(entity.Localizations);
            }

            await _context.SaveChangesAsync();
            await AddAuditAsync(existing.Id, userId, "Update");

            return true;
        }

        public async Task<bool> DeleteAsync(long id, int userId, string language)
        {
            var entity = await _context.JobLocations
                .Include(j => j.Localizations)
                .FirstOrDefaultAsync(j => j.Id == id);

            if (entity == null)
                return false;

            _context.JobLocations.Remove(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Delete");
            return true;
        }

        public async Task<IEnumerable<JobLocationEntity>> GetTemplateDataAsync()
        {
            return await _context.JobLocations
                .AsNoTracking()
                .Where(j => j.IsDefault == true)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllGalleryAsync()
        {
            // No gallery for JobLocation — return empty collection
            return new List<string>();
        }

        public async Task<IEnumerable<JobLocationAuditEntity>> GetAllAuditsAsync(long jobLocationId)
        {
            return await _context.JobLocationAudits
                .AsNoTracking()
                .Where(a => a.JobLocationId == jobLocationId)
                .OrderByDescending(a => a.ActionUserAt)
                .ToListAsync();
        }

        private async Task AddAuditAsync(int jobLocationId, int userId, string action)
        {
            var job = await _context.JobLocations.FindAsync(jobLocationId);
            if (job == null)
                throw new Exception($"JobLocation with Id {jobLocationId} not found.");

            var audit = new JobLocationAuditEntity
            {
                JobLocationId = jobLocationId,
               
                IsDefault = job.IsDefault,
                IsDraft = job.IsDraft,
                IsActive = job.IsActive,
                ActionTypeId = MapActionType(action),
                ActionUserId = userId,
                ActionUserAt = DateTime.UtcNow
            };

            _context.JobLocationAudits.Add(audit);
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
