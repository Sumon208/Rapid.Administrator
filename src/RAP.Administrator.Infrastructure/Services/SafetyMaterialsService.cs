using RAP.Administrator.Application.DTOs.SafetyMaterialsDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.SafetyMaterials;

namespace RAP.Administrator.Infrastructure.Services
{
    public class SafetyMaterialsService : ISafetyMaterialsService
    {
        private readonly ISafetyMaterialsRepository _repository;

        public SafetyMaterialsService(ISafetyMaterialsRepository repository)
        {
            _repository = repository;
        }

        public async Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var (data, totalCount) = await _repository.GetAllAsync(language, pageNumber, pageSize);
                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Safety materials list fetched successfully",
                    IsSuccess = true,
                    Data = new PagedSafetyMaterialsResponse
                    { 
                        Data = data, 
                        TotalCount = totalCount
                    }
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = ex.Message, IsSuccess = false };
            }
        }

        public async Task<RequestResponse> GetByIdAsync(int id)
        {
            try
            {
                var item = await _repository.GetByIdAsync(id);
                if (item == null)
                    return new RequestResponse { StatusCode = "404", Message = "Safety material not found", IsSuccess = false };

                return new RequestResponse { StatusCode = "200", Message = "Record retrieved successfully", IsSuccess = true, Data = item };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = ex.Message, IsSuccess = false };
            }
        }

        public async Task<RequestResponse> CreateAsync(SafetyMaterialsEntity entity, int userId, string language)
        {
            try
            {
                var created = await _repository.CreateAsync(entity, userId, language);
                return new RequestResponse { StatusCode = "201", Message = "Created successfully", IsSuccess = true, Data = created };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = ex.Message, IsSuccess = false };
            }
        }

        public async Task<RequestResponse> CreateBulkAsync(IEnumerable<SafetyMaterialsEntity> entities, int userId, string language)
        {
            try
            {
                var count = await _repository.CreateBulkAsync(entities, userId, language);
                return new RequestResponse { StatusCode = "201", Message = $"{count} records created successfully", IsSuccess = true, Data = count };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = ex.Message, IsSuccess = false };
            }
        }

        public async Task<RequestResponse> UpdateAsync(SafetyMaterialsEntity entity, int userId, string language)
        {
            try
            {
                var success = await _repository.UpdateAsync(entity, userId, language);
                return new RequestResponse
                {
                    StatusCode = success ? "200" : "404",
                    Message = success ? "Updated successfully" : "Record not found",
                    IsSuccess = success
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = ex.Message, IsSuccess = false };
            }
        }

        public async Task<RequestResponse> DeleteAsync(int id, int userId, string language)
        {
            try
            {
                var success = await _repository.DeleteAsync(id, userId, language);
                return new RequestResponse
                {
                    StatusCode = success ? "200" : "404",
                    Message = success ? "Deleted successfully" : "Record not found",
                    IsSuccess = success
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = ex.Message, IsSuccess = false };
            }
        }

        public async Task<RequestResponse> GetTemplateDataAsync()
        {
            try
            {
                var data = await _repository.GetTemplateDataAsync();
                return new RequestResponse { StatusCode = "200", Message = "Template data retrieved", IsSuccess = true, Data = data };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = ex.Message, IsSuccess = false };
            }
        }

        public async Task<RequestResponse> GetAllGalleryAsync()
        {
            try
            {
                var data = await _repository.GetAllGalleryAsync();
                return new RequestResponse { StatusCode = "200", Message = "Gallery fetched", IsSuccess = true, Data = data };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = ex.Message, IsSuccess = false };
            }
        }

        public async Task<RequestResponse> GetAllAuditsAsync(int safetyMaterialsId)
        {
            try
            {
                var audits = await _repository.GetAllAuditsAsync(safetyMaterialsId);
                return new RequestResponse { StatusCode = "200", Message = "Audits retrieved", IsSuccess = true, Data = audits };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = ex.Message, IsSuccess = false };
            }
        }
    }
}
