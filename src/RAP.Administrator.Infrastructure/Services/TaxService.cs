using RAP.Administrator.Application.DTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.Tax;
using RAP.Administrator.Infrastructure.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Services
{
    public class TaxService : ITaxService
    {
        private readonly ITaxRepository _repository;

        public TaxService(ITaxRepository repository)
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
                    Message = "Tax list fetched successfully",
                    IsSuccess = true,
                    Data = new
                    {
                        Data = data.Select(d => new TaxListDto
                        {
                            Id = d.Id,
                            BankName = d.BankName,
                            AccountNumber = d.AccountNumber,
                            BranchName = d.BranchName,
                            OpeningBalance = d.OpeningBalance,
                            IsActive = d.IsActive,
                            CreatedDate = d.CreatedDate
                        }).ToList(),
                        TotalCount = totalCount
                    }
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error fetching tax list: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                    return new RequestResponse
                    {
                        StatusCode = "404",
                        Message = "Tax not found",
                        IsSuccess = false
                    };

                var dto = new TaxResponseDto
                {
                    Id = entity.Id,
                    BankName = entity.BankName,
                    AccountNumber = entity.AccountNumber,
                    BranchName = entity.BranchName,
                    IBANNumber = entity.IBANNumber,
                    OpeningBalance = entity.OpeningBalance,
                    Address = entity.Address,
                    BankDetails = entity.BankDetails,
                    IsDefault = entity.IsDefault,
                    IsActive = entity.IsActive,
                    IsDraft = entity.IsDraft,
                    IsDeleted = entity.IsDeleted,
                    CreatedDate = entity.CreatedDate,
                    UpdatedDate = entity.UpdatedDate,
                    DraftedDate = entity.DraftedDate,
                    DeletedDate = entity.DeletedDate,
                    Audits = entity.Audits?.Select(a => new TaxAuditEntity
                    {
                        Id = a.Id,
                        ActionUserId = a.ActionUserId,
                        ActionTypeId = a.ActionTypeId,
                        ActionUserAt = a.ActionUserAt,
                        IsDefault = a.IsDefault,
                        StatusId = a.StatusId
                    }).ToList()
                };

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Tax fetched successfully",
                    IsSuccess = true,
                    Data = dto
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error fetching tax: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> CreateAsync(TaxEntity entity, int userId, string language)
        {
            try
            {
                var created = await _repository.CreateAsync(entity, userId, language);

                var audit = new TaxAuditEntity
                {
                    Id = created.Id,
                    ActionUserId = userId,
                    ActionTypeId = 1, // Create
                    ActionUserAt = DateTime.UtcNow,
                    IsDefault = created.IsDefault,
                    StatusId = created.IsActive
                };
                await _repository.GetAllAuditsAsync(created.Id);

                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = "Tax created successfully",
                    IsSuccess = true,
                    Data = created
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error creating tax: {ex.Message}",
                    IsSuccess = false
                };
            }
        }


        public async Task<RequestResponse> CreateBulkAsync(IEnumerable<TaxEntity> entities, int userId, string language)
        {
            try
            {
                var count = await _repository.CreateBulkAsync(entities, userId, language);
                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = $"{count} Tax created successfully",
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

        public async Task<RequestResponse> UpdateAsync(TaxUpdateDto dto, int userId, string language)
        {
            try
            {
               
                var entity = new TaxEntity
                {
                    Id = dto.Id,
                    BankName = dto.BankName,
                    AccountNumber = dto.AccountNumber,
                    BranchName = dto.BranchName,
                    IBANNumber = dto.IBANNumber,
                    OpeningBalance = dto.OpeningBalance,
                    Address = dto.Address,
                    BankDetails = dto.BankDetails,
                    IsActive = dto.IsActive,
                    IsDefault = dto.IsDefault,
                    IsDraft = dto.IsDraft
                };

              
                var success = await _repository.UpdateAsync(entity, userId, language);

                if (!success)
                {
                    return new RequestResponse
                    {
                        StatusCode = "404",
                        Message = "Tax not found or update failed",
                        IsSuccess = false
                    };
                }

                await _repository.GetAllAuditsAsync(entity.Id);

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Tax updated successfully",
                    IsSuccess = true,
                    Data = dto
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error updating tax: {ex.Message}",
                    IsSuccess = false
                };
            }
        }



        public async Task<RequestResponse> DeleteAsync(int id, int userId, string language)
        {
            try
            {
                var deleted = await _repository.DeleteAsync(id, userId, language);

                if (!deleted)
                    return new RequestResponse
                    {
                        StatusCode = "404",
                        Message = "Tax not found or already deleted",
                        IsSuccess = false
                    };

                var audit = new TaxAuditEntity
                {
                    Id = id,
                    ActionUserId = userId,
                    ActionTypeId = 3, // Delete
                    ActionUserAt = DateTime.UtcNow
                };
                await _repository.GetAllAuditsAsync(id);

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Tax deleted successfully",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error deleting tax: {ex.Message}",
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

        public async Task<RequestResponse> GetAllAuditsAsync(int taxId)
        {
            try
            {
                var audits = await _repository.GetAllAuditsAsync(taxId);
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
