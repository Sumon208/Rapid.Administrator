using RAP.Administrator.Domain.Models.SampleReceiving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.SampleReceivingDTOs
{
    public class SampleReceivingListDTO
    {
        public int Id { get; set; }
        public int? ReceivingNo { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerReference { get; set; }
        public string? TypeOfSample { get; set; }
        public string? RequiredTests { get; set; }
        public int? NumberOfSample { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }

        public string? BranchName { get; set; }
        public string? SectionName { get; set; }
        public string? DeliveredByName { get; set; }
        public string? ReceivedByName { get; set; }

    }

    public class PaginatedSampleReceivingListDTO
    {
        public IEnumerable<SampleReceivingEntity> Data { get; set; } = new List<SampleReceivingEntity>();
        public int TotalCount { get; set; }
        
    }
}
