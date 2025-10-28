using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.DocumentTypeDTOs
{
    public class DocumentTypeLocalizationDto
    {
        public int? Id { get; set; }

        public int? LanguageId { get; set; }

        [StringLength(100)]
        public string? Name { get; set; }
    }
}
