using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Domain.Models.SalaryAdvance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Repositories
{
    public class SalaryAdvanceRepository : ISalaryAdvanceRepository
    {
        private readonly ApplicationDbContext _context;

        public SalaryAdvanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<SalaryAdvanceEntity> Data, int TotalCount)> GetAllAsync(      string language, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.SalaryAdvances
                .Include(sa => sa.Iqma)
                .Include(sa => sa.PaymentMode)
                .Include(sa => sa.Branches)
                .Include(sa => sa.Localizations)
                .AsNoTracking()
                .OrderByDescending(sa => sa.Id);

            int totalCount = await query.CountAsync();

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize > 0 ? pageSize : totalCount)
                .ToListAsync();

            return (data, totalCount);
        }


        public async Task<SalaryAdvanceEntity?> GetByIdAsync(int id)
        {
            return await _context.SalaryAdvances
                .Include(s => s.Localizations)
                .Include(s => s.Audits)
                .Include(s => s.Iqma)
                .Include(s => s.PaymentMode)
                .Include(s => s.Branches)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<SalaryAdvanceEntity> CreateAsync(SalaryAdvanceEntity entity, int userId)
        {
            _context.SalaryAdvances.Add(entity);
            await _context.SaveChangesAsync();
            await AddAuditAsync(entity.Id, userId, "Create");
            return entity;
        }

        public async Task<int> CreateBulkAsync(IEnumerable<SalaryAdvanceEntity> entities, int userId)
        {
            _context.SalaryAdvances.AddRange(entities);
            await _context.SaveChangesAsync();

            foreach (var entity in entities)
                await AddAuditAsync(entity.Id, userId, "CreateBulk");

            return entities.Count();
        }

        public async Task<bool> UpdateAsync(SalaryAdvanceEntity entity, int userId)
        {
            var existing = await _context.SalaryAdvances
                .Include(s => s.Localizations)
                .FirstOrDefaultAsync(s => s.Id == entity.Id);

            if (existing == null) return false;

            existing.IqmaId = entity.IqmaId;
            existing.BranchId = entity.BranchId;
            existing.AdvanceAmount = entity.AdvanceAmount;
            existing.Description = entity.Description;
            existing.PaymentModeId = entity.PaymentModeId;
            existing.Date = entity.Date;

            if (entity.Localizations != null)
            {
                _context.SalaryAdvanceLocalizations.RemoveRange(existing.Localizations);
                await _context.SalaryAdvanceLocalizations.AddRangeAsync(entity.Localizations);
            }

            await _context.SaveChangesAsync();
            await AddAuditAsync(entity.Id, userId, "Update");
            return true;
        }

        public async Task<bool> DeleteAsync(int id, int userId)
        {
            var entity = await _context.SalaryAdvances
                .Include(s => s.Localizations)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (entity == null) return false;

            _context.SalaryAdvances.Remove(entity);
            await _context.SaveChangesAsync();
            await AddAuditAsync(id, userId, "Delete");
            return true;
        }

        public async Task<IEnumerable<SalaryAdvanceEntity>> GetTemplateDataAsync()
        {
            return await _context.SalaryAdvances
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllGalleryAsync()
        {
            return new List<string>();
        }

        public async Task<IEnumerable<SalaryAdvanceAudit>> GetAllAuditsAsync(int salaryAdvanceId)
        {
            return await _context.SalaryAdvanceAudits
                .AsNoTracking()
                .Where(a => a.SalaryAdvanceId == salaryAdvanceId)
                .OrderByDescending(a => a.ActionUserAt)
                .ToListAsync();
        }

        private async Task AddAuditAsync(int salaryAdvanceId, int userId, string actionTypeName)
        {
            var entity = await _context.SalaryAdvances.FindAsync(salaryAdvanceId);
            if (entity == null) throw new Exception($"SalaryAdvance with Id {salaryAdvanceId} not found.");

            var audit = new SalaryAdvanceAudit
            {
                SalaryAdvanceId = salaryAdvanceId,
                ActionUserId = userId,
                ActionUserAt = DateTime.UtcNow,
                ActionTypeId = MapActionType(actionTypeName),
                Name = entity.Description,
               
            };

            _context.SalaryAdvanceAudits.Add(audit);
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
