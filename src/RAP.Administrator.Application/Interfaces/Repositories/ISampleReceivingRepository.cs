using RAP.Administrator.Domain.Models.SampleReceiving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Repositories
{
    public interface ISampleReceivingRepository
    {
        Task<(IEnumerable<SampleReceivingEntity> Data, int TotalCount)> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);
        Task<SampleReceivingEntity?> GetByIdAsync(long id);
        Task<SampleReceivingEntity> CreateAsync(SampleReceivingEntity entity, int userId, string language);
        Task<int> CreateBulkAsync(IEnumerable<SampleReceivingEntity> entities, int userId, string language);
        Task<bool> UpdateAsync(SampleReceivingEntity entity, int userId, string language);
        Task<bool> DeleteAsync(long id, int userId, string language);
        Task<IEnumerable<SampleReceivingEntity>> GetTemplateDataAsync();
        Task<IEnumerable<string>> GetAllGalleryAsync();
        Task<IEnumerable<SampleReceivedAuditEntity>> GetAllAuditsAsync(long receivedId);
    }
}
