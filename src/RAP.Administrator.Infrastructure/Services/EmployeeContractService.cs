using RAP.Administrator.Application.DTOs.EmployeeContractDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.EmployeeContract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Services
{
    public class EmployeeContractService : IEmployeeContractService
    {
        private readonly IEmployeeContractRepository _repository;

        public EmployeeContractService(IEmployeeContractRepository repository)
        {
            _repository = repository;
        }

        public async Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var (data, totalCount) = await _repository.GetAllAsync(language, pageNumber, pageSize);

                var pagedResponse = new PagedEmployeeContractResponse
                {
                    TotalCount = totalCount,
                    Data = data
                };

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Employee contracts fetched successfully",
                    IsSuccess = true,
                    Data = pagedResponse
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error fetching contracts: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> GetByIdAsync(long id)
        {
            try
            {
                var contract = await _repository.GetByIdAsync(id);
                if (contract == null)
                    return new RequestResponse { StatusCode = "404", Message = "Contract not found", IsSuccess = false };

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Contract retrieved successfully",
                    IsSuccess = true,
                    Data = contract
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = $"Error fetching contract: {ex.Message}", IsSuccess = false };
            }
        }

        public async Task<RequestResponse> CreateAsync(EmployeeContractEntity entity, int userId, string language)
        {
            try
            {
                var created = await _repository.CreateAsync(entity, userId, language);
                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = "Contract created successfully",
                    IsSuccess = true,
                    Data = created
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = $"Error creating contract: {ex.Message}", IsSuccess = false };
            }
        }

        public async Task<RequestResponse> CreateBulkAsync(IEnumerable<EmployeeContractEntity> entities, int userId, string language)
        {
            try
            {
                var count = await _repository.CreateBulkAsync(entities, userId, language);
                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = $"{count} contracts created successfully",
                    IsSuccess = true,
                    Data = count
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = $"Error in bulk create: {ex.Message}", IsSuccess = false };
            }
        }

        public async Task<RequestResponse> UpdateAsync(EmployeeContractEntity entity, int userId, string language)
        {
            try
            {
                var success = await _repository.UpdateAsync(entity, userId, language);
                if (!success)
                    return new RequestResponse { StatusCode = "400", Message = "Update failed or contract not found", IsSuccess = false };

                return new RequestResponse { StatusCode = "200", Message = "Contract updated successfully", IsSuccess = true, Data = entity };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = $"Error updating contract: {ex.Message}", IsSuccess = false };
            }
        }

        public async Task<RequestResponse> DeleteAsync(long id, int userId, string language)
        {
            try
            {
                var deleted = await _repository.DeleteAsync(id, userId, language);
                if (!deleted)
                    return new RequestResponse { StatusCode = "404", Message = "Contract not found or already deleted", IsSuccess = false };

                return new RequestResponse { StatusCode = "200", Message = "Contract deleted successfully", IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = $"Error deleting contract: {ex.Message}", IsSuccess = false };
            }
        }

        public async Task<RequestResponse> GetTemplateDataAsync()
        {
            try
            {
                var data = await _repository.GetTemplateDataAsync();
                return new RequestResponse { StatusCode = "200", Message = "Template contracts retrieved successfully", IsSuccess = true, Data = data };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = $"Error retrieving template contracts: {ex.Message}", IsSuccess = false };
            }
        }

        public async Task<RequestResponse> GetAllAuditsAsync(long contractId)
        {
            try
            {
                var audits = await _repository.GetAllAuditsAsync(contractId);
                return new RequestResponse { StatusCode = "200", Message = "Audit data retrieved successfully", IsSuccess = true, Data = audits };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = $"Error retrieving audit data: {ex.Message}", IsSuccess = false };
            }
        }
    }
}
