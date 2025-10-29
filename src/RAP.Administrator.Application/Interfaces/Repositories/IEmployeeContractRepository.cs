using RAP.Administrator.Domain.Models.EmployeeContract;

namespace RAP.Administrator.Application.Interfaces.Repositories
{
    public interface IEmployeeContractRepository
    {
        Task<(IEnumerable<EmployeeContractEntity> Data, int TotalCount)> GetAllAsync(
            string language, int pageNumber = 1, int pageSize = 10);

        Task<EmployeeContractEntity?> GetByIdAsync(long id);

        Task<EmployeeContractEntity> CreateAsync(EmployeeContractEntity entity, int userId, string language);

        Task<int> CreateBulkAsync(IEnumerable<EmployeeContractEntity> entities, int userId, string language);

        Task<bool> UpdateAsync(EmployeeContractEntity entity, int userId, string language);

        Task<bool> DeleteAsync(long id, int userId, string language);

        Task<IEnumerable<EmployeeContractEntity>> GetTemplateDataAsync();

        Task<IEnumerable<EmployeeContractAudit>> GetAllAuditsAsync(long contractId);
    }
}
