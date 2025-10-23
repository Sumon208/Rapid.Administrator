using Microsoft.AspNetCore.Mvc;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.DTOs.ShiftTypeDTOs;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models;

namespace RAP.Administrator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftTypeController : ControllerBase
    {
        private readonly IShiftTypeService _shiftTypeService;

        public ShiftTypeController(IShiftTypeService shiftTypeService)
        {
            _shiftTypeService = shiftTypeService;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] string language = "en", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _shiftTypeService.GetAllAsync(language, pageNumber, pageSize);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

          
            var pagedData = response.Data as PagedShiftTypeResponse;
            if (pagedData == null)
                return StatusCode(500, "Invalid data format");

            var result = pagedData.Data.Select(d => new ShiftTypeResponseDto
            {
                Id = d.Id,
                Name = d.Name,
                Color = d.Color ?? "",
                StartTime = d.StartTime,
                EndTime = d.EndTime,
                BreakTime = d.BreakTime,
                Status = d.Status,
                IsDefault = d.IsDefault
            }).ToList();

            return Ok(new { TotalCount = pagedData.TotalCount, Data = result });
        }


        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle([FromQuery] long id)
        {
            var response = await _shiftTypeService.GetByIdAsync(id);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var data = response.Data as ShiftTypeResponseDto;
            if (data == null)
                return NotFound("ShiftType not found");

            return Ok(data);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle([FromBody] ShiftTypeCreateDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new ShiftType
            {
                Name = dto.Name,
                Color = dto.Color,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                BreakTime = dto.BreakTime,
                Status = dto.Status,
                IsDefault = dto.IsDefault,
                Localizations = dto.Localizations?.Select(l => new ShiftTypeLocalization
                {
                    LanguageId = l.LanguageId,
                  
                }).ToList()
            };

            var response = await _shiftTypeService.CreateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, Id = ((ShiftType)response.Data).Id });
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk([FromBody] List<ShiftTypeCreateDto> dtos, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entities = dtos.Select(dto => new ShiftType
            {
                Name = dto.Name,
                Color = dto.Color,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                BreakTime = dto.BreakTime,
                Status = dto.Status,
                IsDefault = dto.IsDefault
            }).ToList();

            var response = await _shiftTypeService.CreateBulkAsync(entities, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, CreatedCount = response.Data });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] ShiftTypeUpdateDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new ShiftType
            {
                Id = dto.Id,
                Name = dto.Name,
                Color = dto.Color,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                BreakTime = dto.BreakTime,
                Status = dto.Status,
                IsDefault = dto.IsDefault,
                Localizations = dto.Localizations?.Select(l => new ShiftTypeLocalization
                {
                    ShiftTypeId = l.ShiftTypeId,
                    LanguageId = l.LanguageId,
                    
                }).ToList()
            };

            var response = await _shiftTypeService.UpdateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] long id, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var response = await _shiftTypeService.DeleteAsync(id, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpGet("GetAllTemplateData")]
        public async Task<IActionResult> GetAllTemplateData()
        {
            var response = await _shiftTypeService.GetTemplateDataAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllGallery")]
        public async Task<IActionResult> GetAllGallery()
        {
            var response = await _shiftTypeService.GetAllGalleryAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }


        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits([FromQuery] long shiftTypeId)
        {
            var response = await _shiftTypeService.GetAllAuditsAsync(shiftTypeId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var audits = response.Data as IEnumerable<ShiftTypeAudit>;
            var result = audits?.Select(a => new ShiftTypeAuditDto
            {
                ShiftTypeId =a.ShiftTypeId, 
                ActionTypeName = a.ActionTypeName,
                ActionUserId = (int?)a.ActionUserId, 
                ActionAt = a.ActionAt,
                IsDefault = a.IsDefault
            });

            return Ok(result);
        }


    }
}
