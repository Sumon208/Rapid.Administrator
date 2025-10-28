using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.Document
{
    public class DocumentLocalizationEntity
    {
        public int Id { get; set; }
        public int? DocumentId { get; set; }
        public int? LanguageId { get; set; }
        public string? Name { get; set; }

        // Navigation
        public DocumentEntity? Document { get; set; }
    }
}
