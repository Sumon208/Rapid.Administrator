using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Domain.Models.DocumentType;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Services
{
    public interface IDocumentTypeService
    {
        Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);
        Task<RequestResponse> GetByIdAsync(long id);
        Task<RequestResponse> CreateAsync(DocumentTypeEntity entity, int userId, string language);
        Task<RequestResponse> CreateBulkAsync(IEnumerable<DocumentTypeEntity> entities, int userId, string language);
        Task<RequestResponse> UpdateAsync(DocumentTypeEntity entity, int userId, string language);
        Task<RequestResponse> DeleteAsync(long id, int userId, string language);
        Task<RequestResponse> GetTemplateDataAsync();
        Task<RequestResponse> GetAllGalleryAsync();
        Task<RequestResponse> GetAllAuditsAsync(long documentTypeId);
    }
}
