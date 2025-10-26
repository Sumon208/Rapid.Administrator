using RAP.Administrator.Domain.Models.Retirement;
using RAP.Administrator.Application.DTOs.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Services
{
    public interface IRetirementService
    {
        Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);
        Task<RequestResponse> GetByIdAsync(long id);
        Task<RequestResponse> CreateAsync(RetirementEntity entity, int userId, string language);
        Task<RequestResponse> CreateBulkAsync(IEnumerable<RetirementEntity> entities, int userId, string language);
        Task<RequestResponse> UpdateAsync(RetirementEntity entity, int userId, string language);
        Task<RequestResponse> DeleteAsync(long id, int userId, string language);
        Task<RequestResponse> GetTemplateDataAsync();
        Task<RequestResponse> GetAllGalleryAsync();
        Task<RequestResponse> GetAllAuditsAsync(long retirementId);
    }
}
