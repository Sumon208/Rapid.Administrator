using RAP.Administrator.Domain.Models.SafetyMaterials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Repositories
{
    public interface ISafetyMaterialsRepository
    {
        Task<(IEnumerable<SafetyMaterialsEntity> Data, int TotalCount)> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);
        Task<SafetyMaterialsEntity?> GetByIdAsync(int id);
        Task<SafetyMaterialsEntity> CreateAsync(SafetyMaterialsEntity entity, int userId, string language);
        Task<int> CreateBulkAsync(IEnumerable<SafetyMaterialsEntity> entities, int userId, string language);
        Task<bool> UpdateAsync(SafetyMaterialsEntity entity, int userId, string language);
        Task<bool> DeleteAsync(int id, int userId, string language);
        Task<IEnumerable<SafetyMaterialsEntity>> GetTemplateDataAsync();
        Task<IEnumerable<string>> GetAllGalleryAsync();
        Task<IEnumerable<SafetyMaterialsAuditEntity>> GetAllAuditsAsync(int safetyMaterialsId);
    }
}
