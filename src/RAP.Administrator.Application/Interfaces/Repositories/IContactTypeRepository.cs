using RAP.Administrator.Domain.Models.ContactType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Repositories
{
    public interface IContactTypeRepository
    {
        Task<(IEnumerable<ContactTypeEntity> Data, int TotalCount)> GetAllAsync(
            string language, int pageNumber = 1, int pageSize = 10);
        Task<ContactTypeEntity?> GetByIdAsync(long id);
        Task<ContactTypeEntity> CreateAsync(ContactTypeEntity entity, int userId, string language);

        Task<int> CreateBulkAsync(IEnumerable<ContactTypeEntity> entities, int userId, string language);
        Task<bool> UpdateAsync(ContactTypeEntity entity, int userId, string language);
        Task<bool> DeleteAsync(long id, int userId, string language);
        Task<IEnumerable<ContactTypeEntity>> GetTemplateDataAsync();
        Task<IEnumerable<string>> GetAllGalleryAsync();
        Task<IEnumerable<ContactTypeAuditEntity>> GetAllAuditsAsync(long contactTypeId);

    }
}
