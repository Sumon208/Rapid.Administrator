using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.SampleReceivingDTOs
{
    public class SampleReceivingTemplateDTO
    {
        public IEnumerable<BranchListDTO>? Branches { get; set; }
        public IEnumerable<CustomerListDTO>? Customers { get; set; }
        public IEnumerable<SectionListDTO>? Sections { get; set; }
        public IEnumerable<DeliveredListDTO>? DeliveredList { get; set; }
        public IEnumerable<ReceiverListDTO>? Receivers { get; set; }
    }

    public class BranchListDTO {
        public int Id { get; set; } 
        public string? Name { get; set; } 
    }
    public class CustomerListDTO 
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
    }
    public class SectionListDTO 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
    public class DeliveredListDTO 
    { 
        public int Id { get; set; } 
        public string? Name { get; set; } 
    }
    public class ReceiverListDTO 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}

