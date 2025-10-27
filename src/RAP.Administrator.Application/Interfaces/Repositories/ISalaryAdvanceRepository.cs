using RAP.Administrator.Domain.Models.SalaryAdvance;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Repositories
{
    public interface ISalaryAdvanceRepository
    {
        Task<(IEnumerable<SalaryAdvanceEntity> Data, int TotalCount)> GetAllAsync(
     string language, int pageNumber = 1, int pageSize = 10);
        Task<SalaryAdvanceEntity?> GetByIdAsync(int id);
        Task<SalaryAdvanceEntity> CreateAsync(SalaryAdvanceEntity entity, int userId);
        Task<int> CreateBulkAsync(IEnumerable<SalaryAdvanceEntity> entities, int userId);
        Task<bool> UpdateAsync(SalaryAdvanceEntity entity, int userId);
        Task<bool> DeleteAsync(int id, int userId);
        Task<IEnumerable<SalaryAdvanceEntity>> GetTemplateDataAsync();
        Task<IEnumerable<string>> GetAllGalleryAsync();
        Task<IEnumerable<SalaryAdvanceAudit>> GetAllAuditsAsync(int salaryAdvanceId);
    }
}
