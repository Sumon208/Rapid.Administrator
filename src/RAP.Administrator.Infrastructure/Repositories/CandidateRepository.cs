using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Domain.Models.CandidateSelection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly ApplicationDbContext _context;

        public CandidateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<CandidateEntity> Data, int TotalCount)> GetAllAsync(
            int pageNumber = 1, int pageSize = 10, int? languageId = null)
        {
            var query = _context.Candidates
                .Include(c => c.Localizations)
                .Include(c => c.Position)
                .Include(c => c.Team)
                .AsNoTracking()
                .OrderByDescending(c => c.Id);

            int totalCount = await query.CountAsync();

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize > 0 ? pageSize : totalCount)
                .ToListAsync();

            if (languageId.HasValue)
            {
                foreach (var candidate in data)
                {
                    candidate.Localizations = candidate.Localizations
                        .Where(l => l.LanguageId == languageId.Value)
                        .ToList();
                }
            }

            return (data, totalCount);
        }

        public async Task<CandidateEntity?> GetByIdAsync(int id, int? languageId = null)
        {
            var candidate = await _context.Candidates
                .Include(c => c.Localizations)
                .Include(c => c.Audits)
                .Include(c => c.Exports)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (candidate != null && languageId.HasValue)
            {
                candidate.Localizations = candidate.Localizations
                    .Where(l => l.LanguageId == languageId.Value)
                    .ToList();
            }

            return candidate;
        }

        public async Task<CandidateEntity> CreateAsync(CandidateEntity entity, int userId)
        {
            await _context.Candidates.AddAsync(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, "Insert", userId);
            return entity;
        }

        public async Task<int> CreateBulkAsync(IEnumerable<CandidateEntity> entities, int userId)
        {
            await _context.Candidates.AddRangeAsync(entities);
            int count = await _context.SaveChangesAsync();

            foreach (var entity in entities)
                await AddAuditAsync(entity.Id, "Insert", userId);

            return count;
        }

        public async Task<bool> UpdateAsync(CandidateEntity entity, int userId)
        {
            var existing = await _context.Candidates
                .Include(c => c.Localizations)
                .FirstOrDefaultAsync(c => c.Id == entity.Id);

            if (existing == null)
                return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);

            await _context.SaveChangesAsync();
            await AddAuditAsync(existing.Id, "Update", userId);

            return true;
        }

        public async Task<bool> DeleteAsync(int id, int userId)
        {
            var entity = await _context.Candidates.FindAsync(id);
            if (entity == null)
                return false;

            _context.Candidates.Remove(entity);
            await _context.SaveChangesAsync();
            await AddAuditAsync(entity.Id, "Delete", userId);

            return true;
        }

        private async Task AddAuditAsync(int candidateId, string actionType, int userId)
        {
            var audit = new CandidateAudit
            {
                CandidateId = candidateId,
                ActionTypeId = actionType switch
                {
                    "Insert" => 1,
                    "Update" => 2,
                    "Delete" => 3,
                    _ => 0
                },
                ActionUserId = userId,
                ActionUserAt = DateTime.UtcNow
            };

            await _context.CandidateAudits.AddAsync(audit);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CandidateEntity>> GetTemplateDataAsync()
        {
            return await _context.Candidates
                .AsNoTracking()
                .Take(5)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllGalleryAsync()
        {
            return await Task.FromResult(new List<string>());
        }

        public async Task<IEnumerable<CandidateAudit>> GetAllAuditsAsync(int candidateId)
        {
            return await _context.CandidateAudits
                .Where(a => a.CandidateId == candidateId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
