using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.DataContext.Entities.SPEntities
{
    public class HotelLocForDepartDash_Result
    {
        public string? HotelName { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }
    }
}
