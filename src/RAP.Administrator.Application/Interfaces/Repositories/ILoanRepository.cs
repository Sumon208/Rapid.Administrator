using RAP.Administrator.Domain.Models.Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Repositories
{
    public interface ILoanRepository
    {
        Task<(IEnumerable<LoanEntity> Data, int TotalCount)> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);
        Task<LoanEntity?> GetByIdAsync(long id);
        Task<LoanEntity> CreateAsync(LoanEntity entity, int userId, string language);
        Task<int> CreateBulkAsync(IEnumerable<LoanEntity> entities, int userId, string language);
        Task<bool> UpdateAsync(LoanEntity entity, int userId, string language);
        Task<bool> DeleteAsync(long id, int userId, string language);
        Task<IEnumerable<LoanEntity>> GetTemplateDataAsync();
        Task<IEnumerable<string>> GetAllGalleryAsync();
        Task<IEnumerable<LoanAudit>> GetAllAuditsAsync(long loanId);

    }
}
