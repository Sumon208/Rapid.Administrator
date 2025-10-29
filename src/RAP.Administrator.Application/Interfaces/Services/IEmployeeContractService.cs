using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Domain.Models.EmployeeContract;

namespace RAP.Administrator.Application.Interfaces.Services
{
    public interface IEmployeeContractService
    {
        Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);
        Task<RequestResponse> GetByIdAsync(long id);
        Task<RequestResponse> CreateAsync(EmployeeContractEntity entity, int userId, string language);
        Task<RequestResponse> CreateBulkAsync(IEnumerable<EmployeeContractEntity> entities, int userId, string language);
        Task<RequestResponse> UpdateAsync(EmployeeContractEntity entity, int userId, string language);
        Task<RequestResponse> DeleteAsync(long id, int userId, string language);
        Task<RequestResponse> GetTemplateDataAsync();
        Task<RequestResponse> GetAllAuditsAsync(long contractId);
    }
}
