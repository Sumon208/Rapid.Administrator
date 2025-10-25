using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.TransferDTOs
{
    public class TransferLocalizationDto
    {
        public int Id { get; set; }
        public int? TransferId { get; set; }
        public string? Language { get; set; } = "en";
        public string? Descriptions { get; set; }
    }
}
