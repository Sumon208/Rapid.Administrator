using Microsoft.AspNetCore.Mvc;
using RAP.Administrator.Application.DTOs.InsuranceDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models;
using RAP.Administrator.Domain.Models.Insurance;

namespace RAP.Administrator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceService _insuranceService;

        public InsuranceController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] string language = "en", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _insuranceService.GetAllAsync(language, pageNumber, pageSize);

            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var pagedData = response.Data as PagedInsuranceResponse;
            if (pagedData == null)
                return StatusCode(500, "Invalid data format");

            var result = pagedData.Data.Select(i => new InsuranceDto
            {
                Id = i.Id,
                InsuranceName = i.InsuranceName,
                Description = i.Description,
                IsDefault = i.IsDefault,
                IsDraft = i.IsDraft,
                Branch = i.Branch,
                EmployeeId = i.EmployeeId,
                Localizations = i.Localizations?.Select(l => new InsuranceLocalizationDto
                {
                    InsuranceId = l.InsuranceId,
                    LanguageId = l.LanguageId,
                    Name = l.Name
                }).ToList(),
                Audits = i.Audits?.Select(a => new InsuranceAuditDto
                {
                    InsuranceId = a.InsuranceId,
                    ActionUserId = a.ActionUserId,
                    ActionUserAt = a.ActionUserAt,
                    IsDefault = a.IsDefault,
                    IsDraft = a.IsDraft
                }).ToList()
            }).ToList();

            return Ok(new { TotalCount = pagedData.TotalCount, Data = result });
        }

      
        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle([FromQuery] int id)
        {
            var response = await _insuranceService.GetByIdAsync(id);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var insurance = response.Data as InsuranceEntity;
            if (insurance == null)
                return NotFound("Insurance not found");

            var dto = new InsuranceDto
            {
                Id = insurance.Id,
                InsuranceName = insurance.InsuranceName,
                Description = insurance.Description,
                IsDefault = insurance.IsDefault,
                IsDraft = insurance.IsDraft,
          
                Localizations = insurance.Localizations?.Select(l => new InsuranceLocalizationDto
                {
                    InsuranceId = l.InsuranceId,
                    LanguageId = l.LanguageId,
                   Name = l.Name,
                }).ToList(),
                Audits = insurance.Audits?.Select(a => new InsuranceAuditDto
                {
                    InsuranceId = a.InsuranceId,
                 
                    ActionUserId = a.ActionUserId,
                    ActionUserAt = a.ActionUserAt,
                    IsDefault = a.IsDefault,
                    IsDraft = a.IsDraft
                }).ToList()
            };

            return Ok(dto);
        }

     
        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle([FromBody] InsuranceDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new InsuranceEntity
            {
                InsuranceName = dto.InsuranceName,
                Description = dto.Description,
                IsDefault = dto.IsDefault,
                IsDraft = dto.IsDraft,
                Branch = dto.Branch,
                EmployeeId=(int)dto.EmployeeId,


                Localizations = dto.Localizations?.Select(l => new InsuranceLocalization
                {
                    LanguageId = (int) l.LanguageId,

                    InsuranceId = (int)l.InsuranceId,
                   
                    Name = l.Name,

                }).ToList()
            };

            var response = await _insuranceService.CreateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, Id = ((InsuranceEntity)response.Data).Id });
        }

        
        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk([FromBody] List<InsuranceDto> dtos, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entities = dtos.Select(dto => new InsuranceEntity
            {
                InsuranceName = dto.InsuranceName,
                Description = dto.Description,
                IsDefault = dto.IsDefault,
                IsDraft = dto.IsDraft,
              
            }).ToList();

            var response = await _insuranceService.CreateBulkAsync(entities, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, CreatedCount = response.Data });
        }

     
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] InsuranceDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entity = new InsuranceEntity
            {
                Id = dto.Id,
                InsuranceName = dto.InsuranceName,
                Description = dto.Description,
                IsDefault = dto.IsDefault,
                IsDraft = dto.IsDraft,
               
                Localizations = dto.Localizations?.Select(l => new InsuranceLocalization
                {
                    InsuranceId = dto.Id,
                    LanguageId = (int)l.LanguageId,
                     Name=l.Name
                }).ToList()
            };

            var response = await _insuranceService.UpdateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

       
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var response = await _insuranceService.DeleteAsync(id, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

       
        [HttpGet("GetAllTemplateData")]
        public async Task<IActionResult> GetAllTemplateData()
        {
            var response = await _insuranceService.GetTemplateDataAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        
        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits([FromQuery] int insuranceId)
        {
            var response = await _insuranceService.GetAllAuditsAsync(insuranceId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var audits = response.Data as IEnumerable<InsuranceAuditEntity>;
            var result = audits?.Select(a => new InsuranceAuditDto
            {
                InsuranceId = a.InsuranceId,
              
                ActionUserId = a.ActionUserId,
                ActionUserAt = a.ActionUserAt,
                IsDefault = a.IsDefault,
                IsDraft = a.IsDraft
            });

            return Ok(result);
        }
    }
}
