using RAP.Administrator.Application.DTOs.InsuranceDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.Insurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Services
{
    public class InsuranceService : IInsuranceService
    {
        private readonly IInsuranceRepository _insuranceRepository;

        public InsuranceService(IInsuranceRepository insuranceRepository)
        {
            _insuranceRepository = insuranceRepository;
        }

        public async Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var (data, totalCount) = await _insuranceRepository.GetAllAsync(language, pageNumber, pageSize);

                var pagedResponse = new PagedInsuranceResponse
                {
                    TotalCount = totalCount,
                    Data = data
                };

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Insurance list fetched successfully",
                    IsSuccess = true,
                    Data = pagedResponse   
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error fetching insurance list: {ex.Message}",
                    IsSuccess = false
                };
            }
        }


        public async Task<RequestResponse> GetByIdAsync(long id)
        {
            try
            {
                var insurance = await _insuranceRepository.GetByIdAsync(id);
                if (insurance == null)
                {
                    return new RequestResponse
                    {
                        StatusCode = "404",
                        Message = "Insurance not found",
                        IsSuccess = false
                    };
                }

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Insurance retrieved successfully",
                    IsSuccess = true,
                    Data = insurance
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error fetching insurance: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> CreateAsync(InsuranceEntity entity, int userId, string language)
        {
            try
            {
                var created = await _insuranceRepository.CreateAsync(entity, userId, language);
                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = "Insurance created successfully",
                    IsSuccess = true,
                    Data = created
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error creating insurance: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> CreateBulkAsync(IEnumerable<InsuranceEntity> entities, int userId, string language)
        {
            try
            {
                var count = await _insuranceRepository.CreateBulkAsync(entities, userId, language);
                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = $"{count} insurances created successfully",
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

        public async Task<RequestResponse> UpdateAsync(InsuranceEntity entity, int userId, string language)
        {
            try
            {
                var success = await _insuranceRepository.UpdateAsync(entity, userId, language);

                if (!success)
                {
                    return new RequestResponse
                    {
                        StatusCode = "400",
                        Message = "Update failed or insurance not found",
                        IsSuccess = false
                    };
                }

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Insurance updated successfully",
                    IsSuccess = true,
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error updating insurance: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> DeleteAsync(long id, int userId, string language)
        {
            try
            {
                var deleted = await _insuranceRepository.DeleteAsync(id, userId, language);
                if (!deleted)
                {
                    return new RequestResponse
                    {
                        StatusCode = "404",
                        Message = "Insurance not found or already deleted",
                        IsSuccess = false
                    };
                }

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Insurance deleted successfully",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error deleting insurance: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> GetTemplateDataAsync()
        {
            try
            {
                var data = await _insuranceRepository.GetTemplateDataAsync();
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
                var data = await _insuranceRepository.GetAllGalleryAsync();
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

        public async Task<RequestResponse> GetAllAuditsAsync(long insuranceId)
        {
            try
            {
                var audits = await _insuranceRepository.GetAllAuditsAsync(insuranceId);
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
