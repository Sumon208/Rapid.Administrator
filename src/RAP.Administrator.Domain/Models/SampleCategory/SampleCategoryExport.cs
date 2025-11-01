using RAP.Administrator.Domain.Models.SampleReceiving;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.SampleCategory
{
    public class SampleCategoryExport
    {
        [Key]
        public int Id { get; set; }

        public int? CategoryId { get; set; }

        [MaxLength(250)]
        public string? FileName { get; set; }

        [MaxLength(1000)]
        public string? FilePath { get; set; }

        public DateTime? ExportedAt { get; set; }


        public virtual SampleCategoryEntity? SampleCategories { get; set; }
    }
}
