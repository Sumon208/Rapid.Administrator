using Microsoft.AspNetCore.Mvc;
using RAP.Administrator.Application.DTOs.DivisionDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models;

namespace RAP.Administrator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        private readonly IDivisionService _divisionService;

        public DivisionController(IDivisionService divisionService)
        {
            _divisionService = divisionService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] string language = "en", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _divisionService.GetAllAsync(language, pageNumber, pageSize);

            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var pagedData = response.Data as PagedDivisionResponse;
            if (pagedData == null)
                return StatusCode(500, "Invalid data format");

            var result = pagedData.Data.Select(d => new DivisionDto
            {
                Id = d.Id,
                Code = d.Code,
                DivisionName = d.DivisionName,
                Region = d.Region,
                Description = d.Description,
                StatusTypeId = d.StatusTypeId,
                IsDefault = d.IsDefault,
                Localizations = d.Localizations?.Select(l => new DivisionLocalizationDto
                {
                    DivisionId = l.DivisionId,
                    LanguageId = l.LanguageId,
                    CountryId = l.CountryId,
                    LocalizedName = l.LocalizedName,
                    LocalizedDescription = l.LocalizedDescription,
                    IsDeleted = l.IsDeleted,
                    DeletedAt = l.DeletedAt,
                    DeletedBy = l.DeletedBy
                }).ToList(),
                Audits = d.Audits?.Select(a => new DivisionAuditDto
                {
                    DivisionId = a.DivisionId,
                    ActionTypeName = a.ActionTypeName,
                    ActionUserId = a.ActionUserId,
                    ActionAt = a.ActionAt,
                    IsDefault = a.IsDefault,
                    StatusTypeId = a.StatusTypeId
                }).ToList()
            }).ToList();

            return Ok(new { TotalCount = pagedData.TotalCount, Data = result });
        }


        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle([FromQuery] long id)
        {
            var response = await _divisionService.GetByIdAsync(id);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var division = response.Data as Division;
            if (division == null)
                return NotFound("Division not found");

            var dto = new DivisionDto
            {
                Id = division.Id,
                Code = division.Code,
                DivisionName = division.DivisionName,
                Region = division.Region,
                Description = division.Description,
                StatusTypeId = division.StatusTypeId,
                IsDefault = division.IsDefault,
                Localizations = division.Localizations?.Select(l => new DivisionLocalizationDto
                {
                    DivisionId = l.DivisionId,
                    LanguageId = l.LanguageId,
                    CountryId = l.CountryId,
                    LocalizedName = l.LocalizedName,
                    LocalizedDescription = l.LocalizedDescription,
                    IsDeleted = l.IsDeleted,
                    DeletedAt = l.DeletedAt,
                    DeletedBy = l.DeletedBy
                }).ToList(),
                Audits = division.Audits?.Select(a => new DivisionAuditDto
                {
                    DivisionId = a.DivisionId,
                    ActionTypeName = a.ActionTypeName,
                    ActionUserId = a.ActionUserId,
                    ActionAt = a.ActionAt,
                    IsDefault = a.IsDefault,
                    StatusTypeId = a.StatusTypeId
                }).ToList()
            };

            return Ok(dto);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle([FromBody] DivisionDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new Division
            {
                Code = dto.Code,
                DivisionName = dto.DivisionName,
                Region = dto.Region,
                Description = dto.Description,
                StatusTypeId = dto.StatusTypeId,
                IsDefault = dto.IsDefault,
                Localizations = dto.Localizations?.Select(l => new DivisionLocalization
                {
                    LanguageId = l.LanguageId,
                    CountryId = l.CountryId,
                    LocalizedName = l.LocalizedName,
                    LocalizedDescription = l.LocalizedDescription,
                    IsDeleted = l.IsDeleted,
                    DeletedAt = l.DeletedAt,
                    DeletedBy = l.DeletedBy
                }).ToList()
            };

            var response = await _divisionService.CreateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, Id = ((Division)response.Data).Id });
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk([FromBody] List<DivisionDto> dtos, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entities = dtos.Select(dto => new Division
            {
                Code = dto.Code,
                DivisionName = dto.DivisionName,
                Region = dto.Region,
                Description = dto.Description,
                StatusTypeId = dto.StatusTypeId,
                IsDefault = dto.IsDefault
            }).ToList();

            var response = await _divisionService.CreateBulkAsync(entities, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, CreatedCount = response.Data });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] DivisionDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entity = new Division
            {
                Id = dto.Id,
                Code = dto.Code,
                DivisionName = dto.DivisionName,
                Region = dto.Region,
                Description = dto.Description,
                StatusTypeId = dto.StatusTypeId,
                IsDefault = dto.IsDefault,
                Localizations = dto.Localizations?.Select(l => new DivisionLocalization
                {
                    DivisionId = dto.Id,
                    LanguageId = l.LanguageId,
                    CountryId = l.CountryId,
                    LocalizedName = l.LocalizedName,
                    LocalizedDescription = l.LocalizedDescription,
                    IsDeleted = l.IsDeleted,
                    DeletedAt = l.DeletedAt,
                    DeletedBy = l.DeletedBy
                }).ToList()
            };

            var response = await _divisionService.UpdateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] long id, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var response = await _divisionService.DeleteAsync(id, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpGet("GetAllTemplateData")]
        public async Task<IActionResult> GetAllTemplateData()
        {
            var response = await _divisionService.GetTemplateDataAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllGallery")]
        public async Task<IActionResult> GetAllGallery()
        {
            var response = await _divisionService.GetAllGalleryAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits([FromQuery] long divisionId)
        {
            var response = await _divisionService.GetAllAuditsAsync(divisionId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var audits = response.Data as IEnumerable<DivisionAudit>;
            var result = audits?.Select(a => new DivisionAuditDto
            {
                DivisionId = a.DivisionId,
                ActionTypeName = a.ActionTypeName,
                ActionUserId = a.ActionUserId,
                ActionAt = a.ActionAt,
                IsDefault = a.IsDefault,
                StatusTypeId = a.StatusTypeId
            });

            return Ok(result);
        }
    }
}
