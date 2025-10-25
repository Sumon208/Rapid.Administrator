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

            // Filter localizations by languageId after fetching
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
                candidate.Localizations = candidate.Localizations
                    .Where(l => l.LanguageId == languageId)
                    .ToList();

            return candidate;
        }

        public async Task<CandidateEntity> CreateAsync(CandidateEntity entity, int userId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
               
                _context.Candidates.Add(entity);
                await _context.SaveChangesAsync();

                
                if (entity.Localizations != null && entity.Localizations.Any())
                {
                    foreach (var loc in entity.Localizations)
                    {
                        loc.CandidateId = entity.Id; 
                    }
                    _context.CandidateLocalizations.AddRange(entity.Localizations);
                    await _context.SaveChangesAsync();
                }

                await AddAuditAsync(entity.Id, userId, "Create");

                await transaction.CommitAsync();
                return entity;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw; 
            }
        }


        public async Task<int> CreateBulkAsync(IEnumerable<CandidateEntity> entities, int userId)
        {
            _context.Candidates.AddRange(entities);
            await _context.SaveChangesAsync();

            foreach (var entity in entities)
                await AddAuditAsync(entity.Id, userId, "CreateBulk");

            return entities.Count();
        }

        public async Task<bool> UpdateAsync(CandidateEntity entity, int userId)
        {
            var existing = await _context.Candidates
                .Include(c => c.Localizations)
                .FirstOrDefaultAsync(c => c.Id == entity.Id);

            if (existing == null)
                return false;

            existing.Code = entity.Code;
            existing.Name = entity.Name;
            existing.PositionId = entity.PositionId;
            existing.TeamId = entity.TeamId;
            existing.IsDefault = entity.IsDefault;
            existing.StatusId = entity.StatusId;

            if (entity.Localizations != null)
            {
                _context.CandidateLocalizations.RemoveRange(existing.Localizations);
                await _context.CandidateLocalizations.AddRangeAsync(entity.Localizations);
            }

            await _context.SaveChangesAsync();
            await AddAuditAsync(existing.Id, userId, "Update");
            return true;
        }

        public async Task<bool> DeleteAsync(int id, int userId)
        {
            var entity = await _context.Candidates
                .Include(c => c.Localizations)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (entity == null)
                return false;

            _context.Candidates.Remove(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Delete");
            return true;
        }

        public async Task<IEnumerable<CandidateEntity>> GetTemplateDataAsync(int? languageId = null)
        {
            var query = _context.Candidates
                .Include(c => c.Localizations)
                .Where(c => c.IsDefault)
                .AsNoTracking();

            if (languageId.HasValue)
                query = query.Select(c => new CandidateEntity
                {
                    Id = c.Id,
                    Code = c.Code,
                    Name = c.Name,
                    PositionId = c.PositionId,
                    TeamId = c.TeamId,
                    StatusId = c.StatusId,
                    IsDefault = c.IsDefault,
                    Localizations = c.Localizations.Where(l => l.LanguageId == languageId).ToList()
                }).AsQueryable();

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllGalleryAsync()
        {
            return new List<string>();
        }

        public async Task<IEnumerable<CandidateAudit>> GetAllAuditsAsync(int candidateId)
        {
            return await _context.CandidateAudits
                .AsNoTracking()
                .Where(a => a.CandidateId == candidateId)
                .OrderByDescending(a => a.ActionUserAt)
                .ToListAsync();
        }

        private async Task AddAuditAsync(int candidateId, int userId, string actionTypeName)
        {
            var audit = new CandidateAudit
            {
                CandidateId = candidateId,
                ActionUserId = userId,
                ActionUserAt = DateTime.UtcNow,
                ActionTypeId = MapActionType(actionTypeName)
            };

            _context.CandidateAudits.Add(audit);
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
