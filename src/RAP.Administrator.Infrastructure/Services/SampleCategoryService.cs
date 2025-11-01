using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Application.DTOs.SampleCategoryDTOs;
using RAP.Administrator.Domain.Models.SampleCategory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Services
{
    public class SampleCategoryService : ISampleCategoryService
    {
        private readonly ISampleCategoryRepository _sampleCategoryRepository;

        public SampleCategoryService(ISampleCategoryRepository sampleCategoryRepository)
        {
            _sampleCategoryRepository = sampleCategoryRepository;
        }

      
        public async Task<RequestResponse> GetAllAsync(string language, int skip = 0, int take = 10)
        {
            try
            {
                var (data, totalCount) = await _sampleCategoryRepository.GetAllAsync(language, skip, take);
                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Sample category list fetched successfully",
                    IsSuccess = true,
                    Data = new PagedSampleCategoryResponse
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
                    Message = $"Error fetching sample category list: {ex.Message}",
                    IsSuccess = false
                };
            }
        }



        public async Task<RequestResponse> GetByIdAsync(int id)
        {
            try
            {
                var category = await _sampleCategoryRepository.GetByIdAsync(id);
                if (category == null)
                {
                    return new RequestResponse
                    {
                        StatusCode = "404",
                        Message = "Sample category not found",
                        IsSuccess = false
                    };
                }

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Sample category retrieved successfully",
                    IsSuccess = true,
                    Data = category
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error fetching sample category: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> CreateAsync(SampleCategoryEntity entity, int userId, string language)
        {
            try
            {
                var created = await _sampleCategoryRepository.CreateAsync(entity, userId, language);

                var audit = new SampleCategoryAudit
                {
                    CategoryId = created.Id,
                    ActionUserAt = DateTime.UtcNow,
                    ActionUserId = userId,
                    ActionTypeId = created.ActionTypeId,
                   
                };
                await _sampleCategoryRepository.GetAllAuditsAsync(created.Id);

                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = "Sample category created successfully",
                    IsSuccess = true,
                    Data = created
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error creating sample category: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> CreateBulkAsync(IEnumerable<SampleCategoryEntity> entities, int userId, string language)
        {
            try
            {
                var count = await _sampleCategoryRepository.CreateBulkAsync(entities, userId, language);
                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = $"{count} sample categories created successfully",
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

        public async Task<RequestResponse> UpdateAsync(SampleCategoryEntity entity, int userId, string language)
        {
            try
            {
                var success = await _sampleCategoryRepository.UpdateAsync(entity, userId, language);

                if (!success)
                {
                    return new RequestResponse
                    {
                        StatusCode = "400",
                        Message = "Update failed or sample category not found",
                        IsSuccess = false
                    };
                }

                var audit = new SampleCategoryAudit
                {
                    CategoryId = entity.Id,
                    ActionUserAt = DateTime.UtcNow,
                    ActionUserId = userId,
                    ActionTypeId = entity.ActionTypeId,
                   
                };
                await _sampleCategoryRepository.GetAllAuditsAsync(entity.Id);

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Sample category updated successfully",
                    IsSuccess = true,
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error updating sample category: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> DeleteAsync(int id, int userId, string language)
        {
            try
            {
                var deleted = await _sampleCategoryRepository.DeleteAsync(id, userId, language);

                if (!deleted)
                {
                    return new RequestResponse
                    {
                        StatusCode = "404",
                        Message = "Sample category not found or already deleted",
                        IsSuccess = false
                    };
                }

                var audit = new SampleCategoryAudit
                {
                    CategoryId = id,
                    ActionUserAt = DateTime.UtcNow,
                    ActionUserId = userId,
                    ActionTypeId = id
                };
                await _sampleCategoryRepository.GetAllAuditsAsync(id);

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Sample category deleted successfully",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error deleting sample category: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> GetTemplateDataAsync()
        {
            try
            {
                var data = await _sampleCategoryRepository.GetTemplateDataAsync();
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
               // var data = await _sampleCategoryRepository.GetAllGalleryAsync();
                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Gallery data retrieved successfully",
                    IsSuccess = true,
                   // Data = data
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

        public async Task<RequestResponse> GetAllAuditsAsync(int sampleCategoryId)
        {
            try
            {
                var audits = await _sampleCategoryRepository.GetAllAuditsAsync(sampleCategoryId);
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
