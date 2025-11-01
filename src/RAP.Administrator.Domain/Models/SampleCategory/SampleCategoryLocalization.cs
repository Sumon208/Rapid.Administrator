using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.SampleCategory
{
    public class SampleCategoryLocalization
    {
        [Key]
        public int Id { get; set; }

        public int? LanguageId { get; set; }

        public int? CategoryId { get; set; }

        [MaxLength(250)]
        public string? Name { get; set; }

        public virtual SampleCategoryEntity? SampleCategories { get; set; }
    }

}
