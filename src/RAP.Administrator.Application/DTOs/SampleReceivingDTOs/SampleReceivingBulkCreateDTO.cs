using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.SampleReceivingDTOs
{
    public class SampleReceivingBulkCreateDTO
    {
        public ICollection<SampleReceivingCreateDTO> Items { get; set; } = new List<SampleReceivingCreateDTO>();
    }
}
