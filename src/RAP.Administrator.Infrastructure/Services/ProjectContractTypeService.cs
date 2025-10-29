using RAP.Administrator.Application.DTOs.ProjectContractTypeDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.ProjectContractType;

using RAP.Administrator.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Services
{
    public class ProjectContractTypeService : IProjectContractTypeService
    {
        private readonly IProjectContractTypeRepository _repository;

        public ProjectContractTypeService(IProjectContractTypeRepository repository)
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
                    Message = "Project contract types fetched successfully",
                    IsSuccess = true,
                    Data = new PagedProjectContractTypeResponse
                    {
                        Data = data,
                        TotalCount = totalCount
                    }
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error fetching data: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> GetByIdAsync(long id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                    return new RequestResponse { StatusCode = "404", Message = "Not found", IsSuccess = false };

                return new RequestResponse { StatusCode = "200", Message = "Fetched successfully", IsSuccess = true, Data = entity };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = $"Error: {ex.Message}", IsSuccess = false };
            }
        }

        public async Task<RequestResponse> CreateAsync(ProjectContractTypeEntity entity, int userId, string language)
        {
            try
            {
                var created = await _repository.CreateAsync(entity, userId, language);
                return new RequestResponse { StatusCode = "201", Message = "Created successfully", IsSuccess = true, Data = created };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = $"Error: {ex.Message}", IsSuccess = false };
            }
        }

        public async Task<RequestResponse> CreateBulkAsync(IEnumerable<ProjectContractTypeEntity> entities, int userId, string language)
        {
            try
            {
                var count = await _repository.CreateBulkAsync(entities, userId, language);
                return new RequestResponse { StatusCode = "201", Message = $"{count} records created", IsSuccess = true, Data = count };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = $"Error: {ex.Message}", IsSuccess = false };
            }
        }

        public async Task<RequestResponse> UpdateAsync(ProjectContractTypeEntity entity, int userId, string language)
        {
            try
            {
                var success = await _repository.UpdateAsync(entity, userId, language);
                if (!success) return new RequestResponse { StatusCode = "400", Message = "Update failed", IsSuccess = false };

                return new RequestResponse { StatusCode = "200", Message = "Updated successfully", IsSuccess = true, Data = entity };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = $"Error: {ex.Message}", IsSuccess = false };
            }
        }

        public async Task<RequestResponse> DeleteAsync(long id, int userId, string language)
        {
            try
            {
                var deleted = await _repository.DeleteAsync(id, userId, language);
                if (!deleted) return new RequestResponse { StatusCode = "404", Message = "Not found", IsSuccess = false };

                return new RequestResponse { StatusCode = "200", Message = "Deleted successfully", IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = $"Error: {ex.Message}", IsSuccess = false };
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
                return new RequestResponse { StatusCode = "500", Message = $"Error: {ex.Message}", IsSuccess = false };
            }
        }

        public async Task<RequestResponse> GetAllGalleryAsync()
        {
            try
            {
                var data = await _repository.GetAllGalleryAsync();
                return new RequestResponse { StatusCode = "200", Message = "Gallery data retrieved", IsSuccess = true, Data = data };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = $"Error: {ex.Message}", IsSuccess = false };
            }
        }

        public async Task<RequestResponse> GetAllAuditsAsync(long projectContractTypeId)
        {
            try
            {
                var audits = await _repository.GetAllAuditsAsync(projectContractTypeId);
                return new RequestResponse { StatusCode = "200", Message = "Audit data retrieved", IsSuccess = true, Data = audits };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = $"Error: {ex.Message}", IsSuccess = false };
            }
        }
    }
}
