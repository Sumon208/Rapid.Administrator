using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.DTOs.TransferDTOs;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _transferRepository;

        public TransferService(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }

        public async Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var (data, totalCount) = await _transferRepository.GetAllAsync(language, pageNumber, pageSize);

                var pagedResponse = new PagedTransferResponse
                {
                    TotalCount = totalCount,
                    Data = data
                };

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Transfer list fetched successfully",
                    IsSuccess = true,
                    Data = pagedResponse
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error fetching transfer list: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> GetByIdAsync(int id)
        {
            try
            {
                var transfer = await _transferRepository.GetByIdAsync(id);
                if (transfer == null)
                {
                    return new RequestResponse
                    {
                        StatusCode = "404",
                        Message = "Transfer not found",
                        IsSuccess = false
                    };
                }

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Transfer retrieved successfully",
                    IsSuccess = true,
                    Data = transfer
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error fetching transfer: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> CreateAsync(TransferEntity entity, int userId, string language)
        {
            try
            {
                var created = await _transferRepository.CreateAsync(entity, userId, language);
                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = "Transfer created successfully",
                    IsSuccess = true,
                    Data = created
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error creating transfer: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> CreateBulkAsync(IEnumerable<TransferEntity> entities, int userId, string language)
        {
            try
            {
                var count = await _transferRepository.CreateBulkAsync(entities, userId, language);
                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = $"{count} transfers created successfully",
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

        public async Task<RequestResponse> UpdateAsync(TransferEntity entity, int userId, string language)
        {
            try
            {
                var success = await _transferRepository.UpdateAsync(entity, userId, language);

                if (!success)
                {
                    return new RequestResponse
                    {
                        StatusCode = "400",
                        Message = "Update failed or transfer not found",
                        IsSuccess = false
                    };
                }

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Transfer updated successfully",
                    IsSuccess = true,
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error updating transfer: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> DeleteAsync(int id, int userId, string language)
        {
            try
            {
                var deleted = await _transferRepository.DeleteAsync(id, userId, language);
                if (!deleted)
                {
                    return new RequestResponse
                    {
                        StatusCode = "404",
                        Message = "Transfer not found or already deleted",
                        IsSuccess = false
                    };
                }

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Transfer deleted successfully",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error deleting transfer: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> GetTemplateDataAsync()
        {
            try
            {
                var data = await _transferRepository.GetTemplateDataAsync();
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
                var data = await _transferRepository.GetAllGalleryAsync();
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

        public async Task<RequestResponse> GetAllAuditsAsync(int transferId)
        {
            try
            {
                var audits = await _transferRepository.GetAllAuditsAsync(transferId);
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
