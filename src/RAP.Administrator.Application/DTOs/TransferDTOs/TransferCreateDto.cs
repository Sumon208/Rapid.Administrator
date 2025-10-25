using RAP.Administrator.Application.DTOs.InsuranceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.TransferDTOs
{
    public class TransferCreateDto
    {
        public string? IqamaNo { get; set; }
        public int? BranchId { get; set; }
        public int? FromLocationId { get; set; }
        public int? ToLocationId { get; set; }
        public DateTime? TransferDate { get; set; }

        public string? Descriptions { get; set; }

        public ICollection<TransferLocalizationDto>? Localizations { get; set; }
        public ICollection<TransferAuditDto>? Audits { get; set; }
    }
}
