using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Domain.Models.CandidateList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Repositories
{
    public class CandidateListRepository : ICandidateListRepository
    {
        private readonly ApplicationDbContext _context;

        public CandidateListRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<CandidateListEntity> Data, int TotalCount)> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.CandidateLists
                .Include(c => c.Localizations)
                .Include(c => c.Audits)
                .AsNoTracking()
                .OrderByDescending(c => c.Id);

            int totalCount = await query.CountAsync();

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize > 0 ? pageSize : totalCount)
                .ToListAsync();

            return (data, totalCount);
        }

        public async Task<CandidateListEntity?> GetByIdAsync(long id)
        {
            return await _context.CandidateLists
                .Include(c => c.Localizations)
                .Include(c => c.Audits)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<CandidateListEntity> CreateAsync(CandidateListEntity entity, int userId, string language)
        {
            _context.CandidateLists.Add(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Create");
            return entity;
        }

        public async Task<int> CreateBulkAsync(IEnumerable<CandidateListEntity> entities, int userId, string language)
        {
            _context.CandidateLists.AddRange(entities);
            await _context.SaveChangesAsync();

            foreach (var entity in entities)
                await AddAuditAsync(entity.Id, userId, "CreateBulk");

            return entities.Count();
        }

        public async Task<bool> UpdateAsync(CandidateListEntity entity, int userId, string language)
        {
            var existing = await _context.CandidateLists
                .Include(c => c.Localizations)
                .FirstOrDefaultAsync(c => c.Id == entity.Id);

            if (existing == null)
                return false;

            existing.FirstName = entity.FirstName;
            existing.LastName = entity.LastName;
            existing.Email = entity.Email;
            existing.Phone = entity.Phone;
            existing.AlternatePhone = entity.AlternatePhone;
            existing.SSN = entity.SSN;
            existing.PresentAddress = entity.PresentAddress;
            existing.PermanentAddress = entity.PermanentAddress;
            existing.ZipCode = entity.ZipCode;
            existing.CountryId = entity.CountryId;
            existing.IsActive = entity.IsActive;

            if (entity.Localizations != null)
            {
                _context.CandidateListLocalizations.RemoveRange(existing.Localizations);
                await _context.CandidateListLocalizations.AddRangeAsync(entity.Localizations);
            }

            await _context.SaveChangesAsync();
            await AddAuditAsync(existing.Id, userId, "Update");

            return true;
        }

        public async Task<bool> DeleteAsync(long id, int userId, string language)
        {
            var entity = await _context.CandidateLists
                .Include(c => c.Localizations)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (entity == null)
                return false; 

            _context.CandidateLists.Remove(entity);
            await _context.SaveChangesAsync();

            
            try
            {
                await AddAuditAsync(entity.Id, userId, "Delete");
            }
            catch
            {
                
            }

            return true;
        }

        public async Task<IEnumerable<CandidateListEntity>> GetTemplateDataAsync()
        {
            return await _context.CandidateLists
                .AsNoTracking()
                .Where(c => c.IsActive == true)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllGalleryAsync()
        {
           
            return new List<string>();
        }

        public async Task<IEnumerable<CandidateListAudit>> GetAllAuditsAsync(long candidateId)
        {
            return await _context.CandidateListAudits
                .AsNoTracking()
                .Where(a => a.CandidateId == candidateId)
                .OrderByDescending(a => a.ActionUserAt)
                .ToListAsync();
        }

        private async Task AddAuditAsync(int candidateListId, int userId, string actionTypeName)
        {
            var candidate = await _context.CandidateLists.FindAsync(candidateListId);
            if (candidate == null)
                throw new Exception($"CandidateList with Id {candidateListId} not found.");

            var audit = new CandidateListAudit
            {
                CandidateId = candidateListId,
                ActionUserId = userId,
                ActionUserAt = DateTime.UtcNow,
                ActionTypeId = MapActionType(actionTypeName),
         
            };

            _context.CandidateListAudits.Add(audit);
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
