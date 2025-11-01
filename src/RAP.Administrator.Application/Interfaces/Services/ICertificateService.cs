using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Domain.Models.Certificate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Services
{
    public interface ICertificateService
    {
        Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);
        Task<RequestResponse> GetByIdAsync(int id);
        Task<RequestResponse> CreateAsync(CertificateEntity entity, int userId, string language);
        Task<RequestResponse> CreateBulkAsync(IEnumerable<CertificateEntity> entities, int userId, string language);
        Task<RequestResponse> UpdateAsync(CertificateEntity entity, int userId, string language);
        Task<RequestResponse> DeleteAsync(int id, int userId, string language);
        Task<RequestResponse> GetTemplateDataAsync();
        Task<RequestResponse> GetAllGalleryAsync();
        Task<RequestResponse> GetAllAuditsAsync(int certificateId);
    }
}
