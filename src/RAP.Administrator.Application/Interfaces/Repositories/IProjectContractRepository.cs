using RAP.Administrator.Domain.Models.ProjectContract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Repositories
{
    public interface IProjectContractRepository
    {
        Task<(IEnumerable<ProjectContractEntity> Data, int TotalCount)> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);
        Task<ProjectContractEntity?> GetByIdAsync(long id);
        Task<ProjectContractEntity> CreateAsync(ProjectContractEntity entity, int userId, string language);
        Task<int> CreateBulkAsync(IEnumerable<ProjectContractEntity> entities, int userId, string language);
        Task<bool> UpdateAsync(ProjectContractEntity entity, int userId, string language);
        Task<bool> DeleteAsync(long id, int userId, string language);
        Task<IEnumerable<ProjectContractEntity>> GetTemplateDataAsync();
        Task<IEnumerable<string>> GetAllGalleryAsync();
        Task<IEnumerable<ProjectContractAudit>> GetAllAuditsAsync(long projectContractId);
    }
}
