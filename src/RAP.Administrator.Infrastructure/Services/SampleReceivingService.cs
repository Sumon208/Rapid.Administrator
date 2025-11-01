using RAP.Administrator.Application.DTOs.DivisionDTOs;
using RAP.Administrator.Application.DTOs.SampleReceivingDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.Divisions;
using RAP.Administrator.Domain.Models.SampleReceiving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Services
{
    public class SampleReceivingService: ISampleReceivingService
    {
        private readonly ISampleReceivingRepository _sampleReceivingRepo;

        public SampleReceivingService(ISampleReceivingRepository sampleReceivingRepo)
        {
            _sampleReceivingRepo = sampleReceivingRepo;
        }


        public async Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var (data, totalCount) = await _sampleReceivingRepo.GetAllAsync(language, pageNumber, pageSize);
                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Sample Received list fetched successfully",
                    IsSuccess = true,
                    Data = new PaginatedSampleReceivingListDTO
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


        public async Task<RequestResponse> GetByIdAsync(int id)
        {
            try
            {
                var division = await _sampleReceivingRepo.GetByIdAsync(id);
                if (division == null)
                {
                    return new RequestResponse
                    {
                        StatusCode = "404",
                        Message = "Sample Received not found",
                        IsSuccess = false
                    };
                }

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Sample Received retrieved successfully",
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


        public async Task<RequestResponse> CreateAsync(SampleReceivingEntity entity, int userId, string language)
        {
            try
            {
                var created = await _sampleReceivingRepo.CreateAsync(entity, userId, language);

                var audit = new SampleReceivedAuditEntity
                {
                    ReceivedId = created.Id,
                    ActionUserAt=DateTime.Now,
                    ActionUserId = userId,
                    ActionTypeId = created.Id
                   
                };
                await _sampleReceivingRepo.GetAllAuditsAsync(created.Id);

                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = "Sample Received created successfully",
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

        public async Task<RequestResponse> CreateBulkAsync(IEnumerable<SampleReceivingEntity> entities, int userId, string language)
        {
            try
            {
                var count = await _sampleReceivingRepo.CreateBulkAsync(entities, userId, language);
                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = $"{count} Sample Received created successfully",
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

        public async Task<RequestResponse> UpdateAsync(SampleReceivingEntity entity, int userId, string language)
        {
            try
            {
                var success = await _sampleReceivingRepo.UpdateAsync(entity, userId, language);

                if (!success)
                {
                    return new RequestResponse
                    {
                        StatusCode = "400",
                        Message = "Update failed or Sample Received not found",
                        IsSuccess = false
                    };
                }

                var audit = new SampleReceivedAuditEntity
                {
                    ReceivedId = entity.Id,
                    ActionUserAt = DateTime.Now,
                    ActionUserId = userId,
                    ActionTypeId = entity.Id

                };
                await _sampleReceivingRepo.GetAllAuditsAsync(entity.Id);

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "SampleReceiving updated successfully",
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


        public async Task<RequestResponse> DeleteAsync(int id, int userId, string language)
        {
            try
            {
                var deleted = await _sampleReceivingRepo.DeleteAsync(id, userId, language);

                if (!deleted)
                {
                    return new RequestResponse
                    {
                        StatusCode = "404",
                        Message = "SampleReceiving not found or already deleted",
                        IsSuccess = false
                    };
                }

                var audit = new SampleReceivedAuditEntity
                {
                    ReceivedId = id,
                    ActionUserAt = DateTime.UtcNow,
                    ActionUserId = userId,
                    ActionTypeId=id
                };
                await _sampleReceivingRepo.GetAllAuditsAsync(id);

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
                var data = await _sampleReceivingRepo.GetTemplateDataAsync();
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
                var data = await _sampleReceivingRepo.GetAllGalleryAsync();
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


        public async Task<RequestResponse> GetAllAuditsAsync(int sampleRId)
        {
            try
            {
                var audits = await _sampleReceivingRepo.GetAllAuditsAsync(sampleRId);
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
