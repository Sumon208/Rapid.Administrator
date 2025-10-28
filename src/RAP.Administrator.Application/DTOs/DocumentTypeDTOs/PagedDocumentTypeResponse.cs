using RAP.Administrator.Domain.Models.Divisions;
using RAP.Administrator.Domain.Models.DocumentType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.DocumentTypeDTOs
{
    public class PagedDocumentTypeResponse
    {
        public IEnumerable<DocumentTypeEntity> Data { get; set; } = new List<DocumentTypeEntity>();
        public int TotalCount { get; set; }
    }
}
