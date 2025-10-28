using RAP.Administrator.Domain.Models.Divisions;
using RAP.Administrator.Domain.Models.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.DocumentDTOs
{
    public class PagedDocumentResponse
    {
        public IEnumerable<DocumentEntity> Data { get; set; } = new List<DocumentEntity>();
        public int TotalCount { get; set; }

    }
}
