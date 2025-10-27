using Microsoft.AspNetCore.Mvc;
using RAP.Administrator.Application.DTOs.SalaryAdvanceDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.SalaryAdvance;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAP.Administrator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryAdvanceController : ControllerBase
    {
        private readonly ISalaryAdvanceService _service;

        public SalaryAdvanceController(ISalaryAdvanceService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] string language = "en", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _service.GetAllAsync(language, pageNumber, pageSize);

            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var pagedData = response.Data as PagedSalaryAdvanceResponse;
            if (pagedData == null)
                return StatusCode(500, "Invalid data format");

            var result = pagedData.Data.Select(sa => new SalaryAdvanceCreateUpdateDto
            {
                Id = sa.Id,
                IqmaId = sa.IqmaId,
                BranchId = sa.BranchId,
                AdvanceAmount = sa.AdvanceAmount,
                Description = sa.Description,
                PaymentModeId = sa.PaymentModeId,
                Date = sa.Date,
                Localizations = sa.Localizations?.Select(l => new SalaryAdvanceLocalizationDto
                {
                    SalaryAdvanceId = l.SalaryAdvanceId,
                    LanguageId = l.LanguageId,
                   
                }).ToList(),
                Audits = sa.Audits?.Select(a => new SalaryAdvanceAuditDto
                {
                    SalaryAdvanceId = a.SalaryAdvanceId,
                    ActionUserId = a.ActionUserId,
                    ActionUserAt = a.ActionUserAt
                }).ToList()
            }).ToList();

            return Ok(new { TotalCount = pagedData.TotalCount, Data = result });
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle([FromQuery] int id)
        {
            var response = await _service.GetByIdAsync(id);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var entity = response.Data as SalaryAdvanceEntity;
            if (entity == null)
                return NotFound("Salary advance not found");

            var dto = new SalaryAdvanceCreateUpdateDto
            {
                Id = entity.Id,
                IqmaId = entity.IqmaId,
                BranchId = entity.BranchId,
                AdvanceAmount = entity.AdvanceAmount,
                Description = entity.Description,
                PaymentModeId = entity.PaymentModeId,
                Date = entity.Date,
                Localizations = entity.Localizations?.Select(l => new SalaryAdvanceLocalizationDto
                {
                    SalaryAdvanceId = l.SalaryAdvanceId,
                    LanguageId = l.LanguageId,
                    
                }).ToList(),
                Audits = entity.Audits?.Select(a => new SalaryAdvanceAuditDto
                {
                    SalaryAdvanceId = a.SalaryAdvanceId,
                    ActionUserId = a.ActionUserId,
                    ActionUserAt = a.ActionUserAt
                }).ToList()
            };

            return Ok(dto);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle([FromBody] SalaryAdvanceCreateUpdateDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new SalaryAdvanceEntity
            {
                IqmaId = dto.IqmaId,
                BranchId = dto.BranchId,
                AdvanceAmount = dto.AdvanceAmount,
                Description = dto.Description,
                PaymentModeId = dto.PaymentModeId,
                Date = dto.Date,
                Localizations = dto.Localizations?.Select(l => new SalaryAdvanceLocalization
                {
                    LanguageId = l.LanguageId,
                    
                }).ToList()
            };

            var response = await _service.CreateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, Id = ((SalaryAdvanceEntity)response.Data).Id });
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk([FromBody] List<SalaryAdvanceCreateUpdateDto> dtos, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entities = dtos.Select(dto => new SalaryAdvanceEntity
            {
                IqmaId = dto.IqmaId,
                BranchId = dto.BranchId,
                AdvanceAmount = dto.AdvanceAmount,
                Description = dto.Description,
                PaymentModeId = dto.PaymentModeId,
                Date = dto.Date
            }).ToList();

            var response = await _service.CreateBulkAsync(entities, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, CreatedCount = response.Data });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] SalaryAdvanceCreateUpdateDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entity = new SalaryAdvanceEntity
            {
                Id = dto.Id.Value,
                IqmaId = dto.IqmaId,
                BranchId = dto.BranchId,
                AdvanceAmount = dto.AdvanceAmount,
                Description = dto.Description,
                PaymentModeId = dto.PaymentModeId,
                Date = dto.Date,
                Localizations = dto.Localizations?.Select(l => new SalaryAdvanceLocalization
                {
                    SalaryAdvanceId = dto.Id.Value,
                    LanguageId = l.LanguageId,
                    
                }).ToList()
            };

            var response = await _service.UpdateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id, [FromQuery] int userId)
        {
            var response = await _service.DeleteAsync(id, userId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpGet("GetAllTemplateData")]
        public async Task<IActionResult> GetAllTemplateData()
        {
            var response = await _service.GetTemplateDataAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllGallery")]
        public async Task<IActionResult> GetAllGallery()
        {
            var response = await _service.GetAllGalleryAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits([FromQuery] int salaryAdvanceId)
        {
            var response = await _service.GetAllAuditsAsync(salaryAdvanceId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var audits = response.Data as IEnumerable<SalaryAdvanceAudit>;
            var result = audits?.Select(a => new SalaryAdvanceAuditDto
            {
                SalaryAdvanceId = a.SalaryAdvanceId,
                ActionUserId = a.ActionUserId,
                ActionUserAt = a.ActionUserAt
            });

            return Ok(result);
        }
    }
}
