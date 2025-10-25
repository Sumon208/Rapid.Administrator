using RAP.Administrator.Application.DTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Domain.Models.Tax;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Services
{
    public interface ITaxService
    {
        Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);
        Task<RequestResponse> GetByIdAsync(int id);
        Task<RequestResponse> CreateAsync(TaxEntity entity, int userId, string language);
        Task<RequestResponse> UpdateAsync(TaxUpdateDto entity, int userId, string language);
        Task<RequestResponse> DeleteAsync(int id, int userId, string language);
        Task<RequestResponse> GetTemplateDataAsync();
        Task<RequestResponse> GetAllGalleryAsync();
        Task<RequestResponse> GetAllAuditsAsync(int taxId);
        Task<RequestResponse> CreateBulkAsync(IEnumerable<TaxEntity> entities, int userId, string language);
    }
}
