using RAP.Administrator.Domain.Models.LoanType;

namespace RAP.Administrator.Application.Interfaces.Repositories
{
    public interface ILoanTypeRepository
    {
        Task<(IEnumerable<LoanTypeEntity> Data, int TotalCount)> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);
        Task<LoanTypeEntity?> GetByIdAsync(long id);
        Task<LoanTypeEntity> CreateAsync(LoanTypeEntity entity, int userId, string language);
        Task<int> CreateBulkAsync(IEnumerable<LoanTypeEntity> entities, int userId, string language);
        Task<bool> UpdateAsync(LoanTypeEntity entity, int userId, string language);
        Task<bool> DeleteAsync(long id, int userId, string language);
        Task<IEnumerable<LoanTypeEntity>> GetTemplateDataAsync();
        Task<IEnumerable<string>> GetAllGalleryAsync();
        Task<IEnumerable<LoanTypeAudit>> GetAllAuditsAsync(long loanTypeId);
    }
}
