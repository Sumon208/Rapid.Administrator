using Microsoft.AspNetCore.Mvc;
using RAP.Administrator.Application.DTOs.SafetyMaterialsDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.SafetyMaterials;

namespace RAP.Administrator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SafetyMaterialsController : ControllerBase
    {
        private readonly ISafetyMaterialsService _safetyMaterialsService;

        public SafetyMaterialsController(ISafetyMaterialsService safetyMaterialsService)
        {
            _safetyMaterialsService = safetyMaterialsService;
        }

   
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] string language = "en", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _safetyMaterialsService.GetAllAsync(language, pageNumber, pageSize);

            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var pagedData = response.Data as PagedSafetyMaterialsResponse;
            if (pagedData == null)
                return StatusCode(500, "Invalid data format");

            var result = pagedData.Data.Select(d => new SafetyMaterialsDto
            {
                Id = d.Id,
                EmployeeId = d.EmployeeId,
                DurationId = d.DurationId,
                Amount = d.Amount,
                Note = d.Note,
                
                Localizations = d.Localizations?.Select(l => new SafetyMaterialsLocalizationDto
                {
                    Id = l.Id,
                    LanguageId = l.LanguageId,
                    SafetyMaterialsId = l.SafetyMaterialsId,
                    Name = l.Name
                }).ToList(),
                Audits = d.Audits?.Select(a => new SafetyMaterialsAuditDto
                {
                    Id = a.Id,
                    SafetyMaterialsId = a.SafetyMaterialsId,
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
                }).ToList(),
                Exports = d.Exports?.Select(e => new SafetyMaterialsExportDto
                {
                    Id = e.Id,
                    SafetyMaterialsId = e.SafetyMaterialsId,
            
                    ExportedAt = e.ExportedAt
                }).ToList()
            }).ToList();

            return Ok(new { TotalCount = pagedData.TotalCount, Data = result });
        }

       
        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle([FromQuery] int id)
        {
            var response = await _safetyMaterialsService.GetByIdAsync(id);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var entity = response.Data as SafetyMaterialsEntity;
            if (entity == null)
                return NotFound("Record not found");

            var dto = new SafetyMaterialsDto
            {
                Id = entity.Id,
                EmployeeId = entity.EmployeeId,
                DurationId = entity.DurationId,
                Amount = entity.Amount,
                Note = entity.Note,
               
                Localizations = entity.Localizations?.Select(l => new SafetyMaterialsLocalizationDto
                {
                    Id = l.Id,
                    LanguageId = l.LanguageId,
                    SafetyMaterialsId = l.SafetyMaterialsId,
                    Name = l.Name
                }).ToList(),
              
            };

            return Ok(dto);
        }

      
        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle([FromBody] SafetyMaterialsCreateDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new SafetyMaterialsEntity
            {
                Date= dto.Date,

                EmployeeId = dto.EmployeeId,
                Category=dto.Category,
                Amount = dto.Amount,
                DurationId = dto.DurationId,
                NextDate = dto.NextDate,
                Note = dto.Note,
                Localizations = dto.Localizations?.Select(l => new SafetyMaterialsLocalizationEntity
                {
                    LanguageId = l.LanguageId,
                    Name = l.Name
                }).ToList()
            };

            var response = await _safetyMaterialsService.CreateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, Id = ((SafetyMaterialsEntity)response.Data).Id });
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk([FromBody] List<SafetyMaterialsDto> dtos, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entities = dtos.Select(dto => new SafetyMaterialsEntity
            {
                Date = dto.Date,

                EmployeeId = dto.EmployeeId,
                Category = dto.Category,
                Amount = dto.Amount,
                DurationId = dto.DurationId,
                NextDate = dto.NextDate,
                Note = dto.Note,
            }).ToList();

            var response = await _safetyMaterialsService.CreateBulkAsync(entities, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new 
            {   Message = response.Message,
                CreatedCount = response.Data 
            });
        }

       
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] SafetyMaterialsDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entity = new SafetyMaterialsEntity
            {
                Id = dto.Id,
                Date = dto.Date,

                EmployeeId = dto.EmployeeId,
                Category = dto.Category,
                Amount = dto.Amount,
                DurationId = dto.DurationId,
                NextDate = dto.NextDate,
                Note = dto.Note,
                Localizations = dto.Localizations?.Select(l => new SafetyMaterialsLocalizationEntity
                {
                    Id = l.Id,
                    SafetyMaterialsId = dto.Id,
                    LanguageId = l.LanguageId,
                    Name = l.Name
                }).ToList()
            };

            var response = await _safetyMaterialsService.UpdateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

  
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var response = await _safetyMaterialsService.DeleteAsync(id, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

       
        [HttpGet("GetAllTemplateData")]
        public async Task<IActionResult> GetAllTemplateData()
        {
            var response = await _safetyMaterialsService.GetTemplateDataAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        
        [HttpGet("GetAllGallery")]
        public async Task<IActionResult> GetAllGallery()
        {
            var response = await _safetyMaterialsService.GetAllGalleryAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

       
        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits([FromQuery] int safetyMaterialsId)
        {
            var response = await _safetyMaterialsService.GetAllAuditsAsync(safetyMaterialsId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var audits = response.Data as IEnumerable<SafetyMaterialsAuditEntity>;
            var result = audits?.Select(a => new SafetyMaterialsAuditDto
            {
                Id = a.Id,
                SafetyMaterialsId = a.SafetyMaterialsId,
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
