using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models;
using RAP.Administrator.Application.DTOs.Shared; 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RAP.Administrator.Application.DTOs.DivisionDTOs;

namespace RAP.Administrator.Infrastructure.Services
{
    public class DivisionService :IDivisionService
    {
        private readonly IDivisionRepository _divisionRepository;

        public DivisionService(IDivisionRepository divisionRepository)
        {
            _divisionRepository = divisionRepository;
        }


        public async Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var (data, totalCount) = await _divisionRepository.GetAllAsync(language, pageNumber, pageSize);
                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Division list fetched successfully",
                    IsSuccess = true,
                    Data = new PagedDivisionResponse
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
                    Message = $"Error fetching division list: {ex.Message}",
                    IsSuccess = false
                };
            }
        }


        public async Task<RequestResponse> GetByIdAsync(long id)
        {
            try
            {
                var division = await _divisionRepository.GetByIdAsync(id);
                if (division == null)
                {
                    return new RequestResponse
                    {
                        StatusCode = "404",
                        Message = "Division not found",
                        IsSuccess = false
                    };
                }

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Division retrieved successfully",
                    IsSuccess = true,
                    Data = division
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error fetching division: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

  
        public async Task<RequestResponse> CreateAsync(Division entity, int userId, string language)
        {
            try
            {
                var created = await _divisionRepository.CreateAsync(entity, userId, language);

                var audit = new DivisionAudit
                {
                    DivisionId = created.Id,
                    ActionAt = DateTime.UtcNow,
                    ActionUserId = userId,
                    ActionTypeName = "Create",
                    IsDefault = created.IsDefault,
                    StatusTypeId = created.StatusTypeId
                };
                await _divisionRepository.GetAllAuditsAsync(created.Id);

                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = "Division created successfully",
                    IsSuccess = true,
                    Data = created
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error creating division: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> CreateBulkAsync(IEnumerable<Division> entities, int userId, string language)
        {
            try
            {
                var count = await _divisionRepository.CreateBulkAsync(entities, userId, language);
                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = $"{count} divisions created successfully",
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

        public async Task<RequestResponse> UpdateAsync(Division entity, int userId, string language)
        {
            try
            {
                var success = await _divisionRepository.UpdateAsync(entity, userId, language);

                if (!success)
                {
                    return new RequestResponse
                    {
                        StatusCode = "400",
                        Message = "Update failed or division not found",
                        IsSuccess = false
                    };
                }

                var audit = new DivisionAudit
                {
                    DivisionId = entity.Id,
                    ActionAt = DateTime.UtcNow,
                    ActionUserId = userId,
                    ActionTypeName = "Update",
                    IsDefault = entity.IsDefault,
                    StatusTypeId = entity.StatusTypeId
                };
                await _divisionRepository.GetAllAuditsAsync(entity.Id);

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Division updated successfully",
                    IsSuccess = true,
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error updating division: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        
        public async Task<RequestResponse> DeleteAsync(long id, int userId, string language)
        {
            try
            {
                var deleted = await _divisionRepository.DeleteAsync(id, userId, language);

                if (!deleted)
                {
                    return new RequestResponse
                    {
                        StatusCode = "404",
                        Message = "Division not found or already deleted",
                        IsSuccess = false
                    };
                }

                var audit = new DivisionAudit
                {
                    DivisionId = id,
                    ActionAt = DateTime.UtcNow,
                    ActionUserId = userId,
                    ActionTypeName = "Delete"
                };
                await _divisionRepository.GetAllAuditsAsync(id);

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Division deleted successfully",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error deleting division: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

      
        public async Task<RequestResponse> GetTemplateDataAsync()
        {
            try
            {
                var data = await _divisionRepository.GetTemplateDataAsync();
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
                var data = await _divisionRepository.GetAllGalleryAsync();
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

      
        public async Task<RequestResponse> GetAllAuditsAsync(long divisionId)
        {
            try
            {
                var audits = await _divisionRepository.GetAllAuditsAsync(divisionId);
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
