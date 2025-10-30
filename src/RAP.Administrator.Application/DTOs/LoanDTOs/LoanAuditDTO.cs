using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.LoanDTOs
{
    public class LoanAuditDTO
    {
        public int Id { get; set; }
        public int? LoanId { get; set; }

        public string? Code { get; set; }
        public string? Dail { get; set; }
        public string? Name { get; set; }
        public bool? IsDefault { get; set; }
        public bool? StatusId { get; set; }
        public string? Browser { get; set; }
        public string? Location { get; set; }
        public string? IP { get; set; }
        public string? OS { get; set; }
        public string? MapURL { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int? ActionTypeId { get; set; }
        public int? ActionUserId { get; set; }
        public DateTime? ActionUserAt { get; set; }
    }
}
