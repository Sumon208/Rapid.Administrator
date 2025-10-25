using RAP.Administrator.Domain.Models.Insurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Repositories
{
    public interface IInsuranceRepository
    {
        Task<(IEnumerable<InsuranceEntity> Data, int TotalCount)> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);
        Task<InsuranceEntity?> GetByIdAsync(long id);
        Task<InsuranceEntity> CreateAsync(InsuranceEntity entity, int userId, string language);
        Task<int> CreateBulkAsync(IEnumerable<InsuranceEntity> entities, int userId, string language);
        Task<bool> UpdateAsync(InsuranceEntity entity, int userId, string language);
        Task<bool> DeleteAsync(long id, int userId, string language);
        Task<IEnumerable<InsuranceEntity>> GetTemplateDataAsync();
        Task<IEnumerable<string>> GetAllGalleryAsync();
        Task<IEnumerable<InsuranceAuditEntity>> GetAllAuditsAsync(long insuranceId);
    }
}
