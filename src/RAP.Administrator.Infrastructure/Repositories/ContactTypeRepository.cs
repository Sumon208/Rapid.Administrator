using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Domain.Models.ContactType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Repositories
{
    public class ContactTypeRepository : IContactTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

       
        public async Task<(IEnumerable<ContactTypeEntity> Data, int TotalCount)> GetAllAsync(
            string language, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.ContactTypes
                .Include(c => c.Localizations)
                .AsNoTracking()
                .OrderByDescending(c => c.Id);

            int totalCount = await query.CountAsync();

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize > 0 ? pageSize : totalCount)
                .ToListAsync();

            return (data, totalCount);
        }

     
        public async Task<ContactTypeEntity?> GetByIdAsync(long id)
        {
            return await _context.ContactTypes
                .Include(c => c.Localizations)
                .Include(c => c.Audits)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

     
        public async Task<ContactTypeEntity> CreateAsync(ContactTypeEntity entity, int userId, string language)
        {
            _context.ContactTypes.Add(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Create");

            return entity;
        }

       
        public async Task<int> CreateBulkAsync(IEnumerable<ContactTypeEntity> entities, int userId, string language)
        {
            _context.ContactTypes.AddRange(entities);
            await _context.SaveChangesAsync();

            foreach (var entity in entities)
                await AddAuditAsync(entity.Id, userId, "CreateBulk");

            return entities.Count();
        }

     
        public async Task<bool> UpdateAsync(ContactTypeEntity entity, int userId, string language)
        {
            var existing = await _context.ContactTypes
                .Include(c => c.Localizations)
                .FirstOrDefaultAsync(c => c.Id == entity.Id);

            if (existing == null)
                return false;

            existing.ContactType = entity.ContactType;
            existing.Description = entity.Description;

            if (entity.Localizations != null)
            {
                _context.ContactTypeLocalizations.RemoveRange(existing.Localizations);
                await _context.ContactTypeLocalizations.AddRangeAsync(entity.Localizations);
            }

            await _context.SaveChangesAsync();
            await AddAuditAsync(existing.Id, userId, "Update");
            return true;
        }


        public async Task<bool> DeleteAsync(long id, int userId, string language)
        {
            var entity = await _context.ContactTypes
                .Include(c => c.Localizations)
                .Include(c => c.Audits)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (entity == null)
                return false;


            await AddAuditAsync(entity.Id, userId, "Delete");

         
            if (entity.Localizations != null && entity.Localizations.Any())
                _context.ContactTypeLocalizations.RemoveRange(entity.Localizations);

           
            if (entity.Audits != null && entity.Audits.Any())
                _context.ContactTypeAudits.RemoveRange(entity.Audits);

            _context.ContactTypes.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }



        public async Task<IEnumerable<ContactTypeEntity>> GetTemplateDataAsync()
        {
            return await _context.ContactTypes
                .AsNoTracking()
                .ToListAsync();
        }

 
        public async Task<IEnumerable<string>> GetAllGalleryAsync()
        {
            return new List<string>();
        }

      
        public async Task<IEnumerable<ContactTypeAuditEntity>> GetAllAuditsAsync(long contactTypeId)
        {
            return await _context.ContactTypeAudits
                .AsNoTracking()
                .Where(a => a.ContactTypeId == contactTypeId)
                .OrderByDescending(a => a.ActionUserAt)
                .ToListAsync();
        }

       
        private async Task AddAuditAsync(int contactTypeId, int userId, string actionTypeName)
        {
            var contactType = await _context.ContactTypes.FindAsync(contactTypeId);
            if (contactType == null)
                throw new Exception($"ContactType with Id {contactTypeId} not found.");

            var audit = new ContactTypeAuditEntity
            {
                ContactTypeId = contactTypeId,
                ActionUserId = userId,
                ActionUserAt = DateTime.UtcNow,
                ActionTypeId = MapActionType(actionTypeName)
            };

            _context.ContactTypeAudits.Add(audit);
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
