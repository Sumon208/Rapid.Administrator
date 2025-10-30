using Microsoft.AspNetCore.Mvc;
using RAP.Administrator.Application.DTOs.DivisionDTOs;
using RAP.Administrator.Application.DTOs.LoanDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.Loan;

namespace RAP.Administrator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoansService _loanService;

        public LoanController(ILoansService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] string language = "en", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _loanService.GetAllAsync(language, pageNumber, pageSize);

            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var pagedData = response.Data as PagedLoansResponse;

            if (pagedData == null)
                return StatusCode(500, "Invalid data format");

            var result = ((IEnumerable<LoanEntity>)pagedData.Data).Select(l => new LoanGetAllDTO
            {
                Id = l.Id,
              
                Branch = l.Branch,
                IqmaId=l.IqmaId,
                PermittedById=l.PermittedById,
                RepaymentFrom=l.RepaymentFrom,
                ApprovedDate=l.ApprovedDate,
                Amount = l.Amount,
                LoanStatus = l.LoanStatus,
                IsDefault = l.IsDefault,
                IsDraft = l.IsDraft,
                Localizations = l.Localizations?.Select(loc => new LoanLocalizationDTO
                {
                    Id = loc.Id,
                    LoanId = loc.LoanId,
                    LanguageId = loc.LanguageId,
                    Name = loc.Name
                }).ToList(),
                Audits = l.Audits?.Select(a => new LoanAuditDTO
                {
                    Id = a.Id,
                    LoanId = a.LoanId,
                    ActionUserId = a.ActionUserId,
                    ActionUserAt = a.ActionUserAt,
                    ActionTypeId = a.ActionTypeId,
                    IsDefault = a.IsDefault
                }).ToList()
            }).ToList();

            return Ok(new { TotalCount = pagedData.TotalCount, Data = result });
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle([FromQuery] long id)
        {
            var response = await _loanService.GetByIdAsync(id);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var loan = response.Data as LoanEntity;
            if (loan == null)
                return NotFound("Loan not found");

            var dto = new LoanGetDTO
            {
                Id = loan.Id,
                Date = loan.Date,
                ApprovedDate = loan.ApprovedDate,
                RepaymentFrom = loan.RepaymentFrom,
                IqmaId = loan.IqmaId,
        
                Branch = loan.Branch,
                PermittedById = loan.PermittedById,
             
                Amount = loan.Amount,
                InterestPercentage = loan.InterestPercentage,
                InstallmentPeriod = loan.InstallmentPeriod,
                RepaymentAmount = loan.RepaymentAmount,
                Installment = loan.Installment,
                LoanDetails = loan.LoanDetails,
                LoanStatus = loan.LoanStatus,
                IsDefault = loan.IsDefault,
                IsDraft = loan.IsDraft,
                Localizations = loan.Localizations?.Select(l => new LoanLocalizationDTO
                {
                    Id = l.Id,
                    LoanId = l.LoanId,
                    LanguageId = l.LanguageId,
                    Name = l.Name
                }).ToList(),
               
            };

            return Ok(dto);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle([FromBody] LoanCreateDTO dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new LoanEntity
            {
                Date = dto.Date,
                ApprovedDate = dto.ApprovedDate,
                RepaymentFrom = dto.RepaymentFrom,
                IqmaId = dto.IqmaId,
                Branch = dto.Branch,
                PermittedById = dto.PermittedById,
                Amount = dto.Amount,
                InterestPercentage = dto.InterestPercentage,
                InstallmentPeriod = dto.InstallmentPeriod,
                RepaymentAmount = dto.RepaymentAmount,
                Installment = dto.Installment,
                LoanDetails = dto.LoanDetails,
                LoanStatus = dto.LoanStatus,
                IsDefault = dto.IsDefault,
                IsDraft = dto.IsDraft,
                Localizations = dto.Localizations?.Select(l => new LoanLocalization
                {
                    LoanId = l.LoanId,
                    LanguageId = l.LanguageId,
                    Name = l.Name
                }).ToList(),
               
            };

            var response = await _loanService.CreateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, Id = ((LoanEntity)response.Data).Id });
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk([FromBody] List<LoanCreateDTO> dtos, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entities = dtos.Select(dto => new LoanEntity
            {
                Date = dto.Date,
                ApprovedDate = dto.ApprovedDate,
                RepaymentFrom = dto.RepaymentFrom,
                IqmaId = dto.IqmaId,
                Branch = dto.Branch,
                PermittedById = dto.PermittedById,
                Amount = dto.Amount,
                InterestPercentage = dto.InterestPercentage,
                InstallmentPeriod = dto.InstallmentPeriod,
                RepaymentAmount = dto.RepaymentAmount,
                Installment = dto.Installment,
                LoanDetails = dto.LoanDetails,
                LoanStatus = dto.LoanStatus,
                IsDefault = dto.IsDefault,
                IsDraft = dto.IsDraft,
                Localizations = dto.Localizations?.Select(l => new LoanLocalization
                {
                    LoanId = l.LoanId,
                    LanguageId = l.LanguageId,
                    Name = l.Name
                }).ToList(),
               
            }).ToList();

            var response = await _loanService.CreateBulkAsync(entities, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, CreatedCount = response.Data });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] LoanUpdateDTO dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entity = new LoanEntity
            {
                Id = dto.Id,
                Date = dto.Date,
                ApprovedDate = dto.ApprovedDate,
                RepaymentFrom = dto.RepaymentFrom,
                IqmaId = dto.IqmaId,
                Branch = dto.Branch,
                PermittedById = dto.PermittedById,
                Amount = dto.Amount,
                InterestPercentage = dto.InterestPercentage,
                InstallmentPeriod = dto.InstallmentPeriod,
                RepaymentAmount = dto.RepaymentAmount,
                Installment = dto.Installment,
                LoanDetails = dto.LoanDetails,
                LoanStatus = dto.LoanStatus,
                IsDefault = dto.IsDefault,
                IsDraft = dto.IsDraft,
                Localizations = dto.Localizations?.Select(l => new LoanLocalization
                {
                    Id = (int)l.Id,
                    LoanId = dto.Id,
                    LanguageId = l.LanguageId,
                    Name = l.Name
                }).ToList(),
              
            };

            var response = await _loanService.UpdateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] long id, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var response = await _loanService.DeleteAsync(id, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpGet("GetAllTemplateData")]
        public async Task<IActionResult> GetAllTemplateData()
        {
            var response = await _loanService.GetTemplateDataAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllGallery")]
        public async Task<IActionResult> GetAllGallery()
        {
            var response = await _loanService.GetAllGalleryAsync();
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(response.Data);
        }

        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits([FromQuery] long loanId)
        {
            var response = await _loanService.GetAllAuditsAsync(loanId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var audits = response.Data as IEnumerable<LoanAudit>;
            var result = audits?.Select(a => new LoanAuditDTO
            {
                Id = a.Id,
                LoanId = a.LoanId,
                ActionUserId = a.ActionUserId,
                ActionUserAt = a.ActionUserAt,
                ActionTypeId = a.ActionTypeId,
                IsDefault = a.IsDefault
            });

            return Ok(result);
        }
    }
}
