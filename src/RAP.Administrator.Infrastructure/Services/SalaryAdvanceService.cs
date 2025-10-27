using RAP.Administrator.Application.DTOs.DivisionDTOs;
using RAP.Administrator.Application.DTOs.SalaryAdvanceDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.SalaryAdvance;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Services
{
    public class SalaryAdvanceService : ISalaryAdvanceService
    {
        private readonly ISalaryAdvanceRepository _repository;

        public SalaryAdvanceService(ISalaryAdvanceRepository repository)
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
                    Message = "SalaryAdvance list fetched successfully",
                    IsSuccess = true,
                    Data = new PagedSalaryAdvanceResponse
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
                    Message = ex.Message,
                    IsSuccess = false
                };
            }
        }


        public async Task<RequestResponse> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null) return new RequestResponse { StatusCode = "404", Message = "Not found", IsSuccess = false };

                return new RequestResponse { StatusCode = "200", Message = "Fetched successfully", IsSuccess = true, Data = entity };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = ex.Message, IsSuccess = false };
            }
        }

        public async Task<RequestResponse> CreateAsync(SalaryAdvanceEntity entity, int userId, string language)
        {
            try
            {
                var created = await _repository.CreateAsync(entity, userId);

                var audit = new SalaryAdvanceAudit
                {
                    SalaryAdvanceId = created.Id,
                    ActionUserId = userId,
                    ActionUserAt = DateTime.UtcNow,
                   
                };

                await _repository.GetAllAuditsAsync(created.Id);

                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = "Salary advance created successfully",
                    IsSuccess = true,
                    Data = created
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error creating salary advance: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> CreateBulkAsync(IEnumerable<SalaryAdvanceEntity> entities, int userId, string language)
        {
            try
            {
                var count = await _repository.CreateBulkAsync(entities, userId);

                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = $"{count} salary advances created successfully",
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

        public async Task<RequestResponse> UpdateAsync(SalaryAdvanceEntity entity, int userId, string language)
        {
            try
            {
                var success = await _repository.UpdateAsync(entity, userId);

                if (!success)
                {
                    return new RequestResponse
                    {
                        StatusCode = "400",
                        Message = "Update failed or salary advance not found",
                        IsSuccess = false
                    };
                }

                var audit = new SalaryAdvanceAudit
                {
                    SalaryAdvanceId = entity.Id,
                    ActionUserId = userId,
                    ActionUserAt = DateTime.UtcNow,
                    
                };

                await _repository.GetAllAuditsAsync(entity.Id);

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Salary advance updated successfully",
                    IsSuccess = true,
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error updating salary advance: {ex.Message}",
                    IsSuccess = false
                };
            }
        }


        public async Task<RequestResponse> DeleteAsync(int id, int userId)
        {
            try
            {
                var success = await _repository.DeleteAsync(id, userId);
                if (!success) return new RequestResponse { StatusCode = "404", Message = "Delete failed", IsSuccess = false };
                return new RequestResponse { StatusCode = "200", Message = "Deleted successfully", IsSuccess = true };
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
                return new RequestResponse { StatusCode = "200", Message = "Template data fetched", IsSuccess = true, Data = data };
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

        public async Task<RequestResponse> GetAllAuditsAsync(int salaryAdvanceId)
        {
            try
            {
                var audits = await _repository.GetAllAuditsAsync(salaryAdvanceId);
                return new RequestResponse { StatusCode = "200", Message = "Audits fetched", IsSuccess = true, Data = audits };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = ex.Message, IsSuccess = false };
            }
        }
    }
}
