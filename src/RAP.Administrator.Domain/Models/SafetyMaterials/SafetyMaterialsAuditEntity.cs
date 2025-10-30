using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.SafetyMaterials
{
    public class SafetyMaterialsAuditEntity
    {
        public int Id { get; set; }
        public int SafetyMaterialsId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Dail { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool IsDefault { get; set; }
        public bool StatusId { get; set; }
        public string Browser { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string IP { get; set; } = string.Empty;
        public string OS { get; set; } = string.Empty;
        public string MapURL { get; set; } = string.Empty;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int ActionTypeId { get; set; }
        public int ActionUserId { get; set; }
        public DateTime ActionUserAt { get; set; }

        // 🔹 Navigation Property
        public virtual SafetyMaterialsEntity? SafetyMaterials { get; set; }
    }
}
