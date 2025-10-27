using RAP.Administrator.Domain.Models.JobLocation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Repositories
{
    public interface IJobLocationRepository
    {
        Task<(IEnumerable<JobLocationEntity> Data, int TotalCount)> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);
        Task<JobLocationEntity?> GetByIdAsync(long id);
        Task<JobLocationEntity> CreateAsync(JobLocationEntity entity, int userId, string language);
        Task<int> CreateBulkAsync(IEnumerable<JobLocationEntity> entities, int userId, string language);
        Task<bool> UpdateAsync(JobLocationEntity entity, int userId, string language);
        Task<bool> DeleteAsync(long id, int userId, string language);
        Task<IEnumerable<JobLocationEntity>> GetTemplateDataAsync();
        Task<IEnumerable<string>> GetAllGalleryAsync();
        Task<IEnumerable<JobLocationAuditEntity>> GetAllAuditsAsync(long jobLocationId);
    }
}
