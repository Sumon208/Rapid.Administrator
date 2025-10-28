using Microsoft.EntityFrameworkCore;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Domain.Models.Document;


namespace RAP.Administrator.Infrastructure.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly ApplicationDbContext _context;

        public DocumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<DocumentEntity> Data, int TotalCount)> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.Documents
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

        public async Task<DocumentEntity?> GetByIdAsync(long id)
        {
            return await _context.Documents
                .Include(d => d.Localizations)
                .Include(d => d.Audits)
                .Include(d => d.Exports)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<DocumentEntity> CreateAsync(DocumentEntity entity, int userId, string language)
        {
            _context.Documents.Add(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Create");
            return entity;
        }

        public async Task<int> CreateBulkAsync(IEnumerable<DocumentEntity> entities, int userId, string language)
        {
            _context.Documents.AddRange(entities);
            await _context.SaveChangesAsync();

            foreach (var entity in entities)
                await AddAuditAsync(entity.Id, userId, "CreateBulk");

            return entities.Count();
        }

        public async Task<bool> UpdateAsync(DocumentEntity entity, int userId, string language)
        {
            var existing = await _context.Documents
                .Include(d => d.Localizations)
                .FirstOrDefaultAsync(d => d.Id == entity.Id);

            if (existing == null)
                return false;

            // Map fields
            existing.DocumentNo = entity.DocumentNo;
            existing.PINo = entity.PINo;
            existing.InvoiceNo = entity.InvoiceNo;
            existing.PIDate = entity.PIDate;
            existing.InvoiceDate = entity.InvoiceDate;
            existing.DocumentDate = entity.DocumentDate;
            existing.MobileNo = entity.MobileNo;
            existing.OrderById = entity.OrderById;
            existing.ShipmentTypeId = entity.ShipmentTypeId;
            existing.IsDefault = entity.IsDefault;
            existing.IsDraft = entity.IsDraft;

            if (entity.Localizations != null)
            {
                _context.DocumentLocalizations.RemoveRange(existing.Localizations);
                await _context.DocumentLocalizations.AddRangeAsync(entity.Localizations);
            }

            await _context.SaveChangesAsync();
            await AddAuditAsync(existing.Id, userId, "Update");
            return true;
        }

        public async Task<bool> DeleteAsync(long id, int userId, string language)
        {
            var entity = await _context.Documents
                .Include(d => d.Localizations)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (entity == null)
                return false;

            _context.Documents.Remove(entity);
            await _context.SaveChangesAsync();

            await AddAuditAsync(entity.Id, userId, "Delete");
            return true;
        }

        public async Task<IEnumerable<DocumentEntity>> GetTemplateDataAsync()
        {
            return await _context.Documents
                .AsNoTracking()
                .Where(d => d.IsDraft == false)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllGalleryAsync()
        {
            return new List<string>(); // Placeholder
        }

        public async Task<IEnumerable<DocumentAuditEntity>> GetAllAuditsAsync(long documentId)
        {
            return await _context.DocumentAudits
                .AsNoTracking()
                .Where(a => a.DocumentId == documentId)
                .OrderByDescending(a => a.ActionUserAt)
                .ToListAsync();
        }

        private async Task AddAuditAsync(int documentId, int userId, string actionTypeName)
        {
            var document = await _context.Documents.FindAsync(documentId);
            if (document == null)
                throw new Exception($"Document with Id {documentId} not found.");

            var audit = new DocumentAuditEntity
            {
               
                ActionUserId = userId,
                ActionUserAt = DateTime.UtcNow,
                Name = document.DocumentNo,
                ActionTypeId = MapActionType(actionTypeName),
                IsDefault = document.IsDefault,
                StatusId = true
            };

            _context.DocumentAudits.Add(audit);
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
