using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Domain.Models.CandidateSelection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Services
{
    public interface ICandidateService
    {
        Task<RequestResponse> GetAllAsync(int pageNumber = 1, int pageSize = 10, int? languageId = null);
        Task<RequestResponse> GetByIdAsync(int id, int? languageId = null);
        Task<RequestResponse> CreateAsync(CandidateEntity entity, int userId);
        Task<RequestResponse> CreateBulkAsync(IEnumerable<CandidateEntity> entities, int userId);
        Task<RequestResponse> UpdateAsync(CandidateEntity entity, int userId);
        Task<RequestResponse> DeleteAsync(int id, int userId);
        Task<RequestResponse> GetTemplateDataAsync(int? languageId = null);
        Task<RequestResponse> GetAllGalleryAsync();
        Task<RequestResponse> GetAllAuditsAsync(int candidateId);
    }
}
