using RAP.Administrator.Application.DTOs.BranchesDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.Branches;
using RAP.Administrator.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Services
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;

        public BranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var (data, totalCount) = await _branchRepository.GetAllAsync(language, pageNumber, pageSize);
                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Branch list fetched successfully",
                    IsSuccess = true,
                    Data = new PagedBranchResponse 
                    { 
                        Data = data,
                        TotalCount = totalCount 
                    
                    }
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = ex.Message, IsSuccess = false };
            }
        }

        public async Task<RequestResponse> GetByIdAsync(int id)
        {
            try
            {
                var branch = await _branchRepository.GetByIdAsync(id);
                if (branch == null)
                    return new RequestResponse { StatusCode = "404", Message = "Branch not found", IsSuccess = false };

                return new RequestResponse { StatusCode = "200", Message = "Branch retrieved successfully", IsSuccess = true, Data = branch };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = ex.Message, IsSuccess = false };
            }
        }

        public async Task<RequestResponse> CreateAsync(BranchEntity entity, int userId, string language)
        {
            try
            {
                var created = await _branchRepository.CreateAsync(entity, userId, language);
                return new RequestResponse { StatusCode = "201", Message = "Branch created successfully", IsSuccess = true, Data = created };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = ex.Message, IsSuccess = false };
            }
        }

        public async Task<RequestResponse> CreateBulkAsync(IEnumerable<BranchEntity> entities, int userId, string language)
        {
            try
            {
                var count = await _branchRepository.CreateBulkAsync(entities, userId, language);
                return new RequestResponse { StatusCode = "201", Message = $"{count} branches created successfully", IsSuccess = true, Data = count };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = ex.Message, IsSuccess = false };
            }
        }

        public async Task<RequestResponse> UpdateAsync(BranchEntity entity, int userId, string language)
        {
            try
            {
                var success = await _branchRepository.UpdateAsync(entity, userId, language);
                if (!success)
                    return new RequestResponse { StatusCode = "400", Message = "Update failed or branch not found", IsSuccess = false };

                return new RequestResponse { StatusCode = "200", Message = "Branch updated successfully", IsSuccess = true, Data = entity };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = ex.Message, IsSuccess = false };
            }
        }

        public async Task<RequestResponse> DeleteAsync(int id, int userId, string language)
        {
            try
            {
                var deleted = await _branchRepository.DeleteAsync(id, userId, language);
                if (!deleted)
                    return new RequestResponse { StatusCode = "404", Message = "Branch not found or already deleted", IsSuccess = false };

                return new RequestResponse { StatusCode = "200", Message = "Branch deleted successfully", IsSuccess = true };
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
                var data = await _branchRepository.GetTemplateDataAsync();
                return new RequestResponse { StatusCode = "200", Message = "Template data retrieved successfully", IsSuccess = true, Data = data };
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
                var data = await _branchRepository.GetAllGalleryAsync();
                return new RequestResponse { StatusCode = "200", Message = "Gallery retrieved successfully", IsSuccess = true, Data = data };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = ex.Message, IsSuccess = false };
            }
        }

        public async Task<RequestResponse> GetAllAuditsAsync(int branchId)
        {
            try
            {
                var audits = await _branchRepository.GetAllAuditsAsync(branchId);
                return new RequestResponse { StatusCode = "200", Message = "Audits retrieved successfully", IsSuccess = true, Data = audits };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = ex.Message, IsSuccess = false };
            }
        }
    }
}
