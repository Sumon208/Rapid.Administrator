using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Domain.Models.ContactType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Services
{
    public interface IContactTypeService
    {
        Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);
        Task<RequestResponse> GetByIdAsync(long id);
        Task<RequestResponse> CreateAsync(ContactTypeEntity entity, int userId, string language);
        Task<RequestResponse> CreateBulkAsync(IEnumerable<ContactTypeEntity> entities, int userId, string language);
        Task<RequestResponse> UpdateAsync(ContactTypeEntity entity, int userId, string language);
        Task<RequestResponse> DeleteAsync(long id, int userId, string language);
        Task<RequestResponse> GetTemplateDataAsync();
        Task<RequestResponse> GetAllGalleryAsync();
        Task<RequestResponse> GetAllAuditsAsync(long contactTypeId);

    }
}
