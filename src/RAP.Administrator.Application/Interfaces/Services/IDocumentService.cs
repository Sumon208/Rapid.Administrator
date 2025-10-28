using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Domain.Models.Document;


namespace RAP.Administrator.Application.Interfaces.Services
{
    public interface IDocumentService
    {
        Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);
        Task<RequestResponse> GetByIdAsync(long id);
        Task<RequestResponse> CreateAsync(DocumentEntity entity, int userId, string language);
        Task<RequestResponse> CreateBulkAsync(IEnumerable<DocumentEntity> entities, int userId, string language);
        Task<RequestResponse> UpdateAsync(DocumentEntity entity, int userId, string language);
        Task<RequestResponse> DeleteAsync(long id, int userId, string language);
        Task<RequestResponse> GetTemplateDataAsync();
        Task<RequestResponse> GetAllGalleryAsync();
        Task<RequestResponse> GetAllAuditsAsync(long documentId);
    }
}
