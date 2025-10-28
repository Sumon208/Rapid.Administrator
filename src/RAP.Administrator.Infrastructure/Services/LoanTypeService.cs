using RAP.Administrator.Application.DTOs.DivisionDTOs;
using RAP.Administrator.Application.DTOs.LoanTypesDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.LoanType;

namespace RAP.Administrator.Infrastructure.Services
{
    public class LoanTypeService : ILoanTypeService
    {
        private readonly ILoanTypeRepository _loanTypeRepository;

        public LoanTypeService(ILoanTypeRepository loanTypeRepository)
        {
            _loanTypeRepository = loanTypeRepository;
        }

        public async Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var (data, totalCount) = await _loanTypeRepository.GetAllAsync(language, pageNumber, pageSize);
                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "LoanType list fetched successfully",
                    IsSuccess = true,
                   
                    Data = new PagedLoanTypeResponse
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
                    Message = $"Error fetching LoanType list: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> GetByIdAsync(long id)
        {
            try
            {
                var loanType = await _loanTypeRepository.GetByIdAsync(id);
                if (loanType == null)
                    return new RequestResponse
                    {
                        StatusCode = "404",
                        Message = "LoanType not found",
                        IsSuccess = false
                    };

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "LoanType retrieved successfully",
                    IsSuccess = true,
                    Data = loanType
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error fetching LoanType: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> CreateAsync(LoanTypeEntity entity, int userId, string language)
        {
            try
            {
                var created = await _loanTypeRepository.CreateAsync(entity, userId, language);
                await _loanTypeRepository.GetAllAuditsAsync(created.Id);

                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = "LoanType created successfully",
                    IsSuccess = true,
                    Data = created
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error creating LoanType: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> CreateBulkAsync(IEnumerable<LoanTypeEntity> entities, int userId, string language)
        {
            try
            {
                var count = await _loanTypeRepository.CreateBulkAsync(entities, userId, language);
                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = $"{count} LoanTypes created successfully",
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

        public async Task<RequestResponse> UpdateAsync(LoanTypeEntity entity, int userId, string language)
        {
            try
            {
                var success = await _loanTypeRepository.UpdateAsync(entity, userId, language);
                if (!success)
                    return new RequestResponse
                    {
                        StatusCode = "400",
                        Message = "Update failed or LoanType not found",
                        IsSuccess = false
                    };

                await _loanTypeRepository.GetAllAuditsAsync(entity.Id);

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "LoanType updated successfully",
                    IsSuccess = true,
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error updating LoanType: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> DeleteAsync(long id, int userId, string language)
        {
            try
            {
                var deleted = await _loanTypeRepository.DeleteAsync(id, userId, language);
                if (!deleted)
                    return new RequestResponse
                    {
                        StatusCode = "404",
                        Message = "LoanType not found or already deleted",
                        IsSuccess = false
                    };

                await _loanTypeRepository.GetAllAuditsAsync(id);

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "LoanType deleted successfully",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error deleting LoanType: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> GetTemplateDataAsync()
        {
            try
            {
                var data = await _loanTypeRepository.GetTemplateDataAsync();
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
                var data = await _loanTypeRepository.GetAllGalleryAsync();
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

        public async Task<RequestResponse> GetAllAuditsAsync(long loanTypeId)
        {
            try
            {
                var audits = await _loanTypeRepository.GetAllAuditsAsync(loanTypeId);
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
