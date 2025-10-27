using Microsoft.AspNetCore.Mvc;
using RAP.Administrator.Application.DTOs.JobLocationDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.JobLocation;

namespace RAP.Administrator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobLocationController : ControllerBase
    {
        private readonly IJobLocationService _jobLocationService;

        public JobLocationController(IJobLocationService jobLocationService)
        {
            _jobLocationService = jobLocationService;
        }

       
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll( [FromQuery] string language = "en",[FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _jobLocationService.GetAllAsync(language, pageNumber, pageSize);

            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var pagedData = response.Data as PagedJobLocationsResponse;
            if (pagedData == null)
                return StatusCode(500, "Invalid data format");

            var result = pagedData.Data.Select(i => new JobLocationDTO
            {
                Id = i.Id,
                JobLocation = i.JobLocation,
                CountryId = i.CountryId,
               
                Descriptions = i.Descriptions,
                IsDefault = i.IsDefault,
                IsDraft = i.IsDraft,
                IsActive = i.IsActive,
                CreatedAt = i.CreatedAt,
                CreatedBy = i.CreatedBy,
                UpdatedAt = i.UpdatedAt,
                UpdatedBy = i.UpdatedBy,
                Localizations = i.Localizations?.Select(l => new JobLocationLocalizationDTO
                {
                    Id = l.Id,
                    JobLocationId = l.JobLocationId,
                    Descriptions = l.Descriptions,
                    LanguageId = l.LanguageId
                }).ToList(),
                Audits = i.Audits?.Select(a => new JobLocationAuditDTO
                {
                    Id = a.Id,
                    JobLocationId = a.JobLocationId,
                   
                    IsDefault = a.IsDefault,
                    IsDraft = a.IsDraft,
                    IsActive = a.IsActive,
                    ActionTypeId = a.ActionTypeId,
                    ActionUserId = a.ActionUserId,
                    ActionUserAt = a.ActionUserAt
                }).ToList()
            }).ToList();

            return Ok(new { TotalCount = pagedData.TotalCount, Data = result });
        }

 
        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle([FromQuery] int id)
        {
            var response = await _jobLocationService.GetByIdAsync(id);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var entity = response.Data as JobLocationEntity;
            if (entity == null)
                return NotFound("Job location not found");

            var dto = new JobLocationDTO
            {
                Id = entity.Id,
                JobLocation = entity.JobLocation,
                CountryId = entity.CountryId,
                
                Descriptions = entity.Descriptions,
                IsDefault = entity.IsDefault,
                IsDraft = entity.IsDraft,
                IsActive = entity.IsActive,
                Localizations = entity.Localizations?.Select(l => new JobLocationLocalizationDTO
                {
                    Id = l.Id,
                    JobLocationId = l.JobLocationId,
                    Descriptions = l.Descriptions,
                    LanguageId = l.LanguageId
                }).ToList(),
                Audits = entity.Audits?.Select(a => new JobLocationAuditDTO
                {
                    Id = a.Id,
                    JobLocationId = a.JobLocationId,
                   
                    IsDefault = a.IsDefault,
                    IsDraft = a.IsDraft,
                    IsActive = a.IsActive,
                    ActionTypeId = a.ActionTypeId,
                    ActionUserId = a.ActionUserId,
                    ActionUserAt = a.ActionUserAt
                }).ToList()
            };

            return Ok(dto);
        }

      
        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle([FromBody] JobLocationCreateDTO dto, [FromQuery] int userId,
            [FromQuery] string language = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new JobLocationEntity
            {
                JobLocation = dto.JobLocation,
                CountryId = dto.CountryId,
                Descriptions = dto.Descriptions,
                IsDefault = dto.IsDefault,
                IsDraft = dto.IsDraft,
                IsActive = dto.IsActive,
                CreatedBy = dto.CreatedBy,
                Localizations = dto.Localizations?.Select(l => new JobLocationLocalizationEntity
                {
                   
                    Descriptions = l.Descriptions,
                    LanguageId = l.LanguageId
                }).ToList()
            };

            var response = await _jobLocationService.CreateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, Id = ((JobLocationEntity)response.Data).Id });
        }

        
        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk(
            [FromBody] List<JobLocationCreateDTO> dtos,
            [FromQuery] int userId,
            [FromQuery] string language = "en")
        {
            var entities = dtos.Select(dto => new JobLocationEntity
            {
                JobLocation = dto.JobLocation,
                CountryId = dto.CountryId,
                Descriptions = dto.Descriptions,
                IsDefault = dto.IsDefault,
                IsDraft = dto.IsDraft,
                IsActive = dto.IsActive,
                CreatedBy = dto.CreatedBy
            }).ToList();

            var response = await _jobLocationService.CreateBulkAsync(entities, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, CreatedCount = response.Data });
        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update( [FromBody] JobLocationUpdateDTO dto,[FromQuery] int userId,
      [FromQuery] string language = "en")
        {
            if (dto.Id == null)
                return BadRequest("JobLocation Id is required for update.");

            var entity = new JobLocationEntity
            {
                Id = dto.Id.Value,  
                JobLocation = dto.JobLocation,
                CountryId = dto.CountryId,
                Descriptions = dto.Descriptions,
                IsDefault = dto.IsDefault,
                IsDraft = dto.IsDraft,
                IsActive = dto.IsActive,
                UpdatedBy = userId 
            };

            var response = await _jobLocationService.UpdateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }


        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(
            [FromQuery] int id,
            [FromQuery] int userId,
            [FromQuery] string language = "en")
        {
            var response = await _jobLocationService.DeleteAsync(id, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

      
        [HttpGet("GetAllTemplateData")]
        public async Task<IActionResult> GetAllTemplateData()
        {
            var response = await _jobLocationService.GetTemplateDataAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits([FromQuery] int jobLocationId)
        {
            var response = await _jobLocationService.GetAllAuditsAsync(jobLocationId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var audits = response.Data as IEnumerable<JobLocationAuditEntity>;
            var result = audits?.Select(a => new JobLocationAuditDTO
            {
                Id = a.Id,
                JobLocationId = a.JobLocationId,
                
                IsDefault = a.IsDefault,
                IsDraft = a.IsDraft,
                IsActive = a.IsActive,
                ActionTypeId = a.ActionTypeId,
                ActionUserId = a.ActionUserId,
                ActionUserAt = a.ActionUserAt
            });

            return Ok(result);
        }
    }
}
