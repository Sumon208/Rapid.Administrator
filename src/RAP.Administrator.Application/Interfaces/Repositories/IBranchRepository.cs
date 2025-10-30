using RAP.Administrator.Domain.Models.Branches;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Repositories
{
    public interface IBranchRepository
    {
        Task<(IEnumerable<BranchEntity> Data, int TotalCount)> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);
        Task<BranchEntity?> GetByIdAsync(int id);
        Task<BranchEntity> CreateAsync(BranchEntity entity, int userId, string language);
        Task<int> CreateBulkAsync(IEnumerable<BranchEntity> entities, int userId, string language);
        Task<bool> UpdateAsync(BranchEntity entity, int userId, string language);
        Task<bool> DeleteAsync(int id, int userId, string language);
        Task<IEnumerable<BranchEntity>> GetTemplateDataAsync();
        Task<IEnumerable<string>> GetAllGalleryAsync();
        Task<IEnumerable<BranchAuditEntity>> GetAllAuditsAsync(int branchId);
    }
}
