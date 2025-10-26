using RAP.Administrator.Application.DTOs.CandidateListDTOs;
using RAP.Administrator.Application.DTOs.InsuranceDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.CandidateList;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAP.Administrator.Infrastructure.Services
{
    public class CandidateListService : ICandidateListService
    {
        private readonly ICandidateListRepository _candidateListRepository;

        public CandidateListService(ICandidateListRepository candidateListRepository)
        {
            _candidateListRepository = candidateListRepository;
        }

        public async Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var (data, totalCount) = await _candidateListRepository.GetAllAsync(language, pageNumber, pageSize);

                var pagedResponse = new PagedCandidatelistResponse
                {
                    TotalCount = totalCount,
                    Data = data
                };

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Candidate list fetched successfully",
                    IsSuccess = true,
                    Data = pagedResponse
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse
                {
                    StatusCode = "500",
                    Message = $"Error fetching candidate list: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> GetByIdAsync(long id)
        {
            try
            {
                var candidate = await _candidateListRepository.GetByIdAsync(id);
                if (candidate == null)
                {
                    return new RequestResponse
                    {
                        StatusCode = "404",
                        Message = "Candidate not found",
                        IsSuccess = false
                    };
                }

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

        public async Task<RequestResponse> CreateAsync(CandidateListEntity entity, int userId, string language)
        {
            try
            {
                var created = await _candidateListRepository.CreateAsync(entity, userId, language);
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

        public async Task<RequestResponse> CreateBulkAsync(IEnumerable<CandidateListEntity> entities, int userId, string language)
        {
            try
            {
                var count = await _candidateListRepository.CreateBulkAsync(entities, userId, language);
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
                    Message = $"Error in bulk create: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> UpdateAsync(CandidateListEntity entity, int userId, string language)
        {
            try
            {
                var success = await _candidateListRepository.UpdateAsync(entity, userId, language);
                if (!success)
                {
                    return new RequestResponse
                    {
                        StatusCode = "400",
                        Message = "Update failed or candidate not found",
                        IsSuccess = false
                    };
                }

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

        public async Task<RequestResponse> DeleteAsync(long id, int userId, string language)
        {
            try
            {
                var deleted = await _candidateListRepository.DeleteAsync(id, userId, language);

               
                if (!deleted)
                {
                    return new RequestResponse
                    {
                        StatusCode = "200", 
                        Message = "Candidate already deleted or not found.",
                        IsSuccess = true
                    };
                }

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Candidate deleted successfully.",
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

        public async Task<RequestResponse> GetTemplateDataAsync()
        {
            try
            {
                var data = await _candidateListRepository.GetTemplateDataAsync();
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
                var data = await _candidateListRepository.GetAllGalleryAsync();
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

        public async Task<RequestResponse> GetAllAuditsAsync(long candidateId)
        {
            try
            {
                var audits = await _candidateListRepository.GetAllAuditsAsync(candidateId);
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
