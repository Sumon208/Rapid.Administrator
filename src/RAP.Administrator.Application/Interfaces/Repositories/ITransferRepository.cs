using RAP.Administrator.Domain.Models.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.Interfaces.Repositories
{
    public interface ITransferRepository
    {
        Task<(IEnumerable<TransferEntity> Data, int TotalCount)> GetAllAsync(
            string language, int pageNumber = 1, int pageSize = 10);

        Task<TransferEntity?> GetByIdAsync(int id);

        Task<TransferEntity> CreateAsync(TransferEntity entity, int userId, string language);

        Task<int> CreateBulkAsync(IEnumerable<TransferEntity> entities, int userId, string language);

        Task<bool> UpdateAsync(TransferEntity entity, int userId, string language);

        Task<bool> DeleteAsync(int id, int userId, string language);

        Task<IEnumerable<TransferEntity>> GetTemplateDataAsync();

        Task<IEnumerable<string>> GetAllGalleryAsync();

        Task<IEnumerable<TransferAudit>> GetAllAuditsAsync(int transferId);
    }
}
