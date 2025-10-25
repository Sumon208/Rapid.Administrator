using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Domain.Models.Insurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Services
{
    public interface IInsuranceService
    {
        Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);
        Task<RequestResponse> GetByIdAsync(long id);
        Task<RequestResponse> CreateAsync(InsuranceEntity entity, int userId, string language);
        Task<RequestResponse> CreateBulkAsync(IEnumerable<InsuranceEntity> entities, int userId, string language);
        Task<RequestResponse> UpdateAsync(InsuranceEntity entity, int userId, string language);
        Task<RequestResponse> DeleteAsync(long id, int userId, string language);
        Task<RequestResponse> GetTemplateDataAsync();
        Task<RequestResponse> GetAllGalleryAsync();
        Task<RequestResponse> GetAllAuditsAsync(long insuranceId);
    }
}
