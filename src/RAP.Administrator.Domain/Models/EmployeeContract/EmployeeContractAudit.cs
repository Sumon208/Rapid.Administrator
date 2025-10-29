using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.EmployeeContract
{
    public class EmployeeContractAudit
    {
        [Key]
        public int Id { get; set; }

        public int? EmployeeContractId { get; set; }    
        public string? Code { get; set; }                
        public string? Dial { get; set; }                
        public string? Name { get; set; }               
        public bool? IsDefault { get; set; }
        public int? StatusId { get; set; }               
                                                         
        public string? Browser { get; set; }             
        public string? Location { get; set; }            
        public string? IP { get; set; }                 
        public string? OS { get; set; }                 
        public string? MapURL { get; set; }              
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int? ActionTypeId { get; set; }
        public int? ActionUserId { get; set; }
        public DateTime? ActionUserAt { get; set; }
    }
}
