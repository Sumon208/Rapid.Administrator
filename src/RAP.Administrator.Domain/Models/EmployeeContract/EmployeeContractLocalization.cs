using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.EmployeeContract
{

    public class EmployeeContractLocalization
    {
        [Key]
        public int Id { get; set; }

        public int? EmployeeContractId { get; set; }   
        public int? LanguageId { get; set; }           
        public string? Name { get; set; }            
    }
}

