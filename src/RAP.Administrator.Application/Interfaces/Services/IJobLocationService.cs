using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Domain.Models.JobLocation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Services
{
    public interface IJobLocationService
    {
        Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);
        Task<RequestResponse> GetByIdAsync(long id);
        Task<RequestResponse> CreateAsync(JobLocationEntity entity, int userId, string language);
        Task<RequestResponse> CreateBulkAsync(IEnumerable<JobLocationEntity> entities, int userId, string language);
        Task<RequestResponse> UpdateAsync(JobLocationEntity entity, int userId, string language);
        Task<RequestResponse> DeleteAsync(long id, int userId, string language);
        Task<RequestResponse> GetTemplateDataAsync();
        Task<RequestResponse> GetAllGalleryAsync();
        Task<RequestResponse> GetAllAuditsAsync(long jobLocationId);
    }
}
