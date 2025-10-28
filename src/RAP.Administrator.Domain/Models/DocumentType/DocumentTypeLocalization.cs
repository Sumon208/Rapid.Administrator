using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.DocumentType
{
    public class DocumentTypeLocalization
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("DocumentType")]
        public int? DocumentTypeId { get; set; }

      
        public int? LanguageId { get; set; }

        [StringLength(100)]
        public string? Name { get; set; }

        public virtual DocumentTypeEntity? DocumentType { get; set; }
    }
}
