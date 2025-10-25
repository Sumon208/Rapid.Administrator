using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.CandidateSelection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<RequestResponse> GetAllAsync(int pageNumber = 1, int pageSize = 10, int? languageId = null)
        {
            try
            {
                var (data, totalCount) = await _candidateRepository.GetAllAsync(pageNumber, pageSize, languageId);

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Candidate list fetched successfully",
                    IsSuccess = true,
                    Data = new
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
                    Message = $"Error fetching candidates: {ex.Message}",
                    IsSuccess = false
                };
            }
        }


        public async Task<RequestResponse> GetByIdAsync(int id, int? languageId = null)
        {
            try
            {
                var candidate = await _candidateRepository.GetByIdAsync(id, languageId);
                if (candidate == null)
                    return new RequestResponse { StatusCode = "404", Message = "Candidate not found", IsSuccess = false };

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Candidate retrieved successfully",
                    IsSuccess = true,
                    Data = candidate
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error fetching candidate: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> CreateAsync(CandidateEntity entity, int userId)
        {
            try
            {
                var created = await _candidateRepository.CreateAsync(entity, userId);
                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = "Candidate created successfully",
                    IsSuccess = true,
                    Data = created
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error creating candidate: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> CreateBulkAsync(IEnumerable<CandidateEntity> entities, int userId)
        {
            try
            {
                var count = await _candidateRepository.CreateBulkAsync(entities, userId);
                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = $"{count} candidates created successfully",
                    IsSuccess = true,
                    Data = count
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error creating candidates in bulk: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> UpdateAsync(CandidateEntity entity, int userId)
        {
            try
            {
                var success = await _candidateRepository.UpdateAsync(entity, userId);
                if (!success)
                    return new RequestResponse { StatusCode = "400", Message = "Update failed or candidate not found", IsSuccess = false };

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Candidate updated successfully",
                    IsSuccess = true,
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error updating candidate: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> DeleteAsync(int id, int userId)
        {
            try
            {
                var deleted = await _candidateRepository.DeleteAsync(id, userId);
                if (!deleted)
                    return new RequestResponse { StatusCode = "404", Message = "Candidate not found or already deleted", IsSuccess = false };

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Candidate deleted successfully",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error deleting candidate: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> GetTemplateDataAsync(int? languageId = null)
        {
            try
            {
                var data = await _candidateRepository.GetTemplateDataAsync(languageId);
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
                var data = await _candidateRepository.GetAllGalleryAsync();
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

        public async Task<RequestResponse> GetAllAuditsAsync(int candidateId)
        {
            try
            {
                var audits = await _candidateRepository.GetAllAuditsAsync(candidateId);
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
