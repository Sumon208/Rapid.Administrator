using RAP.Administrator.Domain.Models.Divisions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Repositories
{
    public interface IDivisionRepository
    {
        
        Task<(IEnumerable<Division> Data, int TotalCount)> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10);       
        Task<Division?> GetByIdAsync(long id);
        Task<Division> CreateAsync(Division entity, int userId, string language);      
        Task<int> CreateBulkAsync(IEnumerable<Division> entities, int userId, string language);        
        Task<bool> UpdateAsync(Division entity, int userId, string language);      
        Task<bool> DeleteAsync(long id, int userId, string language);     
        Task<IEnumerable<Division>> GetTemplateDataAsync();
        Task<IEnumerable<string>> GetAllGalleryAsync();
        Task<IEnumerable<DivisionAudit>> GetAllAuditsAsync(long divisionId);
    }
}
