using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Domain.Models.Branches;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Services
{
    public interface IBranchService
    {
        Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);
        Task<RequestResponse> GetByIdAsync(int id);
        Task<RequestResponse> CreateAsync(BranchEntity entity, int userId, string language);
        Task<RequestResponse> CreateBulkAsync(IEnumerable<BranchEntity> entities, int userId, string language);
        Task<RequestResponse> UpdateAsync(BranchEntity entity, int userId, string language);
        Task<RequestResponse> DeleteAsync(int id, int userId, string language);
        Task<RequestResponse> GetTemplateDataAsync();
        Task<RequestResponse> GetAllGalleryAsync();
        Task<RequestResponse> GetAllAuditsAsync(int branchId);
    }
}
