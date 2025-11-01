using RAP.Administrator.Application.DTOs.CertificateDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Repositories;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.Certificate;

namespace RAP.Administrator.Infrastructure.Services
{
    public class CertificateService : ICertificateService
    {
        private readonly ICertificateRepository _certificateRepository;

        public CertificateService(ICertificateRepository certificateRepository)
        {
            _certificateRepository = certificateRepository;
        }

        public async Task<RequestResponse> GetAllAsync(string language, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var (data, totalCount) = await _certificateRepository.GetAllAsync(language, pageNumber, pageSize);
                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Certificate list fetched successfully",
                    IsSuccess = true,
                    Data = new PagedCertificateResponse
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
                    Message = $"Error fetching certificates: {ex.Message}",
                    IsSuccess = false
                };
            }
        }

        public async Task<RequestResponse> GetByIdAsync(int id)
        {
            try
            {
                var certificate = await _certificateRepository.GetByIdAsync(id);
                if (certificate == null)
                    return new RequestResponse { StatusCode = "404", Message = "Certificate not found", IsSuccess = false };

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Certificate retrieved successfully",
                    IsSuccess = true,
                    Data = certificate
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = $"Error fetching certificate: {ex.Message}", IsSuccess = false };
            }
        }

        public async Task<RequestResponse> CreateAsync(CertificateEntity entity, int userId, string language)
        {
            try
            {
                var created = await _certificateRepository.CreateAsync(entity, userId, language);
                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = "Certificate created successfully",
                    IsSuccess = true,
                    Data = created
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = $"Error creating certificate: {ex.Message}", IsSuccess = false };
            }
        }

        public async Task<RequestResponse> CreateBulkAsync(IEnumerable<CertificateEntity> entities, int userId, string language)
        {
            try
            {
                var count = await _certificateRepository.CreateBulkAsync(entities, userId, language);
                return new RequestResponse
                {
                    StatusCode = "201",
                    Message = $"{count} certificates created successfully",
                    IsSuccess = true,
                    Data = count
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = $"Error creating bulk certificates: {ex.Message}", IsSuccess = false };
            }
        }

        public async Task<RequestResponse> UpdateAsync(CertificateEntity entity, int userId, string language)
        {
            try
            {
                var success = await _certificateRepository.UpdateAsync(entity, userId, language);
                if (!success)
                    return new RequestResponse { StatusCode = "400", Message = "Update failed or certificate not found", IsSuccess = false };

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Certificate updated successfully",
                    IsSuccess = true,
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = $"Error updating certificate: {ex.Message}", IsSuccess = false };
            }
        }

        public async Task<RequestResponse> DeleteAsync(int id, int userId, string language)
        {
            try
            {
                var deleted = await _certificateRepository.DeleteAsync(id, userId, language);
                if (!deleted)
                    return new RequestResponse { StatusCode = "404", Message = "Certificate not found or already deleted", IsSuccess = false };

                return new RequestResponse
                {
                    StatusCode = "200",
                    Message = "Certificate deleted successfully",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = $"Error deleting certificate: {ex.Message}", IsSuccess = false };
            }
        }

        public async Task<RequestResponse> GetTemplateDataAsync()
        {
            try
            {
                var data = await _certificateRepository.GetTemplateDataAsync();
                return new RequestResponse { StatusCode = "200", Message = "Template data retrieved successfully", IsSuccess = true, Data = data };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = $"Error retrieving template data: {ex.Message}", IsSuccess = false };
            }
        }

        public async Task<RequestResponse> GetAllGalleryAsync()
        {
            try
            {
                var data = await _certificateRepository.GetAllGalleryAsync();
                return new RequestResponse { StatusCode = "200", Message = "Gallery data retrieved successfully", IsSuccess = true, Data = data };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = $"Error retrieving gallery data: {ex.Message}", IsSuccess = false };
            }
        }

        public async Task<RequestResponse> GetAllAuditsAsync(int certificateId)
        {
            try
            {
                var audits = await _certificateRepository.GetAllAuditsAsync(certificateId);
                return new RequestResponse { StatusCode = "200", Message = "Audit data retrieved successfully", IsSuccess = true, Data = audits };
            }
            catch (Exception ex)
            {
                return new RequestResponse { StatusCode = "500", Message = $"Error retrieving audit data: {ex.Message}", IsSuccess = false };
            }
        }
    }
}
