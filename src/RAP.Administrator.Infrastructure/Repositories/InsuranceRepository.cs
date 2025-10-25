using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Domain.Models.Insurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Repositories
{
    public class InsuranceRepository : IInsuranceRepository
    {
        private readonly ApplicationDbContext _context;

        public InsuranceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<(IEnumerable<InsuranceEntity> Data, int TotalCount)> GetAllAsync(
            string language, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.Insurances
                .Include(i => i.Localizations)
                .AsNoTracking()
                .OrderByDescending(i => i.Id);

            int totalCount = await query.CountAsync();

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize > 0 ? pageSize : totalCount)
                .ToListAsync();

            return (data, totalCount);
        }

    
        public async Task<InsuranceEntity?> GetByIdAsync(long id)
        {
            return await _context.Insurances
                .Include(i => i.Localizations)
                .Include(i => i.Audits)
                .Include(i => i.ExportInsurances)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

   
        public async Task<InsuranceEntity> CreateAsync(InsuranceEntity entity, int userId, string language)
        {
            _context.Insurances.Add(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Create");
            return entity;
        }

        
        public async Task<int> CreateBulkAsync(IEnumerable<InsuranceEntity> entities, int userId, string language)
        {
            _context.Insurances.AddRange(entities);
            await _context.SaveChangesAsync();

            foreach (var entity in entities)
                await AddAuditAsync(entity.Id, userId, "CreateBulk");

            return entities.Count();
        }

      
        public async Task<bool> UpdateAsync(InsuranceEntity entity, int userId, string language)
        {
            var existing = await _context.Insurances
                .Include(i => i.Localizations)
                .FirstOrDefaultAsync(i => i.Id == entity.Id);

            if (existing == null)
                return false;

            existing.InsuranceName = entity.InsuranceName;
            existing.Description = entity.Description;
            existing.IsDefault = entity.IsDefault;
            existing.IsDraft = entity.IsDraft;
            existing.EmployeeId = entity.EmployeeId;
            existing.Branch = entity.Branch;

            if (entity.Localizations != null)
            {
                _context.InsuranceLocalizations.RemoveRange(existing.Localizations);
                await _context.InsuranceLocalizations.AddRangeAsync(entity.Localizations);
            }

            await _context.SaveChangesAsync();
            await AddAuditAsync(existing.Id, userId, "Update");

            return true;
        }

       
        public async Task<bool> DeleteAsync(long id, int userId, string language)
        {
            var entity = await _context.Insurances
                .Include(i => i.Localizations)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (entity == null)
                return false;

            _context.Insurances.Remove(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Delete");
            return true;
        }

       
        public async Task<IEnumerable<InsuranceEntity>> GetTemplateDataAsync()
        {
            return await _context.Insurances
                .AsNoTracking()
                .Where(i => i.IsDefault)
                .ToListAsync();
        }

       
        public async Task<IEnumerable<string>> GetAllGalleryAsync()
        {
            return new List<string>();
        }

     
        public async Task<IEnumerable<InsuranceAuditEntity>> GetAllAuditsAsync(long insuranceId)
        {
            return await _context.InsuranceAudits
                .AsNoTracking()
                .Where(a => a.InsuranceId == insuranceId)
                .OrderByDescending(a => a.ActionUserAt)
                .ToListAsync();
        }

      
        private async Task AddAuditAsync(int insuranceId, int userId, string actionTypeName)
        {
            var insurance = await _context.Insurances.FindAsync(insuranceId);
            if (insurance == null)
                throw new Exception($"Insurance with Id {insuranceId} not found.");

            var audit = new InsuranceAuditEntity
            {
                InsuranceId = insuranceId,
                ActionUserId = userId,
                ActionUserAt = DateTime.UtcNow,
                ActionTypeId = MapActionType(actionTypeName),
                IsDefault = insurance.IsDefault,
                IsDraft = insurance.IsDraft,
                InsuranceName = insurance.InsuranceName,
                Description = insurance.Description
            };

            _context.InsuranceAudits.Add(audit);
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
