using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.DivisionDTOs
{
    public class DivisionAuditDto
    {
        public long DivisionId { get; set; }
        public short? ActionTypeId { get; set; }
        public string? ActionTypeName { get; set; }   // from ActionTypes table
        public long? ActionUserId { get; set; }
        public DateTime? ActionAt { get; set; }

        public bool IsDefault { get; set; }
        public short? StatusTypeId { get; set; }
    }
}
