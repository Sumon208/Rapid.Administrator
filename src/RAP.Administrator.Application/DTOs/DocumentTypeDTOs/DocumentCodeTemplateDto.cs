using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.DocumentTypeDTOs
{
    public class DocumentCodeTemplateDto
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string? Code { get; set; }

        [StringLength(100)]
        public string? Name { get; set; }

        public bool? IsActive { get; set; }
    }
}
