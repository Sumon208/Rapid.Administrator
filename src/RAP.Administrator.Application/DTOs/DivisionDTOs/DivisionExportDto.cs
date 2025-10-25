using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.DivisionDTOs
{
    public class DivisionExportDto
    {
        public long? DivisionId { get; set; }
        public string? Description { get; set; } = string.Empty;

        public bool? IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public long? DeletedBy { get; set; }
    }
}
