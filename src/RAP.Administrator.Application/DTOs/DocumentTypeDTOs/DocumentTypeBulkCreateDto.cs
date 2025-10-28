using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.DocumentTypeDTOs
{
    public class DocumentTypeBulkCreateDto
    {
        public List<DocumentTypeCreateUpdateDto> DocumentTypes { get; set; } = new();
    }
}
