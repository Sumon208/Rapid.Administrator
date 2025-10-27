using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.ContactType
{
    public class ContactTypeLocalizationEntity
    {
        public int Id { get; set; }               

        public int? ContactTypeId { get; set; }    
        public int? LanguageId { get; set; }      

        public ContactTypeEntity? ContactType { get; set; }
    }
}
