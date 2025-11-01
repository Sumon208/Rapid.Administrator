using Microsoft.AspNetCore.Mvc;
using RAP.Administrator.Application.DTOs.CertificateDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.Certificate;
using RAP.Administrator.Infrastructure.Services;

namespace RAP.Administrator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly ICertificateService _certificateService;

        public CertificateController(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] string language = "en", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _certificateService.GetAllAsync(language, pageNumber, pageSize);

            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var pagedData = response.Data as PagedCertificateResponse;
            if (pagedData == null)
                return StatusCode(500, "Invalid data format");

            var result = pagedData.Data.Select(c => new CertificateGetAllDTO
            {
                Id = c.Id,
                CertificateNumber = c.CertificateNumber,
                CertificateTypeId = c.CertificateTypeId,
                EmployeeId = c.EmployeeId,
                LabManager = c.LabManager,
                GeneralManager = c.GeneralManager,
                Date = c.Date,
                Description = c.Description,
                ActionTypeName = c.ActionTypeName,
                EmployeeName = c.Employee?.Name,
                Localizations = c.Localizations?.Select(l => new CertificateLocalizationDTO
                {
                    Id = l.Id,
                    CertificateId = l.CertificateId,
                    LanguageId = l.LanguageId,
                    Name = l.Name
                }).ToList()
            }).ToList();

            return Ok(new { TotalCount = pagedData.TotalCount, Data = result });
        }

        
        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle([FromQuery] int id)
        {
            var response = await _certificateService.GetByIdAsync(id);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var certificate = response.Data as CertificateEntity;
            if (certificate == null)
                return NotFound("Certificate not found");

            var dto = new CertificateGetAllDTO
            {
                Id = certificate.Id,
                CertificateNumber = certificate.CertificateNumber,
                CertificateTypeId = certificate.CertificateTypeId,
                EmployeeId = certificate.EmployeeId,
                LabManager = certificate.LabManager,
                GeneralManager = certificate.GeneralManager,
                Date = certificate.Date,
                Description = certificate.Description,
                ActionTypeName = certificate.ActionTypeName,
            
                EmployeeName = certificate.Employee?.Name,
                Localizations = certificate.Localizations?.Select(l => new CertificateLocalizationDTO
                {
                    Id = l.Id,
                    CertificateId = l.CertificateId,
                    LanguageId = l.LanguageId,
                    Name = l.Name
                }).ToList()
            };

            return Ok(dto);
        }

       
        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle([FromBody] CertificateCreateSingleDTO dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new CertificateEntity
            {
                CertificateNumber = dto.CertificateNumber,
                CertificateTypeId = dto.CertificateTypeId,
                EmployeeId = dto.EmployeeId,
                LabManager = dto.LabManager,
                GeneralManager = dto.GeneralManager,
                Date = dto.Date,
                Description = dto.Description,
                Localizations = dto.Localizations?.Select(l => new CertificateLocalizationEntity
                {
                    LanguageId = l.LanguageId,
                    Name = l.Name
                }).ToList()
            };

            var response = await _certificateService.CreateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, Id = ((CertificateEntity)response.Data).Id });
        }

     
        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk([FromBody] CertificateCreateBulkDTO dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            if (dto.Certificates == null || !dto.Certificates.Any())
                return BadRequest("No certificates provided.");

            var entities = dto.Certificates.Select(c => new CertificateEntity
            {
                CertificateNumber = c.CertificateNumber,
                CertificateTypeId = c.CertificateTypeId,
                EmployeeId = c.EmployeeId,
                LabManager = c.LabManager,
                GeneralManager = c.GeneralManager,
                Date = c.Date,
                Description = c.Description
            }).ToList();

            var response = await _certificateService.CreateBulkAsync(entities, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, CreatedCount = response.Data });
        }

      
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] CertificateUpdateDTO dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new CertificateEntity
            {
                Id = dto.Id,
                CertificateTypeId = dto.CertificateTypeId,
                EmployeeId = dto.EmployeeId,
                LabManager = dto.LabManager,
                GeneralManager = dto.GeneralManager,
                Date = dto.Date,
                Description = dto.Description,
                Localizations = dto.Localizations?.Select(l => new CertificateLocalizationEntity
                {
                    Id = l.Id,
                    CertificateId = dto.Id,
                    LanguageId = l.LanguageId,
                    Name = l.Name
                }).ToList()
            };

            var response = await _certificateService.UpdateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

       
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var response = await _certificateService.DeleteAsync(id, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpGet("GetAllTemplateData")]
        public async Task<IActionResult> GetAllTemplateData()
        {
            var response = await _certificateService.GetTemplateDataAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllGallery")]
        public async Task<IActionResult> GetAllGallery()
        {
            var response = await _certificateService.GetAllGalleryAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits([FromQuery] int certificateId)
        {
            var response = await _certificateService.GetAllAuditsAsync(certificateId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var audits = response.Data as IEnumerable<CertificateAuditEntity>;
            var result = audits?.Select(a => new CertificateAuditDTO
            {
                Id = a.Id,
                CertificateId = a.CertificateId,
                Code = a.Code,
                Dail = a.Dail,
                Name = a.Name,
                IsDefault = a.IsDefault,
                StatusId = a.StatusId,
                Browser = a.Browser,
                Location = a.Location,
                IP = a.IP,
                OS = a.OS,
                MapURL = a.MapURL,
                Latitude = a.Latitude,
             
                ActionTypeId = a.ActionTypeId,
                ActionUserId = a.ActionUserId,
                ActionUserAt = a.ActionUserAt
            });

            return Ok(result);
        }
    }
}
