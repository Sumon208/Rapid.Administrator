using Microsoft.AspNetCore.Mvc;

using RAP.Administrator.Application.DTOs.BranchesDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.Branches;

namespace RAP.Administrator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;
       
         
        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] string language = "en", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _branchService.GetAllAsync(language, pageNumber, pageSize);

            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var pagedData = response.Data as PagedBranchResponse;
            if (pagedData == null)
                return StatusCode(500, "Invalid data format");

            var result = pagedData.Data.Select(d => new BranchDto
            {
                Id = d.Id,
                BranchName = d.BranchName,
                BranchArabic = d.BranchArabic,
                VATNumber = d.VATNumber,
                Website = d.Website,
                Phone = d.Phone,
                CurrencySymbol = d.CurrencySymbol,
                City = d.City,
                State = d.State,
                PostCode = d.PostCode,
                PrintFormat = d.PrintFormat,
                InvoiceId = d.InvoiceId,
                Localizations = d.Localizations?.Select(l => new BranchLocalizationDto
                {
                    BranchId = l.BranchId,
                    LanguageId = l.LanguageId,
                    Name = l.Name,
                    AddressLocalized = l.AddressLocalized
                }).ToList(),
                Audits = d.Audits?.Select(a => new BranchAuditDto
                {
                    BranchId = a.BranchId,
                   
                    ActionUserId = a.ActionUserId,
                  
                }).ToList()
            }).ToList();

            return Ok(new { TotalCount = pagedData.TotalCount, Data = result });
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle([FromQuery] int id)
        {
            var response = await _branchService.GetByIdAsync(id);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var branch = response.Data as BranchEntity;
            if (branch == null)
                return NotFound("Branch not found");

            var dto = new BranchDto
            {
                Id = branch.Id,
                BranchName = branch.BranchName,
                BranchArabic = branch.BranchArabic,
                VATNumber = branch.VATNumber,
                Website = branch.Website,
                Phone = branch.Phone,
                CurrencySymbol = branch.CurrencySymbol,
                City = branch.City,
                State = branch.State,
                PostCode = branch.PostCode,
                PrintFormat = branch.PrintFormat,
                InvoiceId = branch.InvoiceId,
                Localizations = branch.Localizations?.Select(l => new BranchLocalizationDto
                {
                    BranchId = l.BranchId,
                    LanguageId = l.LanguageId,
                    Name = l.Name,
                    AddressLocalized = l.AddressLocalized
                }).ToList(),
                Audits = branch.Audits?.Select(a => new BranchAuditDto
                {
                    BranchId = a.BranchId,
                   
                    ActionUserId = a.ActionUserId,
                   
                }).ToList()
            };

            return Ok(dto);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle([FromBody] BranchDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new BranchEntity
            {
                BranchName = dto.BranchName,
                BranchArabic = dto.BranchArabic,
                VATNumber = dto.VATNumber,
                Website = dto.Website,
                Phone = dto.Phone,
                CurrencySymbol = dto.CurrencySymbol,
                City = dto.City,
                State = dto.State,
                PostCode = dto.PostCode,
                PrintFormat = dto.PrintFormat,
                InvoiceId = dto.InvoiceId,
                Localizations = dto.Localizations?.Select(l => new BranchLocalization
                {
                    LanguageId = l.LanguageId,
                    Name = l.Name,
                    AddressLocalized = l.AddressLocalized
                }).ToList()
            };

            var response = await _branchService.CreateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, Id = ((BranchEntity)response.Data).Id });
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk([FromBody] List<BranchDto> dtos, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entities = dtos.Select(dto => new BranchEntity
            {
                BranchName = dto.BranchName,
                BranchArabic = dto.BranchArabic,
                VATNumber = dto.VATNumber,
                Website = dto.Website,
                Phone = dto.Phone,
                CurrencySymbol = dto.CurrencySymbol,
                City = dto.City,
                State = dto.State,
                PostCode = dto.PostCode,
                PrintFormat = dto.PrintFormat,
                InvoiceId = dto.InvoiceId
            }).ToList();

            var response = await _branchService.CreateBulkAsync(entities, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, CreatedCount = response.Data });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] BranchDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entity = new BranchEntity
            {
                Id = dto.Id,
                BranchName = dto.BranchName,
                BranchArabic = dto.BranchArabic,
                VATNumber = dto.VATNumber,
                Website = dto.Website,
                Phone = dto.Phone,
                CurrencySymbol = dto.CurrencySymbol,
                City = dto.City,
                State = dto.State,
                PostCode = dto.PostCode,
                PrintFormat = dto.PrintFormat,
                InvoiceId = dto.InvoiceId,
                Localizations = dto.Localizations?.Select(l => new BranchLocalization
                {
                    BranchId = dto.Id,
                    LanguageId = l.LanguageId,
                    Name = l.Name,
                    AddressLocalized = l.AddressLocalized
                }).ToList()
            };

            var response = await _branchService.UpdateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var response = await _branchService.DeleteAsync(id, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpGet("GetAllTemplateData")]
        public async Task<IActionResult> GetAllTemplateData()
        {
            var response = await _branchService.GetTemplateDataAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllGallery")]
        public async Task<IActionResult> GetAllGallery()
        {
            var response = await _branchService.GetAllGalleryAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits([FromQuery] int branchId)
        {
            var response = await _branchService.GetAllAuditsAsync(branchId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var audits = response.Data as IEnumerable<BranchAuditEntity>;
            var result = audits?.Select(a => new BranchAuditDto
            {
                BranchId = a.BranchId,
               
                ActionUserId = a.ActionUserId,
               
            });

            return Ok(result);
        }
    }
}
