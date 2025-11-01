using RAP.Administrator.Domain.Models.SampleCategory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.SampleCategoryDTOs
{
    public class SampleCategoryLocalizationDTO
    {
        [Key]
        public int Id { get; set; }

        public int? LanguageId { get; set; }

        public int? CategoryId { get; set; }

        [MaxLength(250)]
        public string? Name { get; set; }

      
    }
}
