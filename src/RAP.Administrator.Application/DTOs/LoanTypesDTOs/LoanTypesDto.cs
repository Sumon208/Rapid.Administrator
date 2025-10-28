using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.LoanTypesDTOs
{
    public class LoanTypeDto
    {
        public int Id { get; set; }
        public string? LoanTypeText { get; set; }
        public string? Description { get; set; }
        public bool? IsDefault { get; set; }
        public bool? Draft { get; set; }
    }
}
