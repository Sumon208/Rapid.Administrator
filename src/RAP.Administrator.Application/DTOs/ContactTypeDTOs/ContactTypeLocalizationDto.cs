using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.ContactTypeDTOs
{
    public class ContactTypeLocalizationDto
    {
        public int? Id { get; set; }
        public int? ContactTypeId { get; set; }
        public int? LanguageId { get; set; }
    }
}
