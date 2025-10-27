using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.ContactTypeDTOs
{
    public class ContactTypeTemplateDto
    {
        public List<string>? Languages { get; set; }
        public List<string>? ActionTypes { get; set; }
        public List<string>? Statuses { get; set; }
    }
}
