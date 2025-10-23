using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Repositories
{
    public class ShiftTypeRepository : IShiftTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public ShiftTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<ShiftType> Data, int TotalCount)> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.ShiftTypes
                .Include(s => s.Localizations)
                .AsNoTracking()
                .OrderByDescending(s => s.Id);

            int totalCount = await query.CountAsync();
            var data = await query.Skip((pageNumber - 1) * pageSize)
                                  .Take(pageSize > 0 ? pageSize : totalCount)
                                  .ToListAsync();

            return (data, totalCount);
        }

        public async Task<ShiftType?> GetByIdAsync(long id)
        {
            return await _context.ShiftTypes
                .Include(s => s.Localizations)
                .Include(s => s.Audits)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<ShiftType> CreateAsync(ShiftType entity, int userId, string language)
        {
            _context.ShiftTypes.Add(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Create");
            return entity;
        }

        public async Task<int> CreateBulkAsync(IEnumerable<ShiftType> entities, int userId, string language)
        {
            _context.ShiftTypes.AddRange(entities);
            await _context.SaveChangesAsync();

            foreach (var e in entities)
                await AddAuditAsync(e.Id, userId, "CreateBulk");

            return entities.Count();
        }

        public async Task<bool> UpdateAsync(ShiftType entity, int userId, string language)
        {
            var existing = await _context.ShiftTypes
                .Include(s => s.Localizations)
                .FirstOrDefaultAsync(s => s.Id == entity.Id);

            if (existing == null)
                return false;

          
            existing.Name = entity.Name;
            existing.Color = entity.Color;
            existing.StartTime = entity.StartTime;
            existing.EndTime = entity.EndTime;
            existing.BreakTime = entity.BreakTime;
            existing.Status = entity.Status;
            existing.IsDefault = entity.IsDefault;

            
            if (entity.Localizations != null)
            {
                _context.ShiftTypeLocalizations.RemoveRange(existing.Localizations);
                await _context.ShiftTypeLocalizations.AddRangeAsync(entity.Localizations);
            }

            await _context.SaveChangesAsync();

            
            await AddAuditAsync(existing.Id, userId, "Update");
            return true;
        }


        public async Task<bool> DeleteAsync(long id, int userId, string language)
        {
            var entity = await _context.ShiftTypes
                .Include(s => s.Localizations)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (entity == null)
                return false;

            _context.ShiftTypes.Remove(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Delete");
            return true;
        }

        public async Task<IEnumerable<ShiftType>> GetTemplateDataAsync()
        {
            return await _context.ShiftTypes
                .AsNoTracking()
                .Where(s => s.Status == "Active")
                .ToListAsync();
        }


        public async Task<IEnumerable<string>> GetAllGalleryAsync()
        {
            return new List<string>();
        }

        public async Task<IEnumerable<ShiftTypeAudit>> GetAllAuditsAsync(long shiftTypeId)
        {
            return await _context.ShiftTypeAudits
                .AsNoTracking()
                .Where(a => a.ShiftTypeId == shiftTypeId)
                .OrderByDescending(a => a.ActionAt)
                .ToListAsync();
        }
        private async Task AddAuditAsync(long shiftTypeId, int userId, string actionType)
        {
            var shiftType = await _context.ShiftTypes.FindAsync(shiftTypeId);
            if (shiftType == null)
                throw new Exception($"ShiftType with Id {shiftTypeId} not found.");

            var audit = new ShiftTypeAudit
            {
                ShiftTypeId = shiftTypeId,
                ActionUserId = userId,
                ActionAt = DateTime.UtcNow,
                ActionTypeName = actionType,
                IsDefault = shiftType.IsDefault,
                Status = shiftType.Status  
            };

            _context.ShiftTypeAudits.Add(audit);
            await _context.SaveChangesAsync();
        }


    }
}
