using RAP.Administrator.Application.DTOs.LoanDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.Loan;


namespace RAP.Administrator.Infrastructure.Services
{
    public class LoansService : ILoansService
    {
        private readonly ILoanRepository _loanRepository;

        public LoansService(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var (data, totalCount) = await _loanRepository.GetAllAsync(language, pageNumber, pageSize);
                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Loan list fetched successfully",
                    IsSuccess = true,
                    Data = new PagedLoansResponse
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
                    Message = $"Error fetching loan list: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> GetByIdAsync(int id)
        {
            try
            {
                var loan = await _loanRepository.GetByIdAsync(id);
                if (loan == null)
                    return new RequestResponse
                    {
                        StatusCode = "404",
                        Message = "Loan not found",
                        IsSuccess = false
                    };

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Loan retrieved successfully",
                    IsSuccess = true,
                    Data = loan
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error fetching loan: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> CreateAsync(LoanEntity entity, int userId, string language)
        {
            try
            {
                var created = await _loanRepository.CreateAsync(entity, userId, language);
                await _loanRepository.GetAllAuditsAsync(created.Id);

                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = "Loan created successfully",
                    IsSuccess = true,
                    Data = created
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error creating loan: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> CreateBulkAsync(IEnumerable<LoanEntity> entities, int userId, string language)
        {
            try
            {
                var count = await _loanRepository.CreateBulkAsync(entities, userId, language);
                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = $"{count} loans created successfully",
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

        public async Task<RequestResponse> UpdateAsync(LoanEntity entity, int userId, string language)
        {
            try
            {
                var success = await _loanRepository.UpdateAsync(entity, userId, language);
                if (!success)
                    return new RequestResponse
                    {
                        StatusCode = "400",
                        Message = "Update failed or loan not found",
                        IsSuccess = false
                    };

                await _loanRepository.GetAllAuditsAsync(entity.Id);
                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Loan updated successfully",
                    IsSuccess = true,
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error updating loan: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> DeleteAsync(int id, int userId, string language)
        {
            try
            {
                var deleted = await _loanRepository.DeleteAsync(id, userId, language);
                if (!deleted)
                    return new RequestResponse
                    {
                        StatusCode = "404",
                        Message = "Loan not found or already deleted",
                        IsSuccess = false
                    };

                await _loanRepository.GetAllAuditsAsync(id);
                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Loan deleted successfully",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error deleting loan: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> GetTemplateDataAsync()
        {
            try
            {
                var data = await _loanRepository.GetTemplateDataAsync();
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
                var data = await _loanRepository.GetAllGalleryAsync();
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

        public async Task<RequestResponse> GetAllAuditsAsync(int loanId)
        {
            try
            {
                var audits = await _loanRepository.GetAllAuditsAsync(loanId);
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
