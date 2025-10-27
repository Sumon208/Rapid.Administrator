using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Domain.Models.SalaryAdvance;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Services
{
    public interface ISalaryAdvanceService
    {
        Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);

        Task<RequestResponse> GetByIdAsync(int id);
        Task<RequestResponse> CreateAsync(SalaryAdvanceEntity entity, int userId, string language);

        Task<RequestResponse> CreateBulkAsync(IEnumerable<SalaryAdvanceEntity> entities, int userId, string language);

        Task<RequestResponse> UpdateAsync(SalaryAdvanceEntity entity, int userId, string language);
        Task<RequestResponse> DeleteAsync(int id, int userId);
        Task<RequestResponse> GetTemplateDataAsync();
        Task<RequestResponse> GetAllGalleryAsync();
        Task<RequestResponse> GetAllAuditsAsync(int salaryAdvanceId);
    }
}
