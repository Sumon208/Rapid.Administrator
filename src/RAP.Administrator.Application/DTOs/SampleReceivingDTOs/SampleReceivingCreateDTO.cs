using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.SampleReceivingDTOs
{
    public class SampleReceivingCreateDTO
    {
        public int? BranchId { get; set; }
        public int? CustomerId { get; set; }
        public int? SectionId { get; set; }
        public int? DeliveredById { get; set; }
        public int? ReceivedById { get; set; }

        public int? ReceivingNo { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerReference { get; set; }
        public string? TypeOfSample { get; set; }
        public string? RequiredTests { get; set; }
        public int? NumberOfSample { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }
        public string? OtherNotes { get; set; }

        // Localization
        public ICollection<SampleReceivedLocalizationDTO>? Localizations { get; set; }
    }
}
