using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.TransferDTOs
{
    public class TransferDropdownDto
    {
        public class BranchDto
        {
            public int Id { get; set; }
            public string? Name { get; set; }
        }

        public class FromLocationDto
        {
            public int Id { get; set; }
            public string? Name { get; set; }
        }

        public class ToLocationDto
        {
            public int Id { get; set; }
            public string? Name { get; set; }
        }

        public class IqamaDto
        {
            public int Id { get; set; }
            public string? Name { get; set; }
        }
    }
}
