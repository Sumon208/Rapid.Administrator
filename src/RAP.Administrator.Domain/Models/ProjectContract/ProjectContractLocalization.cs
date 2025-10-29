using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.ProjectContract
{
    public class ProjectContractLocalization
    {
        [Key]
        public int Id { get; set; }                     

        public int? ProjectContractId { get; set; }
       

        public int? LanguageId { get; set; }

        [MaxLength(500)]
        public string? Name { get; set; }

        public virtual ProjectContractEntity? ProjectContract { get; set; }
    }
}
