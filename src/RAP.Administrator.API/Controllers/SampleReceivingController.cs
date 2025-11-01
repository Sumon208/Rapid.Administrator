using Microsoft.AspNetCore.Mvc;
using RAP.Administrator.Application.DTOs.SampleReceivingDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.SampleReceiving;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAP.Administrator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleReceivingController : ControllerBase
    {
        private readonly ISampleReceivingService _sampleReceivingService;

        public SampleReceivingController(ISampleReceivingService sampleReceivingService)
        {
            _sampleReceivingService = sampleReceivingService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] string language = "en", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _sampleReceivingService.GetAllAsync(language, pageNumber, pageSize);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var pagedData = response.Data as PaginatedSampleReceivingListDTO;
            if (pagedData == null)
                return StatusCode(500, "Invalid data format");

            var result = pagedData.Data.Select(d => new SampleReceivingListDTO
            {
                Id = d.Id,
                ReceivingNo = d.ReceivingNo,
                CustomerName = d.CustomerName,
                CustomerReference = d.CustomerReference,
                TypeOfSample = d.TypeOfSample,
                RequiredTests = d.RequiredTests,
                NumberOfSample = d.NumberOfSample,
                Date = d.Date,
                Time = d.Time,
              
                SectionName = d.Section?.Name,
                DeliveredByName = d.DeliveredBy?.Name,
                ReceivedByName = d.ReceivedBy?.Name
            }).ToList();

            return Ok(new { TotalCount = pagedData.TotalCount, Data = result });
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle([FromQuery] int id)
        {
            var response = await _sampleReceivingService.GetByIdAsync(id);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var entity = response.Data as SampleReceivingEntity;
            if (entity == null)
                return NotFound("Sample Receiving not found");

            var dto = new SampleReceivingCreateDTO
            {
                BranchId = entity.BranchId,
                CustomerId = entity.CustomerId,
                SectionId = entity.SectionId,
                DeliveredById = entity.DeliveredById,
                ReceivedById = entity.ReceivedById,
                ReceivingNo = entity.ReceivingNo,
                CustomerName = entity.CustomerName,
                CustomerReference = entity.CustomerReference,
                TypeOfSample = entity.TypeOfSample,
                RequiredTests = entity.RequiredTests,
                NumberOfSample = entity.NumberOfSample,
                Date = entity.Date,
                Time = entity.Time,
                OtherNotes = entity.OtherNotes,
                Localizations = entity.Localizations?.Select(l => new SampleReceivedLocalizationDTO
                {
                    Id = l.Id,
                    LanguageId = l.LanguageId,
                    ReceivedId = l.ReceivedId,
                    Name = l.Name
                }).ToList()
            };

            return Ok(dto);
        }


        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle([FromBody] SampleReceivingCreateDTO dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new SampleReceivingEntity
            {
                BranchId = dto.BranchId,
                CustomerId = dto.CustomerId,
                SectionId = dto.SectionId,
                DeliveredById = dto.DeliveredById,
                ReceivedById = dto.ReceivedById,
                ReceivingNo = dto.ReceivingNo,
                CustomerName = dto.CustomerName,
                CustomerReference = dto.CustomerReference,
                TypeOfSample = dto.TypeOfSample,
                RequiredTests = dto.RequiredTests,
                NumberOfSample = dto.NumberOfSample,
                Date = dto.Date,
                Time = dto.Time,
                OtherNotes = dto.OtherNotes,
                Localizations = dto.Localizations?.Select(l => new SampleReceivedLocalizationEntity
                {
                    LanguageId = l.LanguageId,
                    ReceivedId = l.ReceivedId,
                    Name = l.Name
                }).ToList()
            };

            var response = await _sampleReceivingService.CreateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, Id = ((SampleReceivingEntity)response.Data).Id });
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk([FromBody] SampleReceivingBulkCreateDTO dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entities = dto.Items.Select(item => new SampleReceivingEntity
            {
                BranchId = item.BranchId,
                CustomerId = item.CustomerId,
                SectionId = item.SectionId,
                DeliveredById = item.DeliveredById,
                ReceivedById = item.ReceivedById,
                ReceivingNo = item.ReceivingNo,
                CustomerName = item.CustomerName,
                CustomerReference = item.CustomerReference,
                TypeOfSample = item.TypeOfSample,
                RequiredTests = item.RequiredTests,
                NumberOfSample = item.NumberOfSample,
                Date = item.Date,
                Time = item.Time,
                OtherNotes = item.OtherNotes,
                Localizations = item.Localizations?.Select(l => new SampleReceivedLocalizationEntity
                {
                    LanguageId = l.LanguageId,
                    ReceivedId = l.ReceivedId,
                    Name = l.Name
                }).ToList()
            }).ToList();

            var response = await _sampleReceivingService.CreateBulkAsync(entities, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, CreatedCount = response.Data });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] SampleReceivingUpdateDTO dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entity = new SampleReceivingEntity
            {
                Id = dto.Id,
                BranchId = dto.BranchId,
                CustomerId = dto.CustomerId,
                SectionId = dto.SectionId,
                DeliveredById = dto.DeliveredById,
                ReceivedById = dto.ReceivedById,
                ReceivingNo = dto.ReceivingNo,
                CustomerName = dto.CustomerName,
                CustomerReference = dto.CustomerReference,
                TypeOfSample = dto.TypeOfSample,
                RequiredTests = dto.RequiredTests,
                NumberOfSample = dto.NumberOfSample,
                Date = dto.Date,
                Time = dto.Time,
                OtherNotes = dto.OtherNotes,
                Localizations = dto.Localizations?.Select(l => new SampleReceivedLocalizationEntity
                {
                    Id = l.Id,
                    LanguageId = l.LanguageId,
                    ReceivedId = l.ReceivedId,
                    Name = l.Name
                }).ToList()
            };

            var response = await _sampleReceivingService.UpdateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var response = await _sampleReceivingService.DeleteAsync(id, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpGet("GetTemplateData")]
        public async Task<IActionResult> GetTemplateData()
        {
            var response = await _sampleReceivingService.GetTemplateDataAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllGallery")]
        public async Task<IActionResult> GetAllGallery()
        {
            var response = await _sampleReceivingService.GetAllGalleryAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits([FromQuery] int sampleReceivingId)
        {
            var response = await _sampleReceivingService.GetAllAuditsAsync(sampleReceivingId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var audits = response.Data as IEnumerable<SampleReceivedAuditEntity>;
            return Ok(audits);
        }
    }
}
