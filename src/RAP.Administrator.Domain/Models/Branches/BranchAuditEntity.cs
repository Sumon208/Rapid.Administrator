using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.Branches
{
    public class BranchAuditEntity
    {
        public int Id { get; set; }

    
        public int? BranchId { get; set; }
        public BranchEntity? Branch { get; set; }


        [MaxLength(3)]
        public string? Code { get; set; }      

        [MaxLength(5)]
        public string? Dail { get; set; }       

        [MaxLength(40)]
        public string? Name { get; set; }       

        public bool? IsDefault { get; set; }

        public bool? StatusId { get; set; }

        [MaxLength(15)]
        public string? Browser { get; set; }

        [MaxLength(3)]
        public string? Location { get; set; }  

        [MaxLength(15)]
        public string? IP { get; set; }

        [MaxLength(15)]
        public string? OS { get; set; }

        [MaxLength(100)]
        public string? MapURL { get; set; }

        [Column(TypeName = "decimal(9,6)")]
        public decimal? Latitude { get; set; }

        [Column(TypeName = "decimal(9,6)")]
        public decimal? Longitude { get; set; }

        public int? ActionTypeId { get; set; } 
        public int? ActionUserId { get; set; }  
        public DateTime? ActionUserAt { get; set; }


    }
}
