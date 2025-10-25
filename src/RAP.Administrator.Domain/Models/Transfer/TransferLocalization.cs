using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.Transfer
{
    public class TransferLocalization
    {
        [Key]
        public int Id { get; set; }

        public int? TransferId { get; set; }
        public int? LanguageId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        [ForeignKey("TransferId")]
        public virtual TransferEntity? Transfer { get; set; }
    }
}
