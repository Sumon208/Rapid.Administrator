using System.Collections.Generic;
using System.Threading.Tasks;
using RAP.Administrator.Domain.Models.DocumentType;

namespace RAP.Administrator.Application.Interfaces.Repositories
{
    public interface IDocumentTypeRepository
    {
        Task<(IEnumerable<DocumentTypeEntity> Data, int TotalCount)> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);
        Task<DocumentTypeEntity?> GetByIdAsync(long id);
        Task<DocumentTypeEntity> CreateAsync(DocumentTypeEntity entity, int userId, string language);
        Task<int> CreateBulkAsync(IEnumerable<DocumentTypeEntity> entities, int userId, string language);
        Task<bool> UpdateAsync(DocumentTypeEntity entity, int userId, string language);
        Task<bool> DeleteAsync(long id, int userId, string language);
        Task<IEnumerable<DocumentCodeTemplate>> GetTemplateDataAsync();
        Task<IEnumerable<string>> GetAllGalleryAsync();
        Task<IEnumerable<DocumentTypeAudit>> GetAllAuditsAsync(long documentTypeId);
    }
}
