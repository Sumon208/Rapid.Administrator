using Microsoft.AspNetCore.Mvc;
using RAP.Administrator.Application.DTOs.LoanTypesDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.LoanType;

namespace RAP.Administrator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanTypeController : ControllerBase
    {
        private readonly ILoanTypeService _loanTypeService;

        public LoanTypeController(ILoanTypeService loanTypeService)
        {
            _loanTypeService = loanTypeService;
        }

       
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] string language = "en", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _loanTypeService.GetAllAsync(language, pageNumber, pageSize);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var pagedData = response.Data as PagedLoanTypeResponse;
            if (pagedData == null)
                return StatusCode(500, "Invalid data format");

            var result = pagedData.Data.Select(l => new LoanTypeDto
            {
                Id = l.Id,
                LoanTypeText = l.LoanTypeText,
                Description = l.Description,
                IsDefault = l.IsDefault,
                Draft = l.Draft,
                Localizations = l.Localizations?.Select(loc => new LoanTypeLocalizationDto
                {
                    Id = loc.Id,
                  
                    LanguageId = loc.LanguageId,
                    Name = loc.Name
                }).ToList(),
                Audits = l.Audits?.Select(a => new LoanTypeAuditDto
                {
                    Id = a.Id,
                    LoanTypeId = a.LoanTypeId,
                    ActionTypeId = a.ActionTypeId,
                    ActionUserId = a.ActionUserId,
                    ActionUserAt = a.ActionUserAt,
                    LoanTypeText = a.LoanTypeText,
                    Description = a.Description,
                    IsDefault = a.IsDefault,
                    Draft = a.Draft,
                    Browser = a.Browser,
                    IP = a.IP,
                    MapURL = a.MapURL
                }).ToList()
            }).ToList();

            return Ok(new { TotalCount = pagedData.TotalCount, Data = result });
        }

     
        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle([FromQuery] int id)
        {
            var response = await _loanTypeService.GetByIdAsync(id);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var loanType = response.Data as LoanTypeEntity;
            if (loanType == null)
                return NotFound("LoanType not found");

            var dto = new LoanTypeDto
            {
                Id = loanType.Id,
                LoanTypeText = loanType.LoanTypeText,
                Description = loanType.Description,
                IsDefault = loanType.IsDefault,
                Draft = loanType.Draft,
               
            };

            return Ok(dto);
        }

      
        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle([FromBody] LoanTypeCreateDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new LoanTypeEntity
            {
                LoanTypeText = dto.LoanTypeText,
                Description = dto.Description,
                IsDefault = dto.IsDefault,
                Draft = dto.Draft,
                Localizations = dto.Localizations?.Select(l => new LoanTypeLocalization
                {
                    LanguageId = l.LanguageId,
                    Name = l.Name
                }).ToList()
            };

            var response = await _loanTypeService.CreateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, Id = ((LoanTypeEntity)response.Data).Id });
        }

       
        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk([FromBody] List<LoanTypeCreateDto> dtos, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entities = dtos.Select(dto => new LoanTypeEntity
            {
                LoanTypeText = dto.LoanTypeText,
                Description = dto.Description,
                IsDefault = dto.IsDefault,
                Draft = dto.Draft
            }).ToList();

            var response = await _loanTypeService.CreateBulkAsync(entities, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, CreatedCount = response.Data });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] LoanTypeUpdateDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entity = new LoanTypeEntity
            {
                Id = dto.Id,
                LoanTypeText = dto.LoanTypeText,
                Description = dto.Description,
                IsDefault = dto.IsDefault,
                Draft = dto.Draft
            };

            var response = await _loanTypeService.UpdateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

    
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var response = await _loanTypeService.DeleteAsync(id, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

      
        [HttpGet("GetAllTemplateData")]
        public async Task<IActionResult> GetAllTemplateData()
        {
            var response = await _loanTypeService.GetTemplateDataAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

       
        [HttpGet("GetAllGallery")]
        public async Task<IActionResult> GetAllGallery()
        {
            var response = await _loanTypeService.GetAllGalleryAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

      
        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits([FromQuery] int loanTypeId)
        {
            var response = await _loanTypeService.GetAllAuditsAsync(loanTypeId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var audits = response.Data as IEnumerable<LoanTypeAudit>;
            var result = audits?.Select(a => new LoanTypeAuditDto
            {
                Id = a.Id,
                LoanTypeId = a.LoanTypeId,
                ActionTypeId = a.ActionTypeId,
                ActionUserId = a.ActionUserId,
                ActionUserAt = a.ActionUserAt,
                LoanTypeText = a.LoanTypeText,
                Description = a.Description,
                IsDefault = a.IsDefault,
                Draft = a.Draft,
                Browser = a.Browser,
                IP = a.IP,
                MapURL = a.MapURL
            });

            return Ok(result);
        }
    }
}
