using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Domain.Models.DocumentType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Repositories
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public DocumentTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DocumentTypeEntity> Data, int TotalCount)> GetAllAsync(
            string language, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.DocumentTypes
                .Include(d => d.Localizations)
                .AsNoTracking()
                .OrderByDescending(d => d.Id);

            int totalCount = await query.CountAsync();

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize > 0 ? pageSize : totalCount)
                .ToListAsync();

            return (data, totalCount);
        }

        public async Task<DocumentTypeEntity?> GetByIdAsync(long id)
        {
           
            return await _context.DocumentTypes
                .Include(d => d.Localizations)
                .Include(d => d.Audits)
                .Include(d => d.Exports)
                .FirstOrDefaultAsync(d => d.Id == (int)id);
        }

        public async Task<DocumentTypeEntity> CreateAsync(DocumentTypeEntity entity, int userId, string language)
        {
         
            _context.DocumentTypes.Add(entity);
            await _context.SaveChangesAsync();

            
            await AddAuditAsync(entity.Id, userId, "Create");

            return entity;
        }

        public async Task<int> CreateBulkAsync(IEnumerable<DocumentTypeEntity> entities, int userId, string language)
        {
            var list = entities?.ToList() ?? new List<DocumentTypeEntity>();
            if (!list.Any())
                return 0;

           
            _context.DocumentTypes.AddRange(list);
            await _context.SaveChangesAsync(); 


            var audits = new List<DocumentTypeAudit>();
            foreach (var entity in list)
            {
                audits.Add(new DocumentTypeAudit
                {
                    DocumentTypeId = entity.Id,
                    ActionUserId = userId,
                    ActionUserAt = DateTime.UtcNow,
                    ActionTypeId = MapActionType("CreateBulk"),
                    IsDefault = entity.IsDefault,
                    StatusId = entity.StatusId
                });
            }

            if (audits.Any())
            {
                _context.DocumentTypeAudits.AddRange(audits);
                await _context.SaveChangesAsync(); 
            }

            return list.Count;
        }

        public async Task<bool> UpdateAsync(DocumentTypeEntity entity, int userId, string language)
        {
            var existing = await _context.DocumentTypes
                .Include(d => d.Localizations)
                .FirstOrDefaultAsync(d => d.Id == entity.Id);

            if (existing == null)
                return false;

           
            existing.Name = entity.Name;
            existing.IsDefault = entity.IsDefault;
            existing.StatusId = entity.StatusId;

          
            if (entity.Localizations != null)
            {
                if (existing.Localizations != null && existing.Localizations.Any())
                {
                    _context.DocumentTypeLocalizations.RemoveRange(existing.Localizations);
                }

                // Ensure new localization entities have DocumentTypeId set (optional)
                foreach (var loc in entity.Localizations)
                {
                    loc.DocumentTypeId = existing.Id;
                }

                await _context.DocumentTypeLocalizations.AddRangeAsync(entity.Localizations);
            }

            await _context.SaveChangesAsync();

            await AddAuditAsync(existing.Id, userId, "Update");
            return true;
        }

        public async Task<bool> DeleteAsync(long id, int userId, string language)
        {
            var entity = await _context.DocumentTypes
                .Include(d => d.Localizations)
                .FirstOrDefaultAsync(d => d.Id == (int)id);

            if (entity == null)
                return false;

            _context.DocumentTypes.Remove(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Delete");
            return true;
        }

        public async Task<IEnumerable<DocumentCodeTemplate>> GetTemplateDataAsync()
        {
            return await _context.DocumentCodeTemplates
                .AsNoTracking()
                .Where(t => t.IsActive == true)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllGalleryAsync()
        {
            // If you don't have gallery table yet, return empty list.
            // If later you add DocumentTypeGallery entity, implement accordingly.
            return new List<string>();
        }

        public async Task<IEnumerable<DocumentTypeAudit>> GetAllAuditsAsync(long documentTypeId)
        {
            return await _context.DocumentTypeAudits
                .AsNoTracking()
                .Where(a => a.DocumentTypeId == (int)documentTypeId)
                .OrderByDescending(a => a.ActionUserAt)
                .ToListAsync();
        }

     
        private async Task AddAuditAsync(int documentTypeId, int userId, string action)
        {
            var entity = await _context.DocumentTypes.FindAsync(documentTypeId);
            if (entity == null)
                throw new Exception($"DocumentType with Id {documentTypeId} not found.");

            var audit = new DocumentTypeAudit
            {
                DocumentTypeId = documentTypeId,
                ActionUserId = userId,
                ActionUserAt = DateTime.UtcNow,
                ActionTypeId = MapActionType(action),
                IsDefault = entity.IsDefault,
                StatusId = entity.StatusId,
               
                Name = entity.Name
            };

            _context.DocumentTypeAudits.Add(audit);
            await _context.SaveChangesAsync();
        }

        private short MapActionType(string action) => action switch
        {
            "Create" => 1,
            "CreateBulk" => 2,
            "Update" => 3,
            "Delete" => 4,
            _ => (short)0
        };
    }
}
