using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Domain.Models.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Repositories
{
    public class TransferRepository : ITransferRepository
    {
        private readonly ApplicationDbContext _context;

        public TransferRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<TransferEntity> Data, int TotalCount)> GetAllAsync(
            string language, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.Transfers
                .Include(t => t.Localizations)
                .AsNoTracking()
                .Where(t => t.IsDeleted == false || t.IsDeleted == null)
                .OrderByDescending(t => t.Id);

            int totalCount = await query.CountAsync();

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (data, totalCount);
        }

        public async Task<TransferEntity?> GetByIdAsync(int id)
        {
            return await _context.Transfers
                .Include(t => t.Localizations)
                .FirstOrDefaultAsync(t => t.Id == id && (t.IsDeleted == false || t.IsDeleted == null));
        }

        public async Task<TransferEntity> CreateAsync(TransferEntity entity, int userId, string language)
        {
            entity.CreatedById = userId;
            entity.CreatedAt = DateTime.UtcNow;
            entity.IsDeleted = false;

            await _context.Transfers.AddAsync(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, "Insert", userId);
            return entity;
        }

        public async Task<int> CreateBulkAsync(IEnumerable<TransferEntity> entities, int userId, string language)
        {
            foreach (var entity in entities)
            {
                entity.CreatedById = userId;
                entity.CreatedAt = DateTime.UtcNow;
                entity.IsDeleted = false;
            }

            await _context.Transfers.AddRangeAsync(entities);
            int count = await _context.SaveChangesAsync();

            foreach (var entity in entities)
                await AddAuditAsync(entity.Id, "Insert", userId);

            return count;
        }

        public async Task<bool> UpdateAsync(TransferEntity entity, int userId, string language)
        {
            var existing = await _context.Transfers
                .Include(t => t.Localizations)
                .FirstOrDefaultAsync(t => t.Id == entity.Id);

            if (existing == null)
                return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);

            existing.UpdatedById = userId;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            await AddAuditAsync(existing.Id, "Update", userId);

            return true;
        }

        public async Task<bool> DeleteAsync(int id, int userId, string language)
        {
            var entity = await _context.Transfers.FindAsync(id);
            if (entity == null)
                return false;

            entity.IsDeleted = true;
            entity.UpdatedById = userId;
            entity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            await AddAuditAsync(entity.Id, "Delete", userId);

            return true;
        }

        private async Task AddAuditAsync(int transferId, string actionType, int userId)
        {
            var audit = new TransferAudit
            {
                TransferId = transferId,
                ActionTypeId = actionType switch
                {
                    "Insert" => 1,
                    "Update" => 2,
                    "Delete" => 3,
                    _ => 0
                },
                ActionUserId = userId,
              
            };

            await _context.TransferAudits.AddAsync(audit);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TransferEntity>> GetTemplateDataAsync()
        {
            return await _context.Transfers
                .Where(t => t.IsDeleted == false || t.IsDeleted == null)
                .AsNoTracking()
                .Take(5)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllGalleryAsync()
        {
            // You can adjust this logic if the Transfer has media-related data
            return await Task.FromResult(new List<string>());
        }

        public async Task<IEnumerable<TransferAudit>> GetAllAuditsAsync(int transferId)
        {
            return await _context.TransferAudits
                .Where(a => a.TransferId == transferId)           
                .ToListAsync();
        }
    }
}
