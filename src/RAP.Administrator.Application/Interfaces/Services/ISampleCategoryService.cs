using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Domain.Models.SampleCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Services
{
    public interface ISampleCategoryService
    {
        Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);
        Task<RequestResponse> GetByIdAsync(int id);
        Task<RequestResponse> CreateAsync(SampleCategoryEntity entity, int userId, string language);
        Task<RequestResponse> CreateBulkAsync(IEnumerable<SampleCategoryEntity> entities, int userId, string language);
        Task<RequestResponse> UpdateAsync(SampleCategoryEntity entity, int userId, string language);
        Task<RequestResponse> DeleteAsync(int id, int userId, string language);
        Task<RequestResponse> GetAllAuditsAsync(int sampleCategoryId);
        Task<RequestResponse> GetTemplateDataAsync();
        Task<RequestResponse> GetAllGalleryAsync();
    }
}
