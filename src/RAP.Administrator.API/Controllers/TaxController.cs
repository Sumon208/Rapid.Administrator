using Microsoft.AspNetCore.Mvc;
using RAP.Administrator.Application.DTOs;
using RAP.Administrator.Application.DTOs.DivisionDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models;
using RAP.Administrator.Infrastructure.Services;
using System.Linq;
using System.Threading.Tasks;

namespace RAP.Administrator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxController : ControllerBase
    {
        private readonly ITaxService _taxService;

        public TaxController(ITaxService taxService)
        {
            _taxService = taxService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] string language = "en", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _taxService.GetAllAsync(language, pageNumber, pageSize);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle([FromQuery] int id)
        {
            var response = await _taxService.GetByIdAsync(id);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle([FromBody] TaxCreateDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(new RequestResponse
                {
                    StatusCode = "400",
                    Message = "Invalid data",
                    IsSuccess = false
                });

            var entity = new TaxEntity
            {
                BankName = dto.BankName,
                AccountNumber = dto.AccountNumber,
                BranchName = dto.BranchName,
                IBANNumber = dto.IBANNumber,
                OpeningBalance = dto.OpeningBalance,
                Address = dto.Address,
                BankDetails = dto.BankDetails,
                IsDefault = dto.IsDefault,
                IsActive = dto.IsActive,
                IsDraft = dto.IsDraft
            };

            var response = await _taxService.CreateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new
            {
                Message = response.Message,
                Id = ((TaxEntity)response.Data).Id
            });
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk([FromBody] List<TaxCreateDto> dtos, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entities = dtos.Select(dto => new TaxEntity
            {
                BankName = dto.BankName,
                AccountNumber = dto.AccountNumber,
                BranchName = dto.BranchName,
                IBANNumber = dto.IBANNumber,
                OpeningBalance = dto.OpeningBalance,
                Address = dto.Address,
                BankDetails = dto.BankDetails,
                IsDefault = dto.IsDefault,
                IsActive = dto.IsActive,
                IsDraft = dto.IsDraft
            }).ToList();

            var response = await _taxService.CreateBulkAsync(entities, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, CreatedCount = response.Data });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] TaxUpdateDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var response = await _taxService.UpdateAsync(dto, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, Id = dto.Id });
        }


        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int id, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var response = await _taxService.DeleteAsync(id, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpGet("GetAllTemplateData")]
        public async Task<IActionResult> GetAllTemplateData()
        {
            var response = await _taxService.GetTemplateDataAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllGallery")]
        public async Task<IActionResult> GetAllGallery()
        {
            var response = await _taxService.GetAllGalleryAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }


        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits([FromQuery] int taxId)
        {
            var response = await _taxService.GetAllAuditsAsync(taxId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }
    }
}
