using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.ProjectContract
{
    public class ProjectContractExport
    {
        [Key]
        public int Id { get; set; }

        public int? ProjectContractId { get; set; }
       

        [MaxLength(260)]
        public string? FileName { get; set; }

        [MaxLength(100)]
        public string? FileType { get; set; }            

        [MaxLength(1000)]
        public string? FileUrl { get; set; }            

        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }

        public virtual ProjectContractEntity? ProjectContract { get; set; }


    }
}
