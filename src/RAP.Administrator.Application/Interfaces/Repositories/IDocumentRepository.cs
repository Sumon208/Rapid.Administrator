using RAP.Administrator.Domain.Models.Document;


namespace RAP.Administrator.Application.Interfaces.Repositories
{
    public interface IDocumentRepository
    {
        Task<(IEnumerable<DocumentEntity> Data, int TotalCount)> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);
        Task<DocumentEntity?> GetByIdAsync(long id);
        Task<DocumentEntity> CreateAsync(DocumentEntity entity, int userId, string language);
        Task<int> CreateBulkAsync(IEnumerable<DocumentEntity> entities, int userId, string language);
        Task<bool> UpdateAsync(DocumentEntity entity, int userId, string language);
        Task<bool> DeleteAsync(long id, int userId, string language);
        Task<IEnumerable<DocumentEntity>> GetTemplateDataAsync();
        Task<IEnumerable<string>> GetAllGalleryAsync();
        Task<IEnumerable<DocumentAuditEntity>> GetAllAuditsAsync(long documentId);
    }
}
