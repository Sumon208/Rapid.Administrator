using Microsoft.AspNetCore.Mvc;
using RAP.Administrator.Application.DTOs.ProjectContractTypeDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.ProjectContractType;


namespace RAP.Administrator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectContractTypeController : ControllerBase
    {
        private readonly IProjectContractTypeService _projectContractTypeService;

        public ProjectContractTypeController(IProjectContractTypeService projectContractTypeService)
        {
            _projectContractTypeService = projectContractTypeService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] string language = "en", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _projectContractTypeService.GetAllAsync(language, pageNumber, pageSize);

            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var pagedData = response.Data as PagedProjectContractTypeResponse;
            if (pagedData == null)
                return StatusCode(500, "Invalid data format");

            var result = pagedData.Data.Select(p => new ProjectContractTypeDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                IsDefault = p.IsDefault,
                IsDraft = p.IsDraft,
                Localizations = p.Localizations?.Select(l => new ProjectContractTypeLocalizationDto
                {
                    Id = l.Id,
                    ProjectContractTypeId = l.ProjectContractTypeId,
                    LanguageId = l.LanguageId,
                    Name = l.Name
                }).ToList(),
                Audits = p.Audits?.Select(a => new ProjectContractTypeAuditDto
                {
                    Id = a.Id,
                    ProjectContractTypeId = a.ProjectContractTypeId,
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
        public async Task<IActionResult> GetSingle([FromQuery] long id)
        {
            var response = await _projectContractTypeService.GetByIdAsync(id);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var entity = response.Data as ProjectContractTypeEntity;
            if (entity == null)
                return NotFound("Record not found");

            var dto = new ProjectContractTypeDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                IsDefault = entity.IsDefault,
                IsDraft = entity.IsDraft,
                Localizations = entity.Localizations?.Select(l => new ProjectContractTypeLocalizationDto
                {
                    Id = l.Id,
                    ProjectContractTypeId = l.ProjectContractTypeId,
                    LanguageId = l.LanguageId,
                    Name = l.Name
                }).ToList(),
                Audits = entity.Audits?.Select(a => new ProjectContractTypeAuditDto
                {
                    Id = a.Id,
                    ProjectContractTypeId = a.ProjectContractTypeId,
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
            };

            return Ok(dto);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle([FromBody] ProjectContractTypeCreateUpdateDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new ProjectContractTypeEntity
            {
                Name = dto.Name,
                Description = dto.Description,
                IsDraft = dto.IsDraft,
                IsDefault = dto.IsDefault,
                Localizations = dto.Localizations?.Select(l => new ProjectContractTypeLocalization
                {
                    LanguageId = l.LanguageId,
                    Name = l.Name
                }).ToList()
            };

            var response = await _projectContractTypeService.CreateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, Id = ((ProjectContractTypeEntity)response.Data).Id });
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk([FromBody] List<ProjectContractTypeCreateUpdateDto> dtos, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entities = dtos.Select(dto => new ProjectContractTypeEntity
            {
                Name = dto.Name,
                Description = dto.Description,
                IsDraft = dto.IsDraft,
                IsDefault = dto.IsDefault
            }).ToList();

            var response = await _projectContractTypeService.CreateBulkAsync(entities, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, CreatedCount = response.Data });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] ProjectContractTypeCreateUpdateDto dto, [FromQuery] int id, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entity = new ProjectContractTypeEntity
            {
                Id = id,
                Name = dto.Name,
                Description = dto.Description,
                IsDraft = dto.IsDraft,
                IsDefault = dto.IsDefault,
                Localizations = dto.Localizations?.Select(l => new ProjectContractTypeLocalization
                {
                    ProjectContractTypeId = id,
                    LanguageId = l.LanguageId,
                    Name = l.Name
                }).ToList()
            };

            var response = await _projectContractTypeService.UpdateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] long id, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var response = await _projectContractTypeService.DeleteAsync(id, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpGet("GetAllTemplateData")]
        public async Task<IActionResult> GetAllTemplateData()
        {
            var response = await _projectContractTypeService.GetTemplateDataAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllGallery")]
        public async Task<IActionResult> GetAllGallery()
        {
            var response = await _projectContractTypeService.GetAllGalleryAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits([FromQuery] long projectContractTypeId)
        {
            var response = await _projectContractTypeService.GetAllAuditsAsync(projectContractTypeId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var audits = response.Data as IEnumerable<ProjectContractTypeAudit>;
            var result = audits?.Select(a => new ProjectContractTypeAuditDto
            {
                Id = a.Id,
                ProjectContractTypeId = a.ProjectContractTypeId,
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
