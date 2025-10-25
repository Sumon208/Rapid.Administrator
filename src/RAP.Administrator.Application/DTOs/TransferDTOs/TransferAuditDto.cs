using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.TransferDTOs
{
    public class TransferAuditDto
    {

        public int Id { get; set; }
        public int TransferId { get; set; }
        public string? ActionType { get; set; }
        public string? ChangedBy { get; set; }
        public DateTime? ChangedDate { get; set; }
        public string? PreviousValue { get; set; }
        public string? NewValue { get; set; }
    }
}
