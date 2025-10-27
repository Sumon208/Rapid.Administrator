using RAP.Administrator.Application.DTOs.JobLocationDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.JobLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Services
{
    public class JobLocationService : IJobLocationService
    {
        private readonly IJobLocationRepository _repository;

        public JobLocationService(IJobLocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var (data, totalCount) = await _repository.GetAllAsync(language, pageNumber, pageSize);

                var pagedResponse = new PagedJobLocationsResponse
                {
                    TotalCount = totalCount,
                    Data = data
                };

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Job Location list fetched successfully",
                    IsSuccess = true,
                    Data = pagedResponse
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error fetching job location list: {ex.Message}",
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
                    return new RequestResponse
                    {
                        StatusCode = "404",
                        Message = "Job Location not found",
                        IsSuccess = false
                    };

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Job Location retrieved successfully",
                    IsSuccess = true,
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error fetching job location: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> CreateAsync(JobLocationEntity entity, int userId, string language)
        {
            try
            {
                var created = await _repository.CreateAsync(entity, userId, language);
                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = "Job Location created successfully",
                    IsSuccess = true,
                    Data = created
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error creating job location: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> CreateBulkAsync(IEnumerable<JobLocationEntity> entities, int userId, string language)
        {
            try
            {
                var count = await _repository.CreateBulkAsync(entities, userId, language);
                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = $"{count} job locations created successfully",
                    IsSuccess = true,
                    Data = count
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error in bulk create: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> UpdateAsync(JobLocationEntity entity, int userId, string language)
        {
            try
            {
                var success = await _repository.UpdateAsync(entity, userId, language);
                if (!success)
                    return new RequestResponse
                    {
                        StatusCode = "400",
                        Message = "Update failed or job location not found",
                        IsSuccess = false
                    };

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Job Location updated successfully",
                    IsSuccess = true,
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error updating job location: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> DeleteAsync(long id, int userId, string language)
        {
            try
            {
                var deleted = await _repository.DeleteAsync(id, userId, language);
                if (!deleted)
                    return new RequestResponse
                    {
                        StatusCode = "404",
                        Message = "Job Location not found or already deleted",
                        IsSuccess = false
                    };

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Job Location deleted successfully",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error deleting job location: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> GetTemplateDataAsync()
        {
            try
            {
                var data = await _repository.GetTemplateDataAsync();
                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Template data retrieved successfully",
                    IsSuccess = true,
                    Data = data
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error retrieving template data: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> GetAllGalleryAsync()
        {
            try
            {
                var data = await _repository.GetAllGalleryAsync();
                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Gallery data retrieved successfully",
                    IsSuccess = true,
                    Data = data
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error retrieving gallery data: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> GetAllAuditsAsync(long jobLocationId)
        {
            try
            {
                var audits = await _repository.GetAllAuditsAsync(jobLocationId);
                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Audit data retrieved successfully",
                    IsSuccess = true,
                    Data = audits
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error retrieving audit data: {ex.Message}",
                    IsSuccess = false
                };
            }
        }
    }
}
