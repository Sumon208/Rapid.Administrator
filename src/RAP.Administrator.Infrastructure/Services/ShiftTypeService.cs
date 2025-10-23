using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models;
using RAP.Administrator.Application.DTOs.ShiftTypeDTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Services
{
    public class ShiftTypeService : IShiftTypeService
    {
        private readonly IShiftTypeRepository _shiftTypeRepository;

        public ShiftTypeService(IShiftTypeRepository shiftTypeRepository)
        {
            _shiftTypeRepository = shiftTypeRepository;
        }

        public async Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var (data, totalCount) = await _shiftTypeRepository.GetAllAsync(language, pageNumber, pageSize);
                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "ShiftType list fetched successfully",
                    IsSuccess = true,
                    Data = new PagedShiftTypeResponse
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
                    Message = $"Error fetching ShiftType list: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> GetByIdAsync(long id)
        {
            try
            {
                var shiftType = await _shiftTypeRepository.GetByIdAsync(id);
                if (shiftType == null)
                {
                    return new RequestResponse
                    {
                        StatusCode = "404",
                        Message = "ShiftType not found",
                        IsSuccess = false
                    };
                }

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "ShiftType retrieved successfully",
                    IsSuccess = true,
                    Data = shiftType
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error fetching ShiftType: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> CreateAsync(ShiftType entity, int userId, string language)
        {
            try
            {
                var created = await _shiftTypeRepository.CreateAsync(entity, userId, language);

                var audit = new ShiftTypeAudit
                {
                    ShiftTypeId = created.Id,
                    ActionAt = DateTime.UtcNow,
                    ActionUserId = userId,
                    ActionTypeName = "Create",
                    Name = created.Name,
                    Color = created.Color,
                    StartTime = created.StartTime,
                    EndTime = created.EndTime,
                    BreakTime = created.BreakTime,
                    Status = created.Status,
                    IsDefault = created.IsDefault
                };

               
                await _shiftTypeRepository.GetAllAuditsAsync(created.Id);

                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = "ShiftType created successfully",
                    IsSuccess = true,
                    Data = created
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error creating ShiftType: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> CreateBulkAsync(IEnumerable<ShiftType> entities, int userId, string language)
        {
            try
            {
                var count = await _shiftTypeRepository.CreateBulkAsync(entities, userId, language);
                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = $"{count} ShiftTypes created successfully",
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

        public async Task<RequestResponse> UpdateAsync(ShiftType entity, int userId, string language)
        {
            try
            {
                var success = await _shiftTypeRepository.UpdateAsync(entity, userId, language);

                if (!success)
                {
                    return new RequestResponse
                    {
                        StatusCode = "400",
                        Message = "Update failed or ShiftType not found",
                        IsSuccess = false
                    };
                }

                var audit = new ShiftTypeAudit
                {
                    ShiftTypeId = entity.Id,
                    ActionAt = DateTime.UtcNow,
                    ActionUserId = userId,
                    ActionTypeName = "Update",
                    Name = entity.Name,
                    Color = entity.Color,
                    StartTime = entity.StartTime,
                    EndTime = entity.EndTime,
                    BreakTime = entity.BreakTime,
                    Status = entity.Status,
                    IsDefault = entity.IsDefault
                };

              
                await _shiftTypeRepository.GetAllAuditsAsync(entity.Id);

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "ShiftType updated successfully",
                    IsSuccess = true,
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error updating ShiftType: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> DeleteAsync(long id, int userId, string language)
        {
            try
            {
                var deleted = await _shiftTypeRepository.DeleteAsync(id, userId, language);

                if (!deleted)
                {
                    return new RequestResponse
                    {
                        StatusCode = "404",
                        Message = "ShiftType not found or already deleted",
                        IsSuccess = false
                    };
                }

                var audit = new ShiftTypeAudit
                {
                    ShiftTypeId = id,
                    ActionAt = DateTime.UtcNow,
                    ActionUserId = userId,
                    ActionTypeName = "Delete"
                };

                // Matching DivisionService pattern: call GetAllAuditsAsync after creating audit object
                await _shiftTypeRepository.GetAllAuditsAsync(id);

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "ShiftType deleted successfully",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error deleting ShiftType: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> GetTemplateDataAsync()
        {
            try
            {
                var data = await _shiftTypeRepository.GetTemplateDataAsync();
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
                var data = await _shiftTypeRepository.GetAllGalleryAsync();
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

        public async Task<RequestResponse> GetAllAuditsAsync(long shiftTypeId)
        {
            try
            {
                var audits = await _shiftTypeRepository.GetAllAuditsAsync(shiftTypeId);
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
