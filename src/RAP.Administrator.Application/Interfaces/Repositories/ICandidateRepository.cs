using RAP.Administrator.Domain.Models.CandidateSelection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Repositories
{
    public interface ICandidateRepository
    {
        Task<(IEnumerable<CandidateEntity> Data, int TotalCount)> GetAllAsync(
             int pageNumber = 1, int pageSize = 10, int? languageId = null);

        Task<CandidateEntity?> GetByIdAsync(int id, int? languageId = null);

        Task<CandidateEntity> CreateAsync(CandidateEntity entity, int userId);

        Task<int> CreateBulkAsync(IEnumerable<CandidateEntity> entities, int userId);

        Task<bool> UpdateAsync(CandidateEntity entity, int userId);
        Task<bool> DeleteAsync(int id, int userId);

        Task<IEnumerable<CandidateEntity>> GetTemplateDataAsync(int? languageId = null);

        Task<IEnumerable<string>> GetAllGalleryAsync();

        Task<IEnumerable<CandidateAudit>> GetAllAuditsAsync(int candidateId);
    }
}
