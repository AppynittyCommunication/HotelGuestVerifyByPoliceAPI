using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.DataContext.Entities.SPEntities
{
    public class SP_LastVisitorByHotel_Result
    {
        public string? GuestName { get; set; }
        public int Age { get; set; }
        public string? City { get; set; }
        public string? Visit_Purpose { get; set; }
        public int Total_Adult { get; set; }
        public int Total_Child { get; set; }
        public DateTime CheckInDate { get; set; }
        public byte[]? GuestPhoto { get; set; }
    }
}
