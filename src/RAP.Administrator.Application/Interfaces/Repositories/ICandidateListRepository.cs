using RAP.Administrator.Domain.Models.CandidateList;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Repositories
{
    public interface ICandidateListRepository
    {
        Task<(IEnumerable<CandidateListEntity> Data, int TotalCount)> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);
        Task<CandidateListEntity?> GetByIdAsync(long id);
        Task<CandidateListEntity> CreateAsync(CandidateListEntity entity, int userId, string language);
        Task<int> CreateBulkAsync(IEnumerable<CandidateListEntity> entities, int userId, string language);
        Task<bool> UpdateAsync(CandidateListEntity entity, int userId, string language);
        Task<bool> DeleteAsync(long id, int userId, string language);
        Task<IEnumerable<CandidateListEntity>> GetTemplateDataAsync();
        Task<IEnumerable<string>> GetAllGalleryAsync();
        Task<IEnumerable<CandidateListAudit>> GetAllAuditsAsync(long candidateId);
    }
}
