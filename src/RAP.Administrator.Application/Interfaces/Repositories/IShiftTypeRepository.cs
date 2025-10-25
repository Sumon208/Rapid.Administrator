using RAP.Administrator.Domain.Models.ShiftType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Repositories
{
    public interface IShiftTypeRepository
    {
        Task<(IEnumerable<ShiftType> Data, int TotalCount)> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);
        Task<ShiftType?> GetByIdAsync(long id);
        Task<ShiftType> CreateAsync(ShiftType entity, int userId, string language);
        Task<int> CreateBulkAsync(IEnumerable<ShiftType> entities, int userId, string language);
        Task<bool> UpdateAsync(ShiftType entity, int userId, string language);
        Task<bool> DeleteAsync(long id, int userId, string language);
        Task<IEnumerable<ShiftType>> GetTemplateDataAsync();
        Task<IEnumerable<string>> GetAllGalleryAsync();
        Task<IEnumerable<ShiftTypeAudit>> GetAllAuditsAsync(long shiftTypeId);
    }
}
