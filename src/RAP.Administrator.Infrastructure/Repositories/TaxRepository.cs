using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Domain.Models.Tax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Repositories
{
    public class TaxRepository : ITaxRepository
    {
        private readonly ApplicationDbContext _context;

        public TaxRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<TaxEntity> Data, int TotalCount)> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;

            var query = _context.Taxes
                .AsNoTracking()
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.CreatedDate);

            var totalCount = await query.CountAsync();

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (data, totalCount);
        }

        public async Task<TaxEntity> GetByIdAsync(int id)
        {
            return await _context.Taxes
                .Include(x => x.Audits)
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task<IEnumerable<TaxEntity>> GetTemplateDataAsync()
        {
            return await _context.Taxes
                .AsNoTracking()
                .Where(x => x.IsActive && !x.IsDeleted)
                .ToListAsync();
        }
        
        public async Task<IEnumerable<string>> GetAllGalleryAsync()
        {
            return new List<string>(); // Not implemented
        }

        public async Task<IEnumerable<TaxAuditEntity>> GetAllAuditsAsync(int taxId)
        {
            return await _context.TaxAudits
                .AsNoTracking()
                .Where(a => a.CountryId == taxId)
                .OrderByDescending(a => a.ActionUserAt)
                .ToListAsync();
        }

        public async Task<TaxEntity> CreateAsync(TaxEntity entity, int userId, string language)
        {
            entity.IsActive = true;
            entity.IsDraft = false;
            entity.IsDeleted = false;
            entity.CreatedDate = DateTime.UtcNow;

            _context.Taxes.Add(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Create");
            return entity;
        }

        public async Task<int> CreateBulkAsync(IEnumerable<TaxEntity> entities, int userId, string language)
        {
            foreach (var entity in entities)
            {
                entity.CreatedDate = DateTime.UtcNow;
                entity.IsActive = true;
                entity.IsDeleted = false;
                entity.IsDraft = false;
            }

            _context.Taxes.AddRange(entities);
            await _context.SaveChangesAsync();

            foreach (var entity in entities)
                await AddAuditAsync(entity.Id, userId, "CreateBulk");

            return entities.Count();
        }

        public async Task<bool> UpdateAsync(TaxEntity entity, int userId, string language)
        {
            if (entity == null || entity.Id <= 0)
                return false;

            var existing = await _context.Taxes.FirstOrDefaultAsync(x => x.Id == entity.Id && !x.IsDeleted);
            if (existing == null)
                return false;

            existing.BankName = entity.BankName ?? existing.BankName;
            existing.AccountNumber = entity.AccountNumber ?? existing.AccountNumber;
            existing.BranchName = entity.BranchName ?? existing.BranchName;
            existing.IBANNumber = entity.IBANNumber ?? existing.IBANNumber;
            existing.OpeningBalance = entity.OpeningBalance;
            existing.Address = entity.Address ?? existing.Address;
            existing.BankDetails = entity.BankDetails ?? existing.BankDetails;
            existing.IsDefault = entity.IsDefault;
            existing.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            await AddAuditAsync(existing.Id, userId, "Update");

            return true;
        }


        public async Task<bool> DeleteAsync(int id, int userId, string language)
        {
            var entity = await _context.Taxes.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
            if (entity == null)
                return false;

            entity.IsDeleted = true;
            entity.DeletedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            await AddAuditAsync(entity.Id, userId, "Delete");
            return true;
        }

        private async Task AddAuditAsync(int taxId, int userId, string actionType)
        {
            var audit = new TaxAuditEntity
            {
                CountryId = taxId,
                ActionUserId = userId,
                ActionUserAt = DateTime.UtcNow,
                ActionTypeId = MapActionType(actionType),
                Browser = "N/A",
                Location = "N/A",
                IP = "N/A",
                OS = "N/A"
            };

            await _context.TaxAudits.AddAsync(audit);
            await _context.SaveChangesAsync();
        }

        private int MapActionType(string action)
        {
            return action switch
            {
                "Create" => 1,
                "CreateBulk" => 2,
                "Update" => 3,
                "Delete" => 4,
                _ => 0
            };
        }
    }
}
