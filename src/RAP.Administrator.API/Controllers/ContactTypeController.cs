using Microsoft.AspNetCore.Mvc;
using RAP.Administrator.Application.DTOs.ContactTypeDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.ContactType;

namespace RAP.Administrator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactTypeController : ControllerBase
    {
        private readonly IContactTypeService _contactTypeService;

        public ContactTypeController(IContactTypeService contactTypeService)
        {
            _contactTypeService = contactTypeService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] string language = "en", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _contactTypeService.GetAllAsync(language, pageNumber, pageSize);

            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var pagedData = response.Data as PagedContactTypeResponse;
            if (pagedData == null)
                return StatusCode(500, "Invalid data format");

            var result = pagedData.Data.Select(d => new ContactTypeListDto
            {
                Id = d.Id,
                ContactType = d.ContactType,
                Description = d.Description,
                Localizations = d.Localizations?.Select(l => new ContactTypeLocalizationDto
                {
                    Id = l.Id,
                    ContactTypeId = l.ContactTypeId,
                    LanguageId = l.LanguageId
                }).ToList(),
                Audits = d.Audits?.Select(a => new ContactTypeAuditDto
                {
                    Id = a.Id,
                    ContactTypeId = a.ContactTypeId,
                    Name = a.Name,
                    Description = a.Description,
                    Code = a.Code,
                    Dail = a.Dail,
                    IsDefault = a.IsDefault,
                    StatusId = a.StatusId,
                    Browser = a.Browser,
                    Location = a.Location,
                    IP = a.IP,
                    OS = a.OS,
                    MapURL = a.MapURL,
                    Latitude = a.Latitude,
                    Longitude = a.Longitude,
                    ActionTypeId = a.ActionTypeId,
                    ActionUserId = a.ActionUserId,
                    ActionUserAt = a.ActionUserAt
                }).ToList()
            }).ToList();

            return Ok(new { TotalCount = pagedData.TotalCount, Data = result });
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle([FromQuery] long id)
        {
            var response = await _contactTypeService.GetByIdAsync(id);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var entity = response.Data as ContactTypeEntity;
            if (entity == null)
                return NotFound("ContactType not found");

            var dto = new ContactTypeDetailDto
            {
                Id = entity.Id,
                ContactType = entity.ContactType,
                Description = entity.Description
            };
                
            return Ok(dto);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle([FromBody] ContactTypeCreateUpdateDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new ContactTypeEntity
            {
                ContactType = dto.ContactType,
                Description = dto.Description,
                Localizations = dto.Localizations?.Select(l => new ContactTypeLocalizationEntity
                {
                    LanguageId = l.LanguageId,
                    ContactTypeId = l.ContactTypeId
                }).ToList()
            };

            var response = await _contactTypeService.CreateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, Id = ((ContactTypeEntity)response.Data).Id });
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk([FromBody] List<ContactTypeCreateUpdateDto> dtos, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entities = dtos.Select(dto => new ContactTypeEntity
            {
                ContactType = dto.ContactType,
                Description = dto.Description
            }).ToList();

            var response = await _contactTypeService.CreateBulkAsync(entities, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, CreatedCount = response.Data });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] ContactTypeCreateUpdateDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entity = new ContactTypeEntity
            {
                Id = dto.Id ?? 0,
                ContactType = dto.ContactType,
                Description = dto.Description,
                Localizations = dto.Localizations?.Select(l => new ContactTypeLocalizationEntity
                {
                    ContactTypeId = dto.Id,
                    LanguageId = l.LanguageId
                }).ToList()
            };

            var response = await _contactTypeService.UpdateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] long id, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var response = await _contactTypeService.DeleteAsync(id, userId, language);

            if (!response.IsSuccess)
            {
                return response.StatusCode switch
                {
                    "404" => NotFound(new { success = false, message = response.Message }),
                    "500" => StatusCode(500, new { success = false, message = response.Message }),
                    _ => StatusCode(int.Parse(response.StatusCode), new { success = false, message = response.Message })
                };
            }

            return Ok(new { success = true, message = response.Message });
        }

        [HttpGet("GetAllTemplateData")]
        public async Task<IActionResult> GetAllTemplateData()
        {
            var response = await _contactTypeService.GetTemplateDataAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllGallery")]
        public async Task<IActionResult> GetAllGallery()
        {
            var response = await _contactTypeService.GetAllGalleryAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits([FromQuery] long contactTypeId)
        {
            var response = await _contactTypeService.GetAllAuditsAsync(contactTypeId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var audits = response.Data as IEnumerable<ContactTypeAuditEntity>;
            var result = audits?.Select(a => new ContactTypeAuditDto
            {
                Id = a.Id,
                ContactTypeId = a.ContactTypeId,
                Name = a.Name,
                Description = a.Description,
                Code = a.Code,
                Dail = a.Dail,
                IsDefault = a.IsDefault,
                StatusId = a.StatusId,
                Browser = a.Browser,
                Location = a.Location,
                IP = a.IP,
                OS = a.OS,
                MapURL = a.MapURL,
                Latitude = a.Latitude,
                Longitude = a.Longitude,
                ActionTypeId = a.ActionTypeId,
                ActionUserId = a.ActionUserId,
                ActionUserAt = a.ActionUserAt
            });

            return Ok(result);
        }
    }
}
