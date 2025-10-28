using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.DocumentType
{
    public class DocumentCodeTemplate
    {
        [Key]
        public int Id { get; set; }

        [StringLength(10)]
        public string? Code { get; set; }  

        [StringLength(100)]
        public string? Name { get; set; }  

        public bool? IsActive { get; set; }

      
        public virtual ICollection<DocumentTypeEntity>? DocumentTypes { get; set; }
    }
}
