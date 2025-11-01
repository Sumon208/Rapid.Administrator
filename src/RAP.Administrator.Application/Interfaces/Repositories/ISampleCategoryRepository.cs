using RAP.Administrator.Domain.Models.SampleCategory;

namespace RAP.Administrator.Application.Interfaces.Repositories
{
    public interface ISampleCategoryRepository
    {
        //Task<(IEnumerable<SampleCategoryEntity> Data, int TotalCount)> GetAllAsync(
        //    string language, int pageNumber = 1, int pageSize = 10);
        Task<(IEnumerable<SampleCategoryEntity> Data, int TotalCount)> GetAllAsync(
              string language, int skip, int take);
        Task<SampleCategoryEntity?> GetByIdAsync(int id);

        Task<SampleCategoryEntity> CreateAsync(SampleCategoryEntity entity, int userId, string language);

        Task<int> CreateBulkAsync(IEnumerable<SampleCategoryEntity> entities, int userId, string language);

        Task<bool> UpdateAsync(SampleCategoryEntity entity, int userId, string language);

        Task<bool> DeleteAsync(int id, int userId, string language);

        Task<IEnumerable<SampleCategoryEntity>> GetTemplateDataAsync();

        Task<IEnumerable<SampleCategoryAudit>> GetAllAuditsAsync(int categoryId);
    }
}
