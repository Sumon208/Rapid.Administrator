using RAP.Administrator.Domain.Models;
using RAP.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Repositories
{
    public interface ITaxRepository
    {
        Task<(IEnumerable<TaxEntity> Data, int TotalCount)> GetAllAsync(string language, int pageNumber, int pageSize);
        Task<TaxEntity> GetByIdAsync(int id);
        Task<IEnumerable<TaxEntity>> GetTemplateDataAsync();
        Task<IEnumerable<string>> GetAllGalleryAsync();
        Task<IEnumerable<TaxAuditEntity>> GetAllAuditsAsync(int taxId);

        Task<TaxEntity> CreateAsync(TaxEntity entity, int userId, string language);
        Task<int> CreateBulkAsync(IEnumerable<TaxEntity> entities, int userId, string language);
        Task<bool> UpdateAsync(TaxEntity entity, int userId, string language);
        Task<bool> DeleteAsync(int id, int userId, string language);
    }
}
