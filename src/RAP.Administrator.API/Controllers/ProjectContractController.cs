using Microsoft.AspNetCore.Mvc;
using RAP.Administrator.Application.DTOs.ProjectContractDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Services;

using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using RAP.Administrator.Domain.Models.ProjectContract;

namespace RAP.Administrator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectContractController : ControllerBase
    {
        private readonly IProjectContractService _service;

        public ProjectContractController(IProjectContractService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] string language = "en", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _service.GetAllAsync(language, pageNumber, pageSize);

            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var pagedData = response.Data as PagedProjectContractResponse;
            if (pagedData == null)
                return StatusCode(500, "Invalid data format");

            var result = ((IEnumerable<ProjectContractEntity>)pagedData.Data).Select(pc => new ProjectContractDto
            {
                Id = pc.Id,
                Subject = pc.Subject,
                ContractTypeId = pc.ContractTypeId,
                
                Customer = pc.Customer,
                ContractValue = pc.ContractValue,
                StartDate = pc.StartDate,
                EndDate = pc.EndDate,
                Description = pc.Description,
                IsDefault = pc.IsDefault,
                Draft = pc.Draft,
                Localizations = pc.Localizations?.Select(l => new ProjectContractLocalizationDto
                {
                    ProjectContractId = l.ProjectContractId,
                    LanguageId = l.LanguageId,
                   Name = l.Name
                }).ToList(),
                Audits = pc.Audits?.Select(a => new ProjectContractAuditDto
                {
                    ProjectContractId = a.ProjectContractId,
                    
                    Description = a.Description
                }).ToList(),
               
            }).ToList();

            return Ok(new { TotalCount = pagedData.TotalCount, Data = result });
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle([FromQuery] long id)
        {
            var response = await _service.GetByIdAsync(id);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var pc = response.Data as ProjectContractEntity;
            if (pc == null)
                return NotFound("Project contract not found");

            var dto = new ProjectContractDto
            {
                Id = pc.Id,
                Subject = pc.Subject,
                ContractTypeId = pc.ContractTypeId,
              
                Customer = pc.Customer,
                ContractValue = pc.ContractValue,
                StartDate = pc.StartDate,
                EndDate = pc.EndDate,
                Description = pc.Description,
                IsDefault = pc.IsDefault,
                Draft = pc.Draft,
                Localizations = pc.Localizations?.Select(l => new ProjectContractLocalizationDto
                {
                    ProjectContractId = l.ProjectContractId,
                    LanguageId = l.LanguageId,
                   Name = l.Name
                }).ToList(),
                Audits = pc.Audits?.Select(a => new ProjectContractAuditDto
                {
                    ProjectContractId = a.ProjectContractId,
                   
                    ActionUserId = a.ActionUserId,
                   
                    Description = a.Description
                }).ToList(),
                Exports = pc.Exports?.Select(e => new ProjectContractExportDto
                {
                    ProjectContractId = e.ProjectContractId,
                   
                }).ToList()
            };

            return Ok(dto);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle([FromBody] ProjectContractCreateDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new ProjectContractEntity
            {
                Subject = dto.Subject,
                ContractTypeId = dto.ContractTypeId,
                Customer = dto.Customer,
                ContractValue = dto.ContractValue,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Description = dto.Description,
                IsDefault = dto.IsDefault,
                Draft = dto.Draft,
                Localizations = dto.Localizations?.Select(l => new ProjectContractLocalization
                {
                    LanguageId = l.LanguageId,
                    Name=l.Name,
                }).ToList()
            };

            var response = await _service.CreateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, Id = ((ProjectContractEntity)response.Data).Id });
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk([FromBody] ProjectContractBulkCreateDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entities = dto.Contracts?.Select(c => new ProjectContractEntity
            {
                Subject = c.Subject,
                ContractTypeId = c.ContractTypeId,
                Customer = c.Customer,
                ContractValue = c.ContractValue,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                Description = c.Description,
                IsDefault = c.IsDefault,
                Draft = c.Draft,
                Localizations = c.Localizations?.Select(l => new ProjectContractLocalization
                {
                    LanguageId = l.LanguageId,
                   Name = l.Name
                }).ToList()
            }).ToList();

            var response = await _service.CreateBulkAsync(entities, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, CreatedCount = response.Data });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] ProjectContractUpdateDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entity = new ProjectContractEntity
            {
                Id = dto.Id,
                Subject = dto.Subject,
                ContractTypeId = dto.ContractTypeId,
                Customer = dto.Customer,
                ContractValue = dto.ContractValue,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Description = dto.Description,
                IsDefault = dto.IsDefault,
                Draft = dto.Draft,
                Localizations = dto.Localizations?.Select(l => new ProjectContractLocalization
                {
                    ProjectContractId = dto.Id,
                    LanguageId = l.LanguageId,
                    
                }).ToList()
            };

            var response = await _service.UpdateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] long id, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var response = await _service.DeleteAsync(id, userId, language);
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
        public async Task<IActionResult> GetAllAudits([FromQuery] long projectContractId)
        {
            var response = await _service.GetAllAuditsAsync(projectContractId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var audits = response.Data as IEnumerable<ProjectContractAudit>;
            var result = audits?.Select(a => new ProjectContractAuditDto
            {
                ProjectContractId = a.ProjectContractId,
               
                ActionUserId = a.ActionUserId,
              
                Description = a.Description
            });

            return Ok(result);
        }
    }
}
