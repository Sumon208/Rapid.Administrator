using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Administrator.Application.DTOs.ShiftTypeDTOs
{
    public class ShiftTypeResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;

       
        public int R => Color.Split(',').Length == 3 ? int.Parse(Color.Split(',')[0]) : 0;
        public int G => Color.Split(',').Length == 3 ? int.Parse(Color.Split(',')[1]) : 0;
        public int B => Color.Split(',').Length == 3 ? int.Parse(Color.Split(',')[2]) : 0;

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime BreakTime { get; set; }

        public string Status { get; set; } = string.Empty;
        public bool IsDefault { get; set; }

      
    }

}
