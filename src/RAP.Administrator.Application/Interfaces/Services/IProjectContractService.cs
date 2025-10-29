using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Domain.Models.ProjectContract;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Services
{
    public interface IProjectContractService
    {
        Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);
        Task<RequestResponse> GetByIdAsync(long id);
        Task<RequestResponse> CreateAsync(ProjectContractEntity entity, int userId, string language);
        Task<RequestResponse> CreateBulkAsync(IEnumerable<ProjectContractEntity> entities, int userId, string language);
        Task<RequestResponse> UpdateAsync(ProjectContractEntity entity, int userId, string language);
        Task<RequestResponse> DeleteAsync(long id, int userId, string language);
        Task<RequestResponse> GetTemplateDataAsync();
        Task<RequestResponse> GetAllGalleryAsync();
        Task<RequestResponse> GetAllAuditsAsync(long projectContractId);
    }
}
