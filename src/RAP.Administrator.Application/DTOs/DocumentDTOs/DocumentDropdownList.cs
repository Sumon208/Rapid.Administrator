using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.DocumentDTOs
{
    public class DocumentDropdownDTO
    {
        public IEnumerable<OrderByDTO>? OrderByList { get; set; }
        public IEnumerable<ShipmentTypeDTO>? ShipmentTypeList { get; set; }
    }

    public class OrderByDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class ShipmentTypeDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
