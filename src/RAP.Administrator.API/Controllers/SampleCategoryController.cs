using Microsoft.AspNetCore.Mvc;
using RAP.Administrator.Application.DTOs.SampleCategoryDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.SampleCategory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAP.Administrator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleCategoryController : ControllerBase
    {
        private readonly ISampleCategoryService _sampleCategoryService;

        public SampleCategoryController(ISampleCategoryService sampleCategoryService)
        {
            _sampleCategoryService = sampleCategoryService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] string language = "en", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _sampleCategoryService.GetAllAsync(language, pageNumber, pageSize);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var pagedData = response.Data as PagedSampleCategoryResponse;
            if (pagedData == null)
                return StatusCode(500, "Invalid data format");

            var result = pagedData.Data.Select(d => new SampleCategoryCreateDTO
            {
                Id = d.Id,
                CategoryName = d.CategoryName,
                Description = d.Description,
                Localizations = d.Localizations?.Select(l => new SampleCategoryLocalizationDTO
                {
                    LanguageId = l.LanguageId,
                    CategoryId = l.CategoryId,
                    Name = l.Name
                }).ToList(),
                Audits = d.Audits?.Select(a => new SampleCategoryAuditDTO
                {
                    Id = a.Id,
                    CategoryId = a.CategoryId,
                    ActionTypeId = a.ActionTypeId,
                    ActionUserId = a.ActionUserId,
                    ActionUserAt = a.ActionUserAt,
                    StatusId = a.StatusId,
                    Code = a.Code,
                    Name = a.Name,
                    Dail = a.Dail,
                    Browser = a.Browser,
                    IP = a.IP,
                    OS = a.OS,
                    Location = a.Location,
                    MapURL = a.MapURL,
                    Latitude = a.Latitude,
                    Longitude = a.Longitude
                }).ToList()
            }).ToList();
          

            return Ok(new { TotalCount = pagedData.TotalCount, Data = result });
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle([FromQuery] int id)
        {
            var response = await _sampleCategoryService.GetByIdAsync(id);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var category = response.Data as SampleCategoryEntity;
            if (category == null)
                return NotFound("Sample category not found");

            var dto = new SampleCategoryListDTO
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                Description = category.Description,
             
            };

            return Ok(dto);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle([FromBody] SampleCategoryCreateDTO dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new SampleCategoryEntity
            {
                CategoryName = dto.CategoryName,
                Description = dto.Description,
                StatusTypeId = dto.StatusTypeId,
                Localizations = dto.Localizations?.Select(l => new SampleCategoryLocalization
                {
                    LanguageId = l.LanguageId,
                    CategoryId = l.CategoryId,
                    Name = l.Name
                }).ToList()
            };

            var response = await _sampleCategoryService.CreateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, Id = ((SampleCategoryEntity)response.Data).Id });
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk([FromBody] SampleCategoryBulkCreateDTO bulkDto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entities = bulkDto.Items.Select(dto => new SampleCategoryEntity
            {
                CategoryName = dto.CategoryName,
                Description = dto.Description,
                StatusTypeId = dto.StatusTypeId,
                Localizations = dto.Localizations?.Select(l => new SampleCategoryLocalization
                {
                    LanguageId = l.LanguageId,
                    CategoryId = l.CategoryId,
                    Name = l.Name
                }).ToList()
            }).ToList();

            var response = await _sampleCategoryService.CreateBulkAsync(entities, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, CreatedCount = response.Data });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] SampleCategoryUpdateDTO dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entity = new SampleCategoryEntity
            {
                Id = dto.Id,
                CategoryName = dto.CategoryName,
                Description = dto.Description,
                Localizations = dto.Localizations?.Select(l => new SampleCategoryLocalization
                {
                    LanguageId = l.LanguageId,
                    CategoryId = l.CategoryId,
                    Name = l.Name
                }).ToList()
            };

            var response = await _sampleCategoryService.UpdateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var response = await _sampleCategoryService.DeleteAsync(id, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpGet("GetAllTemplateData")]
        public async Task<IActionResult> GetAllTemplateData()
        {
            var response = await _sampleCategoryService.GetTemplateDataAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllGallery")]
        public async Task<IActionResult> GetAllGallery()
        {
            var response = await _sampleCategoryService.GetAllGalleryAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits([FromQuery] int sampleCategoryId)
        {
            var response = await _sampleCategoryService.GetAllAuditsAsync(sampleCategoryId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var audits = response.Data as IEnumerable<SampleCategoryAudit>;
            var result = audits?.Select(a => new SampleCategoryAuditDTO
            {
                Id = a.Id,
                CategoryId = a.CategoryId,
                ActionTypeId = a.ActionTypeId,
                ActionUserId = a.ActionUserId,
                ActionUserAt = a.ActionUserAt,
                StatusId = a.StatusId,
                Code = a.Code,
                Name = a.Name,
                Dail = a.Dail,
                Browser = a.Browser,
                IP = a.IP,
                OS = a.OS,
                Location = a.Location,
                MapURL = a.MapURL,
                Latitude = a.Latitude,
                Longitude = a.Longitude
            }).ToList();

            return Ok(result);
        }
    }
}
