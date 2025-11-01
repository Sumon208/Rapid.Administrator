using RAP.Administrator.Domain.Models.SalaryAdvance;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.SampleReceiving
{
    public class SampleReceivingEntity
    {
        [Key]
        public int Id { get; set; }

      
        public int? BranchId { get; set; }               
        public int? CustomerId { get; set; }             
        public int? SectionId { get; set; }             
        public int? DeliveredById { get; set; }          
        public int? ReceivedById { get; set; }          

        // Form fields (all nullable)
        public int? ReceivingNo { get; set; }            
        public string? CustomerName { get; set; }        
        [MaxLength(250)]
        public string? CustomerReference { get; set; }
        [MaxLength(250)]
        public string? TypeOfSample { get; set; }
        [MaxLength(1000)]
        public string? RequiredTests { get; set; }
        public int? NumberOfSample { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }             
        [MaxLength(500)]
        public string? OtherNotes { get; set; }  
        
        //common meta (nullable)
        [MaxLength(100)]
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        [MaxLength(100)]
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }

        // Navigation properties
        public virtual BranchListEntity? Branch { get; set; }
        public virtual CustomerListEntity? Customer { get; set; }
        public virtual SectionListEntity? Section { get; set; }
        public virtual DeliveredListEntity? DeliveredBy { get; set; }
        public virtual ReceiverListEntity? ReceivedBy { get; set; }

       
        public virtual ICollection<SampleReceivedLocalizationEntity> Localizations { get; set; } = new List<SampleReceivedLocalizationEntity>();
        public virtual ICollection<SampleReceivedAuditEntity> Audits { get; set; } = new List<SampleReceivedAuditEntity>();
        public virtual ICollection<SampleReceivedExportEntity> Exports { get; set; } = new List<SampleReceivedExportEntity>();
    }

    public class CustomerListEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string? Name { get; set; }

        // Navigation: many SampleReceiving can reference one Customer
        public virtual ICollection<SampleReceivingEntity> SampleReceivings { get; set; } = new List<SampleReceivingEntity>();
    }

    public class ReceiverListEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string? Name { get; set; }

        public virtual ICollection<SampleReceivingEntity> SampleReceivingsReceived { get; set; } = new List<SampleReceivingEntity>();
    }

    public class DeliveredListEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string? Name { get; set; }

        public virtual ICollection<SampleReceivingEntity> SampleReceivingsDelivered { get; set; } = new List<SampleReceivingEntity>();
    }

    public class SectionListEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string? Name { get; set; }

        public virtual ICollection<SampleReceivingEntity> SampleReceivings { get; set; } = new List<SampleReceivingEntity>();
    }


}
