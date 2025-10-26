using RAP.Administrator.Domain.Models.Retirement;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Repositories
{
    public interface IRetirementRepository
    {
        
        Task<(IEnumerable<RetirementEntity> Data, int TotalCount)> GetAllAsync(
            string language, int pageNumber = 1, int pageSize = 10);

        
        Task<RetirementEntity?> GetByIdAsync(long id);

       
        Task<RetirementEntity> CreateAsync(RetirementEntity entity, int userId, string language);

      
        Task<int> CreateBulkAsync(IEnumerable<RetirementEntity> entities, int userId, string language);

       
        Task<bool> UpdateAsync(RetirementEntity entity, int userId, string language);

       
        Task<bool> DeleteAsync(long id, int userId, string language);

       
        Task<IEnumerable<RetirementEntity>> GetTemplateDataAsync();

       
        Task<IEnumerable<string>> GetAllGalleryAsync();

        
        Task<IEnumerable<RetirementAudit>> GetAllAuditsAsync(long retirementId);
    }
}
