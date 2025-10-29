using Microsoft.AspNetCore.Mvc;
using RAP.Administrator.Application.DTOs.EmployeeContractDTOs;
using RAP.Administrator.Application.DTOs.Shared;
using RAP.Administrator.Application.Interfaces.Services;
using RAP.Administrator.Domain.Models.EmployeeContract;

namespace RAP.Administrator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeContractController : ControllerBase
    {
        private readonly IEmployeeContractService _employeeContractService;

        public EmployeeContractController(IEmployeeContractService employeeContractService)
        {
            _employeeContractService = employeeContractService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] string language = "en", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _employeeContractService.GetAllAsync(language, pageNumber, pageSize);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var pagedData = response.Data as PagedEmployeeContractResponse;
            if (pagedData == null)
                return StatusCode(500, "Invalid data format");

            var result = pagedData.Data.Select(c => new EmployeeContractGetAllDto
            {
                Id = c.Id,
                ContactTypeId = c.ContactTypeId,
                StatusId = c.StatusId,
                SalaryAllowanceId = c.SalaryAllowanceId,
                StaffId = c.StaffId,
                Localizations = c.Localizations?.Select(l => new EmployeeContractLocalizationDto
                {
                    EmployeeContractId = l.EmployeeContractId,
                    LanguageId = l.LanguageId,
                    Name = l.Name
                }).ToList(),
                Audits = c.Audits?.Select(a => new EmployeeContractAuditDto
                {
                    EmployeeContractId = a.EmployeeContractId,
                    ActionUserId = a.ActionUserId,
                    ActionUserAt = a.ActionUserAt,
                    StatusId = a.StatusId
                }).ToList()
            }).ToList();

            return Ok(new { TotalCount = pagedData.TotalCount, Data = result });
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle([FromQuery] long id)
        {
            var response = await _employeeContractService.GetByIdAsync(id);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var contract = response.Data as EmployeeContractEntity;
            if (contract == null)
                return NotFound("Employee contract not found");

            var dto = new EmployeeContractGetSingleDto
            {
                Id = contract.Id,
                ContactTypeId = contract.ContactTypeId,
                StatusId = contract.StatusId,
                SalaryAllowanceId = contract.SalaryAllowanceId,
                StaffId = contract.StaffId,
               
            };

            return Ok(dto);
        }

        [HttpPost("CreateSingle")]
        public async Task<IActionResult> CreateSingle([FromBody] EmployeeContractCreateDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new EmployeeContractEntity
            {
                ContactTypeId = dto.ContactTypeId,
                StatusId = dto.StatusId,
                SalaryAllowanceId = dto.SalaryAllowanceId,
                StaffId = dto.StaffId,
                Localizations = dto.Localizations?.Select(l => new EmployeeContractLocalization
                {
                    EmployeeContractId = l.EmployeeContractId,
                    LanguageId = l.LanguageId,
                    Name = l.Name
                }).ToList()
            };

            var response = await _employeeContractService.CreateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, Id = ((EmployeeContractEntity)response.Data).Id });
        }

        [HttpPost("CreateBulk")]
        public async Task<IActionResult> CreateBulk([FromBody] List<EmployeeContractCreateDto> dtos, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entities = dtos.Select(dto => new EmployeeContractEntity
            {
                ContactTypeId = dto.ContactTypeId,
                StatusId = dto.StatusId,
                SalaryAllowanceId = dto.SalaryAllowanceId,
                StaffId = dto.StaffId
            }).ToList();

            var response = await _employeeContractService.CreateBulkAsync(entities, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message, CreatedCount = response.Data });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] EmployeeContractUpdateDto dto, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var entity = new EmployeeContractEntity
            {
                Id = dto.Id,
                ContactTypeId = dto.ContactTypeId,
                StatusId = dto.StatusId,
                SalaryAllowanceId = dto.SalaryAllowanceId,
                StaffId = dto.StaffId,
                Localizations = dto.Localizations?.Select(l => new EmployeeContractLocalization
                {
                    EmployeeContractId = dto.Id,
                    LanguageId = l.LanguageId,
                    Name = l.Name
                }).ToList()
            };

            var response = await _employeeContractService.UpdateAsync(entity, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] long id, [FromQuery] int userId, [FromQuery] string language = "en")
        {
            var response = await _employeeContractService.DeleteAsync(id, userId, language);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            return Ok(new { Message = response.Message });
        }

        [HttpGet("GetAllAudits")]
        public async Task<IActionResult> GetAllAudits([FromQuery] long contractId)
        {
            var response = await _employeeContractService.GetAllAuditsAsync(contractId);
            if (!response.IsSuccess)
                return StatusCode(int.Parse(response.StatusCode), response.Message);

            var audits = response.Data as IEnumerable<EmployeeContractAudit>;
            var result = audits?.Select(a => new EmployeeContractAuditDto
            {
                EmployeeContractId = a.EmployeeContractId,
                ActionUserId = a.ActionUserId,
                ActionUserAt = a.ActionUserAt,
                StatusId = a.StatusId
            });

            return Ok(result);
        }
    }
}
