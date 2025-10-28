using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Domain.Models.LoanType;

namespace RAP.Administrator.Application.Interfaces.Services
{
    public interface ILoanTypeService
    {
        Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);
        Task<RequestResponse> GetByIdAsync(long id);
        Task<RequestResponse> CreateAsync(LoanTypeEntity entity, int userId, string language);
        Task<RequestResponse> CreateBulkAsync(IEnumerable<LoanTypeEntity> entities, int userId, string language);
        Task<RequestResponse> UpdateAsync(LoanTypeEntity entity, int userId, string language);
        Task<RequestResponse> DeleteAsync(long id, int userId, string language);
        Task<RequestResponse> GetTemplateDataAsync();
        Task<RequestResponse> GetAllGalleryAsync();
        Task<RequestResponse> GetAllAuditsAsync(long loanTypeId);
    }
}
