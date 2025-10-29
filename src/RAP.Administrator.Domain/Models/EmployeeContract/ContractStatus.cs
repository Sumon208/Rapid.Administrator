using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.EmployeeContract
{
    public class ContractStatus
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public ICollection<EmployeeContractEntity>? EmployeeContracts { get; set; }
    }
}
