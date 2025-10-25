using RAP.Administrator.Domain.Models.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.TransferDTOs
{
    public class PagedTransferResponse
    {
        public int TotalCount { get; set; }
        public IEnumerable<TransferEntity>? Data { get; set; }
    }
}
