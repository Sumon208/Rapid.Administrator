using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Domain.Models.SafetyMaterials
{
    public class SafetyMaterialsLocalizationEntity
    {
        public int Id { get; set; }
        public int? LanguageId { get; set; }
        public int? SafetyMaterialsId { get; set; }
        public string? Name { get; set; }

        //  Navigation Property
        public virtual SafetyMaterialsEntity? SafetyMaterials { get; set; }
    }
}
