using Microsoft.AspNetCore.Mvc;
using RAP.Administrator.Application.DTOs.CandidateListDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.CandidateList;

namespace RAP.Administrator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateListController : ControllerBase
    {
        private readonly ICandidateListService _candidateListService;

        public CandidateListController(ICandidateListService candidateListService)
        {
            _candidateListService = candidateListService;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] string language = "en", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _candidateListService.GetAllAsync(language, pageNumber, pageSize);

            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var pagedData = response.Data as PagedCandidatelistResponse;
            if (pagedData == null)
                return StatusCode(500, "Invalid data format");

            var result = pagedData.Data.Select(i => new CandidateListReadDTO
            {
                Id = i.Id,
                FirstName = i.FirstName,
                LastName = i.LastName,
                Email = i.Email,
                Phone = i.Phone,
                AlternatePhone = i.AlternatePhone,
                SSN = i.SSN,
                PresentAddress = i.PresentAddress,
                PermanentAddress = i.PermanentAddress,
                ZipCode = i.ZipCode,
                CountryId = i.CountryId,
               
                CreatedAt = i.CreatedAt,
                CreatedBy = i.CreatedBy,
                UpdatedAt = i.UpdatedAt,
                UpdatedBy = i.UpdatedBy,
                IsActive = i.IsActive,
                Localizations = i.Localizations?.Select(l => new CandidateListLocalizationDTO
                {
                    Id = l.Id,
                    CandidateId = l.CandidateId,
                    LanguageId = l.LanguageId,
                    Name = l.Name,
                    Description = l.Description
                }).ToList()
            }).ToList();

            return Ok(new { TotalCount = pagedData.TotalCount, Data = result });
        }

       
        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle([FromQuery] int id)
        {
            var response = await _candidateListService.GetByIdAsync(id);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var candidate = response.Data as CandidateListEntity;
            if (candidate == null)
                return NotFound("Candidate not found");

            var dto = new CandidateListReadDTO
            {
                Id = candidate.Id,
                FirstName = candidate.FirstName,
                LastName = candidate.LastName,
                Email = candidate.Email,
                Phone = candidate.Phone,
                AlternatePhone = candidate.AlternatePhone,
                SSN = candidate.SSN,
                PresentAddress = candidate.PresentAddress,
                PermanentAddress = candidate.PermanentAddress,
                ZipCode = candidate.ZipCode,
                CountryId = candidate.CountryId,
                
                Localizations = candidate.Localizations?.Select(l => new CandidateListLocalizationDTO
                {
                    Id = l.Id,
                    CandidateId = l.CandidateId,
                    LanguageId = l.LanguageId,
                    Name = l.Name,
                    Description = l.Description
                }).ToList(),
                
            };

            return Ok(dto);
        }

       
        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle([FromBody] CandidateListCreateDTO dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new CandidateListEntity
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                AlternatePhone = dto.AlternatePhone,
                SSN = dto.SSN,
                PresentAddress = dto.PresentAddress,
                PermanentAddress = dto.PermanentAddress,
                ZipCode = dto.ZipCode,
                CountryId = dto.CountryId,
                Localizations = dto.Localizations?.Select(l => new CandidateListLocalization
                {
                    CandidateId = l.CandidateId,
                    LanguageId = l.LanguageId,
                    Name = l.Name,
                    Description = l.Description
                }).ToList(),
                Audits = dto.Audits?.Select(a => new CandidateListAudit
                {
                    CandidateId = a.CandidateId,
                   
                    Name = a.Name,
                    IsDefault = a.IsDefault,
                    Status = a.Status,
                    ActionTypeId = a.ActionTypeId,
                    ActionUserId = a.ActionUserId,
                    ActionUserAt = a.ActionUserAt
                }).ToList()
            };

            var response = await _candidateListService.CreateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, Id = ((CandidateListEntity)response.Data).Id });
        }

       
        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk([FromBody] List<CandidateListCreateDTO> dtos, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entities = dtos.Select(dto => new CandidateListEntity
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                AlternatePhone = dto.AlternatePhone,
                SSN = dto.SSN,
                PresentAddress = dto.PresentAddress,
                PermanentAddress = dto.PermanentAddress,
                ZipCode = dto.ZipCode,
                CountryId = dto.CountryId
            }).ToList();

            var response = await _candidateListService.CreateBulkAsync(entities, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, CreatedCount = response.Data });
        }

      
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] CandidateListUpdateDTO dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new CandidateListEntity
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                AlternatePhone = dto.AlternatePhone,
                SSN = dto.SSN,
                PresentAddress = dto.PresentAddress,
                PermanentAddress = dto.PermanentAddress,
                ZipCode = dto.ZipCode,
                CountryId = dto.CountryId
            };

            var response = await _candidateListService.UpdateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }


        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete( [FromQuery] int id, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var response = await _candidateListService.DeleteAsync(id, userId, language);

         
            if (response.IsSuccess)
                return Ok(new { Message = response.Message });

           
            return StatusCode(int.Parse(response.StatusCode), response.Message);
        }



        [HttpGet("GetAllTemplateData")]
        public async Task<IActionResult> GetAllTemplateData()
        {
            var response = await _candidateListService.GetTemplateDataAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

      
        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits([FromQuery] int candidateId)
        {
            var response = await _candidateListService.GetAllAuditsAsync(candidateId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var audits = response.Data as IEnumerable<CandidateListAudit>;
            var result = audits?.Select(a => new CandidateListAuditDTO
            {
                Id = a.Id,
                CandidateId = a.CandidateId,
               
                Name = a.Name,
                IsDefault = a.IsDefault,
                Status = a.Status,
                ActionTypeId = a.ActionTypeId,
                ActionUserId = a.ActionUserId,
                ActionUserAt = a.ActionUserAt
            });

            return Ok(result);
        }
    }
}
