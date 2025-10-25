using Microsoft.AspNetCore.Mvc;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.DTOs.TransferDTOs;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.Transfer;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using RAP.Administrator.Application.DTOs.TransferDTOs.RAP.Administrator.Application.DTOs.TransferDTOs;
using RAP.Administrator.Domain.Models.Insurance;

namespace RAP.Administrator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;

        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] string language = "en", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _transferService.GetAllAsync(language, pageNumber, pageSize);

            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var pagedData = response.Data as PagedTransferResponse;
            if (pagedData == null)
                return StatusCode(500, "Invalid data format");

            var result = pagedData.Data.Select(t => new TransferDto
            {
                Id = t.Id,
                IqamaNo = t.IqamaNo,
                BranchId = t.BranchId,
                FromLocationId = t.FromLocationId,
                ToLocationId = t.ToLocationId,
                TransferDate = t.TransferDate,
                Descriptions = t.Descriptions,
                Localizations = t.Localizations?.Select(l => new TransferLocalizationDto
                {
                    Id = l.Id,
                    TransferId = l.TransferId ?? 0,
                    Language = l.LanguageId.HasValue ? l.LanguageId.ToString() : "en",
                    Descriptions = l.Description
                }).ToList(),
                Audits = t.Audits?.Select(a => new TransferAuditDto
                {
                    Id = a.Id,
                    TransferId = a.TransferId ?? 0,
                    ChangedDate = a.ActionAt,
                    PreviousValue = a.OldValuesJson,
                    NewValue = a.NewValuesJson,
                    ChangedBy = a.ActionUserId?.ToString(),
                    ActionType = a.ActionTypeId?.ToString()
                }).ToList()
            }).ToList();

            return Ok(new { TotalCount = pagedData.TotalCount, Data = result });
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle([FromQuery] int id)
        {
            var response = await _transferService.GetByIdAsync(id);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var transfer = response.Data as TransferEntity;
            if (transfer == null)
                return NotFound("Transfer not found");

            var dto = new TransferDto
            {
                Id = transfer.Id,
                IqamaNo = transfer.IqamaNo,
                BranchId = transfer.BranchId,
                FromLocationId = transfer.FromLocationId,
                ToLocationId = transfer.ToLocationId,
                TransferDate = transfer.TransferDate,
                Descriptions = transfer.Descriptions,
                Localizations = transfer.Localizations?.Select(l => new TransferLocalizationDto
                {
                    Id = l.Id,
                    TransferId = l.TransferId ?? 0,
                    Language = l.LanguageId.HasValue ? l.LanguageId.ToString() : "en",
                    Descriptions = l.Description
                }).ToList(),

                Audits = transfer.Audits?.Select(a => new TransferAuditDto
                {
                    Id = a.Id,
                    TransferId = a.TransferId ?? 0,
                    ChangedDate = a.ActionAt,
                    PreviousValue = a.OldValuesJson,
                    NewValue = a.NewValuesJson,
                    ChangedBy = a.ActionUserId?.ToString(),
                    ActionType = a.ActionTypeId?.ToString()
                }).ToList()
            };

            return Ok(dto);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle([FromBody] TransferDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new TransferEntity
            {
                IqamaNo = dto.IqamaNo,
                BranchId = dto.BranchId,
                FromLocationId = dto.FromLocationId,
                ToLocationId = dto.ToLocationId,
                TransferDate = dto.TransferDate,
                Descriptions = dto.Descriptions,
                Localizations = dto.Localizations?.Select(l => new TransferLocalization
                {
                    TransferId = l.TransferId,
                    LanguageId = int.TryParse(l.Language, out var langId) ? langId : 1, // default "en" = 1
                    Description = l.Descriptions
                }).ToList()
            };

            var response = await _transferService.CreateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, Id = ((TransferEntity)response.Data).Id });
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk([FromBody] List<TransferDto> dtos, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entities = dtos.Select(dto => new TransferEntity
            {
                IqamaNo = dto.IqamaNo,
                BranchId = dto.BranchId,
                FromLocationId = dto.FromLocationId,
                ToLocationId = dto.ToLocationId,
                TransferDate = dto.TransferDate,
                Descriptions = dto.Descriptions,
                Localizations = dto.Localizations?.Select(l => new TransferLocalization
                {
                    TransferId = l.TransferId,
                    LanguageId = int.TryParse(l.Language, out var langId) ? langId : 1,
                    Description = l.Descriptions
                }).ToList()
            }).ToList();

            var response = await _transferService.CreateBulkAsync(entities, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, CreatedCount = response.Data });
        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] TransferUpdateDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entity = new TransferEntity
            {
                Id = dto.Id,
                IqamaNo = dto.IqamaNo,
                BranchId = dto.BranchId,
                FromLocationId = dto.FromLocationId,
                ToLocationId = dto.ToLocationId,
                TransferDate = dto.TransferDate,
                Descriptions = dto.Descriptions
            };

            var response = await _transferService.UpdateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var response = await _transferService.DeleteAsync(id, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpGet("GetAllTemplateData")]
        public async Task<IActionResult> GetAllTemplateData()
        {
            var response = await _transferService.GetTemplateDataAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllGallery")]
        public async Task<IActionResult> GetAllGallery()
        {
            var response = await _transferService.GetAllGalleryAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits([FromQuery] int transferId)
        {
            var response = await _transferService.GetAllAuditsAsync(transferId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var audits = response.Data as IEnumerable<TransferAudit>;
            var result = audits?.Select(a => new TransferAuditDto
            {
                Id = a.Id,
                TransferId = a.TransferId ?? 0,
                ChangedDate = a.ActionAt,
                PreviousValue = a.OldValuesJson,
                NewValue = a.NewValuesJson,
                ChangedBy = a.ActionUserId?.ToString(),
                ActionType = a.ActionTypeId?.ToString()
            });

            return Ok(result);
        }
    }
}
