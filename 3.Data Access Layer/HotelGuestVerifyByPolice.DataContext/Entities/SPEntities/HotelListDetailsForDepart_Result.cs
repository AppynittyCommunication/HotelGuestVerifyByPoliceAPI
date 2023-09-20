using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.DataContext.Entities.SPEntities
{
    public class HotelListDetailsForDepart_Result
    {
        public string? StationName { get; set; }
        public int Hotel_Count { get; set; }
        public int Total_CheckIn { get; set; }
        public int Today_CheckIn { get; set; }
        public int Today_CheckOut { get; set; }
    }
}
