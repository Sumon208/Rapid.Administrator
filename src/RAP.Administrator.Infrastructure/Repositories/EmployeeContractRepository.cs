using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Domain.Models.EmployeeContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Repositories
{
    public class EmployeeContractRepository : IEmployeeContractRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeContractRepository(ApplicationDbContext context)
        {
            _context = context;
        }

      
        public async Task<(IEnumerable<EmployeeContractEntity> Data, int TotalCount)> GetAllAsync(
            string language, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.EmployeeContracts
                .Include(c => c.Localizations)
                .Include(c => c.Audits)
                .Include(c => c.ContactType)
                .Include(c => c.Status)
                .Include(c => c.SalaryAllowance)
                .Include(c => c.Staff)
                .AsNoTracking()
                .OrderByDescending(c => c.Id);

            int totalCount = await query.CountAsync();

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize > 0 ? pageSize : totalCount)
                .ToListAsync();

            return (data, totalCount);
        }

        public async Task<EmployeeContractEntity?> GetByIdAsync(long id)
        {
            return await _context.EmployeeContracts
                .Include(c => c.Localizations)
                .Include(c => c.Audits)
                .Include(c => c.ContactType)
                .Include(c => c.Status)
                .Include(c => c.SalaryAllowance)
                .Include(c => c.Staff)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

  
        public async Task<EmployeeContractEntity> CreateAsync(EmployeeContractEntity entity, int userId, string language)
        {
            _context.EmployeeContracts.Add(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Create");
            return entity;
        }

  
        public async Task<int> CreateBulkAsync(IEnumerable<EmployeeContractEntity> entities, int userId, string language)
        {
            _context.EmployeeContracts.AddRange(entities);
            await _context.SaveChangesAsync();

            foreach (var entity in entities)
                await AddAuditAsync(entity.Id, userId, "CreateBulk");

            return entities.Count();
        }

  
        public async Task<bool> UpdateAsync(EmployeeContractEntity entity, int userId, string language)
        {
            var existing = await _context.EmployeeContracts
                .Include(c => c.Localizations)
                .FirstOrDefaultAsync(c => c.Id == entity.Id);

            if (existing == null)
                return false;

            
            existing.ContactTypeId = entity.ContactTypeId;
            existing.StatusId = entity.StatusId;
            existing.SalaryAllowanceId = entity.SalaryAllowanceId;
            existing.StaffId = entity.StaffId;

            if (entity.Localizations != null)
            {
                _context.EmployeeContractLocalizations.RemoveRange(existing.Localizations);
                await _context.EmployeeContractLocalizations.AddRangeAsync(entity.Localizations);
            }

            await _context.SaveChangesAsync();
            await AddAuditAsync(existing.Id, userId, "Update");

            return true;
        }

        // ✅ Delete contract
        public async Task<bool> DeleteAsync(long id, int userId, string language)
        {
            var entity = await _context.EmployeeContracts
                .Include(c => c.Localizations)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (entity == null)
                return false;

            _context.EmployeeContracts.Remove(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Delete");
            return true;
        }

        // ✅ Get template contracts (defaults)
        public async Task<IEnumerable<EmployeeContractEntity>> GetTemplateDataAsync()
        {
            return await _context.EmployeeContracts
               
                .ToListAsync();
        }

        // ✅ Get all audits
        public async Task<IEnumerable<EmployeeContractAudit>> GetAllAuditsAsync(long contractId)
        {
            return await _context.EmployeeContractAudits
                .AsNoTracking()
                .Where(a => a.EmployeeContractId == contractId)
                .OrderByDescending(a => a.ActionUserAt)
                .ToListAsync();
        }

        private async Task AddAuditAsync(int contractId, int userId, string actionTypeName)
        {
            var contract = await _context.EmployeeContracts.FindAsync(contractId);
            if (contract == null)
                throw new Exception($"Contract with Id {contractId} not found.");

            var audit = new EmployeeContractAudit
            {
                EmployeeContractId = contractId,
                ActionUserId = userId,
                ActionUserAt = DateTime.UtcNow,
                ActionTypeId = MapActionType(actionTypeName),
            
       
                StatusId = contract.StatusId,           
           
                       
            };

            _context.EmployeeContractAudits.Add(audit); 
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
