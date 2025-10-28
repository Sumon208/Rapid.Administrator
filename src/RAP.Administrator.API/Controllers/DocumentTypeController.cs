using Microsoft.AspNetCore.Mvc;
using RAP.Administrator.Application.DTOs.DocumentTypeDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.DocumentType;

namespace RAP.Administrator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocumentTypeService _documentTypeService;

        public DocumentTypeController(IDocumentTypeService documentTypeService)
        {
            _documentTypeService = documentTypeService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] string language = "en", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _documentTypeService.GetAllAsync(language, pageNumber, pageSize);

            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var pagedData = response.Data as PagedDocumentTypeResponse;
            if (pagedData == null)
                return StatusCode(500, "Invalid data format");

            var result = pagedData.Data.Select(d => new DocumentTypeDto
            {
                Id = d.Id,
                TemplateId = d.TemplateId,
               
                Name = d.Name,
                IsDefault = d.IsDefault,
                StatusId = d.StatusId,
                Localizations = d.Localizations?.Select(l => new DocumentTypeLocalizationDto
                {
                    Id = l.Id,
                    LanguageId = l.LanguageId,
                    Name = l.Name
                }).ToList(),
                Audits = d.Audits?.Select(a => new DocumentTypeAuditDto
                {
                    Id = a.Id,
                    DocumentTypeId = a.DocumentTypeId,
                    Code = a.Code,
                    Name = a.Name,
                    IsDefault = a.IsDefault,
                    StatusId = a.StatusId,
                    Browser = a.Browser,
                    Location = a.Location,
                    IP = a.IP,
                    OS = a.OS,
                    MapURL = a.MapURL,
                    Latitude = a.Latitude,
                    Longitude = a.Longitude,
                    ActionTypeId = a.ActionTypeId,
                    ActionUserId = a.ActionUserId,
                    ActionUserAt = a.ActionUserAt
                }).ToList()
            }).ToList();

            return Ok(new { TotalCount = pagedData.TotalCount, Data = result });
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle([FromQuery] long id)
        {
            var response = await _documentTypeService.GetByIdAsync(id);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var documentType = response.Data as DocumentTypeEntity;
            if (documentType == null)
                return NotFound("Document type not found");

            var dto = new DocumentTypeDto
            {
                Id = documentType.Id,
                TemplateId = documentType.TemplateId,
              
                Name = documentType.Name,
                IsDefault = documentType.IsDefault,
                StatusId = documentType.StatusId,
                Localizations = documentType.Localizations?.Select(l => new DocumentTypeLocalizationDto
                {
                    Id = l.Id,
                    LanguageId = l.LanguageId,
                    Name = l.Name
                }).ToList(),
                Audits = documentType.Audits?.Select(a => new DocumentTypeAuditDto
                {
                    Id = a.Id,
                    DocumentTypeId = a.DocumentTypeId,
                    Code = a.Code,
                    Name = a.Name,
                    IsDefault = a.IsDefault,
                    StatusId = a.StatusId,
                    Browser = a.Browser,
                    Location = a.Location,
                    IP = a.IP,
                    OS = a.OS,
                    MapURL = a.MapURL,
                    Latitude = a.Latitude,
                    Longitude = a.Longitude,
                    ActionTypeId = a.ActionTypeId,
                    ActionUserId = a.ActionUserId,
                    ActionUserAt = a.ActionUserAt
                }).ToList()
            };

            return Ok(dto);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle([FromBody] DocumentTypeCreateUpdateDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new DocumentTypeEntity
            {
                TemplateId = dto.TemplateId,
                Name = dto.Name,
                IsDefault = dto.IsDefault,
                StatusId = dto.StatusId,
                Localizations = dto.Localizations?.Select(l => new DocumentTypeLocalization
                {
                    LanguageId = l.LanguageId,
                    Name = l.Name
                }).ToList()
            };

            var response = await _documentTypeService.CreateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, Id = ((DocumentTypeEntity)response.Data).Id });
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk([FromBody] DocumentTypeBulkCreateDto bulkDto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entities = bulkDto.DocumentTypes.Select(dto => new DocumentTypeEntity
            {
                TemplateId = dto.TemplateId,
                Name = dto.Name,
                IsDefault = dto.IsDefault,
                StatusId = dto.StatusId
            }).ToList();

            var response = await _documentTypeService.CreateBulkAsync(entities, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, CreatedCount = response.Data });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] DocumentTypeCreateUpdateDto dto, [FromQuery] int id, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new DocumentTypeEntity
            {
                Id = id,
                TemplateId = dto.TemplateId,
                Name = dto.Name,
                IsDefault = dto.IsDefault,
                StatusId = dto.StatusId,
                Localizations = dto.Localizations?.Select(l => new DocumentTypeLocalization
                {
                    LanguageId = l.LanguageId,
                    Name = l.Name
                }).ToList()
            };

            var response = await _documentTypeService.UpdateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] long id, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var response = await _documentTypeService.DeleteAsync(id, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpGet("GetAllTemplateData")]
        public async Task<IActionResult> GetAllTemplateData()
        {
            var response = await _documentTypeService.GetTemplateDataAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllGallery")]
        public async Task<IActionResult> GetAllGallery()
        {
            var response = await _documentTypeService.GetAllGalleryAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits([FromQuery] long documentTypeId)
        {
            var response = await _documentTypeService.GetAllAuditsAsync(documentTypeId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var audits = response.Data as IEnumerable<DocumentTypeAudit>;
            var result = audits?.Select(a => new DocumentTypeAuditDto
            {
                Id = a.Id,
                DocumentTypeId = a.DocumentTypeId,
                Code = a.Code,
                Name = a.Name,
                IsDefault = a.IsDefault,
                StatusId = a.StatusId,
                Browser = a.Browser,
                Location = a.Location,
                IP = a.IP,
                OS = a.OS,
                MapURL = a.MapURL,
                Latitude = a.Latitude,
                Longitude = a.Longitude,
                ActionTypeId = a.ActionTypeId,
                ActionUserId = a.ActionUserId,
                ActionUserAt = a.ActionUserAt
            });

            return Ok(result);
        }
    }
}
