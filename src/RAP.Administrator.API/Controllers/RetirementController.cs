using Microsoft.AspNetCore.Mvc;
using RAP.Administrator.Application.DTOs.RetirementDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.Retirement;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAP.Administrator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetirementController : ControllerBase
    {
        private readonly IRetirementService _retirementService;

        public RetirementController(IRetirementService retirementService)
        {
            _retirementService = retirementService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] string language = "en", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _retirementService.GetAllAsync(language, pageNumber, pageSize);

            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var pagedData = response.Data as PagedRetirementResponse;
            if (pagedData == null)
                return StatusCode(500, "Invalid data format");

            var result = pagedData.Data.Select(r => new RetirementReadDto
            {
                
                Retirement = r.Retirement,
                EmployeeId = r.EmployeeId,
                Date = r.Date,
                Description = r.Description,
                Status = r.Status,
                IsDefault = r.IsDefault,
                Draft = r.Draft,
                Branch = r.Branch,
                Localizations = r.Localizations?.Select(l => new RetirementLocalizationDto
                {
                    RetirementId = l.RetirementId,
                    LanguageId = l.LanguageId,
                    Description = l.Description
                }).ToList(),
                Audits = r.Audits?.Select(a => new RetirementAuditDto
                {
                    RetirementId = a.RetirementId,
                    ActionType = a.ActionType,
                    ActionUserId = a.ActionUserId,
                    ActionDate = a.ActionDate,
                    EmployeeName = a.EmployeeName,
                    Date = a.Date,
                    Description = a.Description,
                    Status = a.Status
                }).ToList()
            }).ToList();

            return Ok(new { TotalCount = pagedData.TotalCount, Data = result });

        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle([FromQuery] int id)
        {
            var response = await _retirementService.GetByIdAsync(id);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var retirement = response.Data as RetirementEntity;
            if (retirement == null)
                return NotFound("Retirement not found");

            var dto = new RetirementReadDto
            {
                Id = retirement.Id,
                EmployeeId = retirement.EmployeeId,
                Date = retirement.Date,
                Description = retirement.Description,
                Status = retirement.Status,
                Branch = retirement.Branch,
                IsDefault = retirement.IsDefault,
                Draft = retirement.Draft,
                Localizations = retirement.Localizations?.Select(l => new RetirementLocalizationDto
                {
                    RetirementId = l.RetirementId,
                    LanguageId = l.LanguageId,
                    Description = l.Description
                }).ToList(),
                Audits = retirement.Audits?.Select(a => new RetirementAuditDto
                {
                    RetirementId = a.RetirementId,
                    ActionUserId = a.ActionUserId,
                    ActionType = a.ActionType,
                    ActionDate = a.ActionDate,
                    EmployeeName = a.EmployeeName,
                    Date = a.Date,
                    Description = a.Description,
                    Status = a.Status
                }).ToList()
            };

            return Ok(dto);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle([FromBody] RetirementCreateDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new RetirementEntity
            {
                Retirement=dto.Retirement,
                EmployeeId = dto.EmployeeId,
                Date = dto.Date,
                Description = dto.Description,
                Status = dto.Status,
                Branch = dto.Branch,
                IsDefault = dto.IsDefault,
                Draft = dto.Draft,
                Localizations = dto.Localizations?.Select(l => new RetirementLocalization
                {
                    RetirementId = l.RetirementId ?? 0,
                    LanguageId = l.LanguageId ?? 0,
                    Description = l.Description
                }).ToList(),
                Audits = dto.Audits?.Select(a => new RetirementAudit
                {
                    RetirementId = a.RetirementId ?? 0,
                    ActionUserId = a.ActionUserId,
                    ActionType = a.ActionType,
                    ActionDate = a.ActionDate,
                    EmployeeName = a.EmployeeName,
                    Date = a.Date,
                    Description = a.Description,
                    Status = a.Status
                }).ToList()
            };

            var response = await _retirementService.CreateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, Id = ((RetirementEntity)response.Data).Id });
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk([FromBody] List<RetirementCreateDto> dtos, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entities = dtos.Select(dto => new RetirementEntity
            {
                Retirement=dto.Retirement,
                EmployeeId = dto.EmployeeId,
                Date = dto.Date,
                Description = dto.Description,
                Status = dto.Status,
                Branch = dto.Branch,
                IsDefault = dto.IsDefault,
                Draft = dto.Draft
            }).ToList();

            var response = await _retirementService.CreateBulkAsync(entities, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, CreatedCount = response.Data });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] RetirementCreateDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {

            var entity = new RetirementEntity
            {
                Id = dto.RetirementId ?? 0,
                EmployeeId = dto.EmployeeId,
                Date = dto.Date,
                Description = dto.Description,
                Status = dto.Status,
                Branch = dto.Branch,
                IsDefault = dto.IsDefault,
                Draft = dto.Draft,
                Localizations = dto.Localizations?.Select(l => new RetirementLocalization
                {
                    RetirementId = dto.RetirementId ?? 0,
                    LanguageId = l.LanguageId ?? 0,
                    Description = l.Description
                }).ToList()
            };

            var response = await _retirementService.UpdateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var response = await _retirementService.DeleteAsync(id, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpGet("GetAllTemplateData")]
        public async Task<IActionResult> GetAllTemplateData()
        {
            var response = await _retirementService.GetTemplateDataAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits([FromQuery] int retirementId)
        {
            var response = await _retirementService.GetAllAuditsAsync(retirementId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var audits = response.Data as IEnumerable<RetirementAudit>;
            var result = audits?.Select(a => new RetirementAuditDto
            {
                RetirementId = a.RetirementId,
                ActionUserId = a.ActionUserId,
                ActionType = a.ActionType,
                ActionDate = a.ActionDate,
                EmployeeName = a.EmployeeName,
                Date = a.Date,
                Description = a.Description,
                Status = a.Status
            });

            return Ok(result);
        }
    }
}
