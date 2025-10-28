using Microsoft.AspNetCore.Mvc;
using RAP.Administrator.Application.DTOs.DocumentDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.Document;

namespace RAP.Administrator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] string language = "en", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _documentService.GetAllAsync(language, pageNumber, pageSize);

            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var pagedData = response.Data as PagedDocumentResponse;
            if (pagedData == null)
                return StatusCode(500, "Invalid data format");

            var result = pagedData.Data.Select(d => new DocumentDTO
            {
                Id = d.Id,
                DocumentNo = d.DocumentNo,
                PINo = d.PINo,
                InvoiceNo = d.InvoiceNo,
                PIDate = d.PIDate,
                InvoiceDate = d.InvoiceDate,
                DocumentDate = d.DocumentDate,
                MobileNo = d.MobileNo,
                IsDefault = d.IsDefault,
                IsDraft = d.IsDraft,
                OrderById = d.OrderById,
                ShipmentTypeId = d.ShipmentTypeId,
                
            }).ToList();

            return Ok(new { TotalCount = pagedData.TotalCount, Data = result });
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle([FromQuery] long id)
        {
            var response = await _documentService.GetByIdAsync(id);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var document = response.Data as DocumentEntity;
            if (document == null)
                return NotFound("Document not found");

            var dto = new DocumentDTO
            {
                Id = document.Id,
                DocumentNo = document.DocumentNo,
                PINo = document.PINo,
                InvoiceNo = document.InvoiceNo,
                PIDate = document.PIDate,
                InvoiceDate = document.InvoiceDate,
                DocumentDate = document.DocumentDate,
                MobileNo = document.MobileNo,
                IsDefault = document.IsDefault,
                IsDraft = document.IsDraft,
                OrderById = document.OrderById,
                ShipmentTypeId = document.ShipmentTypeId,
               
            };

            return Ok(dto);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle([FromBody] DocumentCreateDTO dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new DocumentEntity
            {
                DocumentNo = dto.DocumentNo,
                PINo = dto.PINo,
                InvoiceNo = dto.InvoiceNo,
                PIDate = dto.PIDate,
                InvoiceDate = dto.InvoiceDate,
                DocumentDate = dto.DocumentDate,
                MobileNo = dto.MobileNo,
                IsDefault = dto.IsDefault,
                IsDraft = dto.IsDraft,
                OrderById = dto.OrderById,
                ShipmentTypeId = dto.ShipmentTypeId,
                Localizations = dto.Localizations?.Select(l => new DocumentLocalizationEntity
                {
                    LanguageId = l.LanguageId,
                    Name = l.Name
                }).ToList(),
                Audits = dto.Audits?.Select(a => new DocumentAuditEntity
                {
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
                    Longitude = a.Longitude,
                    ActionTypeId = a.ActionTypeId,
                    ActionUserId = a.ActionUserId,
                    ActionUserAt = a.ActionUserAt
                }).ToList()
            };

            var response = await _documentService.CreateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, Id = ((DocumentEntity)response.Data).Id });
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk([FromBody] List<DocumentCreateDTO> dtos, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entities = dtos.Select(dto => new DocumentEntity
            {
                DocumentNo = dto.DocumentNo,
                PINo = dto.PINo,
                InvoiceNo = dto.InvoiceNo,
                PIDate = dto.PIDate,
                InvoiceDate = dto.InvoiceDate,
                DocumentDate = dto.DocumentDate,
                MobileNo = dto.MobileNo,
                IsDefault = dto.IsDefault,
                IsDraft = dto.IsDraft,
                OrderById = dto.OrderById,
                ShipmentTypeId = dto.ShipmentTypeId
            }).ToList();

            var response = await _documentService.CreateBulkAsync(entities, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, CreatedCount = response.Data });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] DocumentUpdateDTO dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entity = new DocumentEntity
            {
                Id = dto.Id,
                DocumentNo = dto.DocumentNo,
                PINo = dto.PINo,
                InvoiceNo = dto.InvoiceNo,
                PIDate = dto.PIDate,
                InvoiceDate = dto.InvoiceDate,
                DocumentDate = dto.DocumentDate,
                MobileNo = dto.MobileNo,
                IsDefault = dto.IsDefault,
                IsDraft = dto.IsDraft,
                OrderById = dto.OrderById,
                ShipmentTypeId = dto.ShipmentTypeId,
                Localizations = dto.Localizations?.Select(l => new DocumentLocalizationEntity
                {
                    Id = l.Id,
                    LanguageId = l.LanguageId,
                    Name = l.Name
                }).ToList()
            };

            var response = await _documentService.UpdateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] long id, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var response = await _documentService.DeleteAsync(id, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpGet("GetAllTemplateData")]
        public async Task<IActionResult> GetAllTemplateData()
        {
            var response = await _documentService.GetTemplateDataAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllGallery")]
        public async Task<IActionResult> GetAllGallery()
        {
            var response = await _documentService.GetAllGalleryAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits([FromQuery] long documentId)
        {
            var response = await _documentService.GetAllAuditsAsync(documentId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var audits = response.Data as IEnumerable<DocumentAuditEntity>;
            var result = audits?.Select(a => new DocumentAuditDTO
            {
                Id = a.Id,
                DocumentId = a.DocumentId,
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
                Longitude = a.Longitude,
                ActionTypeId = a.ActionTypeId,
                ActionUserId = a.ActionUserId,
                ActionUserAt = a.ActionUserAt
            });

            return Ok(result);
        }
    }
}
