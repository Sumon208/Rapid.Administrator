using RAP.Administrator.Domain.Models.Certificate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Repositories
{
    public interface ICertificateRepository
    {
        Task<(IEnumerable<CertificateEntity> Data, int TotalCount)> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);
        Task<CertificateEntity?> GetByIdAsync(int id);
        Task<CertificateEntity> CreateAsync(CertificateEntity entity, int userId, string language);
        Task<int> CreateBulkAsync(IEnumerable<CertificateEntity> entities, int userId, string language);
        Task<bool> UpdateAsync(CertificateEntity entity, int userId, string language);
        Task<bool> DeleteAsync(int id, int userId, string language);
        Task<IEnumerable<CertificateEntity>> GetTemplateDataAsync();
        Task<IEnumerable<string>> GetAllGalleryAsync();
        Task<IEnumerable<CertificateAuditEntity>> GetAllAuditsAsync(int certificateId);
    }
}
