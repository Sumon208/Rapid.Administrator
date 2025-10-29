using RAP.Administrator.Domain.Models.ProjectContractType;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Repositories
{
    public interface IProjectContractTypeRepository
    {
        Task<(IEnumerable<ProjectContractTypeEntity> Data, int TotalCount)> GetAllAsync(
            string language, int pageNumber = 1, int pageSize = 10);

        Task<ProjectContractTypeEntity?> GetByIdAsync(long id);

        Task<ProjectContractTypeEntity> CreateAsync(ProjectContractTypeEntity entity, int userId, string language);

        Task<int> CreateBulkAsync(IEnumerable<ProjectContractTypeEntity> entities, int userId, string language);

        Task<bool> UpdateAsync(ProjectContractTypeEntity entity, int userId, string language);

        Task<bool> DeleteAsync(long id, int userId, string language);

        Task<IEnumerable<ProjectContractTypeEntity>> GetTemplateDataAsync();

        Task<IEnumerable<string>> GetAllGalleryAsync();

        Task<IEnumerable<ProjectContractTypeAudit>> GetAllAuditsAsync(long projectContractTypeId);
    }
}
