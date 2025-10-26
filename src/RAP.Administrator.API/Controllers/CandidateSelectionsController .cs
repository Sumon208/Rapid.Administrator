using Microsoft.AspNetCore.Mvc;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.DTOs.CandidateDTOs;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.CandidateSelection;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using RAP.Administrator.Application.DTOs.CandidateDTOs.RAP.Administrator.Application.DTOs.CandidateDTOs;

namespace RAP.Administrator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateSelectionsController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateSelectionsController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] int? languageId = 1,[FromQuery] int pageNumber = 1,
          [FromQuery] int pageSize = 10)
        {
            var response = await _candidateService.GetAllAsync(pageNumber, pageSize, languageId);

            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var pagedData = response.Data as PagedCandidateResponse;
            if (pagedData == null)
                return StatusCode(500, "Invalid data format");

            var result = pagedData.Data.Select(c => new CandidateListDto
            {
                Id = c.Id,
                Code = c.Code,
                Name = c.Name,
                PositionName = c.Position?.PositionName,
                TeamName = c.Team?.TeamName,
                StatusId = c.StatusId,
                IsDefault = c.IsDefault,
                Localizations = c.Localizations?.Select(l => new CandidateLocalizationDto
                {
                    LanguageId = (int)l.LanguageId,
                    LocalizedName = l.LocalizedName,
                    LocalizedDescription = l.LocalizedDescription
                }).ToList(),
                Audits = c.Audits?.Select(a => new CandidateAuditDto
                {
                    CandidateId = a.CandidateId,
                    ActionTypeId = a.ActionTypeId,
                    ActionUserId = a.ActionUserId,
                    ActionUserAt = a.ActionUserAt
                }).ToList()
            }).ToList();

            return Ok(new
            {
                TotalCount = pagedData.TotalCount,
                Data = result
            });
        }




        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle([FromQuery] int id, [FromQuery] int? languageId = null)
        {
            var response = await _candidateService.GetByIdAsync(id, languageId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var candidate = response.Data as CandidateEntity;
            if (candidate == null)
                return NotFound("Candidate not found");

            var dto = new CandidateDto
            {
                Id = candidate.Id,
                Code = candidate.Code,
                Name = candidate.Name,
                PositionId = candidate.PositionId,
                PositionName = candidate.Position?.PositionName,
                TeamId = candidate.TeamId,
                TeamName = candidate.Team?.TeamName,
                StatusId = candidate.StatusId,
                IsDefault = candidate.IsDefault,
                Localizations = candidate.Localizations?.Select(l => new CandidateLocalizationDto
                {
                    LanguageId = (int) l.LanguageId,
                    LocalizedName = l.LocalizedName,
                    LocalizedDescription = l.LocalizedDescription
                }).ToList(),
                Audits = candidate.Audits?.Select(a => new CandidateAuditDto
                {
                    CandidateId = a.CandidateId,
                    ActionTypeId = a.ActionTypeId,
                    ActionUserId = a.ActionUserId,
                    ActionUserAt = a.ActionUserAt
                }).ToList()
            };

            return Ok(dto);
        }

       
        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle([FromBody] CandidateCreateDto dto, [FromQuery] int userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new CandidateEntity
            {
                Code = dto.Code,
                Name = dto.Name,
                PositionId = dto.PositionId,
                TeamId = dto.TeamId,
                StatusId = dto.StatusId,
                IsDefault = dto.IsDefault,
                //Localizations = dto.Localizations?.Select(l => new CandidateLocalization
                //{
                //    LanguageId = l.LanguageId,
                //    LocalizedName = l.LocalizedName,
                //    LocalizedDescription = l.LocalizedDescription
                //}).ToList()
            };

            var response = await _candidateService.CreateAsync(entity, userId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new
            {
                Message = response.Message,
                Id = ((CandidateEntity)response.Data).Id
            });
        }

       
        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk([FromBody] CandidateBulkCreateDto dto, [FromQuery] int userId)
        {
            var entities = dto.Candidates.Select(c => new CandidateEntity
            {
                Code = c.Code,
                Name = c.Name,
                PositionId = c.PositionId,
                TeamId = c.TeamId,
                StatusId = c.StatusId,
                IsDefault = c.IsDefault,
                //Localizations = c.Localizations?.Select(l => new CandidateLocalization
                //{
                //    LanguageId = l.LanguageId,
                //    LocalizedName = l.LocalizedName,
                //    LocalizedDescription = l.LocalizedDescription
                //}).ToList()
            }).ToList();

            var response = await _candidateService.CreateBulkAsync(entities, userId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new
            {
                Message = response.Message,
                CreatedCount = response.Data
            });
        }

        
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] CandidateUpdateDto dto, [FromQuery] int userId)
        {
            var entity = new CandidateEntity
            {
                Id = dto.Id,
                Code = dto.Code,
                Name = dto.Name,
                PositionId = dto.PositionId,
                TeamId = dto.TeamId,
                StatusId = dto.StatusId,
                IsDefault = dto.IsDefault,
                Localizations = dto.Localizations?.Select(l => new CandidateLocalization
                {
                    LanguageId = l.LanguageId,
                    LocalizedName = l.LocalizedName,
                    LocalizedDescription = l.LocalizedDescription
                }).ToList()
            };

            var response = await _candidateService.UpdateAsync(entity, userId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

       
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id, [FromQuery] int userId)
        {
            var response = await _candidateService.DeleteAsync(id, userId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

      
        [HttpGet("GetAllTemplateData")]
        public async Task<IActionResult> GetAllTemplateData()
        {
            var response = await _candidateService.GetTemplateDataAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

       
        [HttpGet("GetAllGallery")]
        public async Task<IActionResult> GetAllGallery()
        {
            var response = await _candidateService.GetAllGalleryAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        // ---------------- GET AUDITS ----------------
        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits([FromQuery] int candidateId)
        {
            var response = await _candidateService.GetAllAuditsAsync(candidateId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var audits = response.Data as IEnumerable<CandidateAudit>;
            var result = audits?.Select(a => new CandidateAuditDto
            {
                CandidateId = a.CandidateId,
                ActionTypeId = a.ActionTypeId,
                ActionUserId = a.ActionUserId,
                ActionUserAt = a.ActionUserAt
            });

            return Ok(result);
        }
    }
}
