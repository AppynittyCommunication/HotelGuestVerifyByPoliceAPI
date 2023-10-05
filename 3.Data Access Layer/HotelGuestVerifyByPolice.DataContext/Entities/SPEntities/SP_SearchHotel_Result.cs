using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.DataContext.Entities.SPEntities
{
    public class SP_SearchHotel_Result
    {
        public string? GuestName { get; set; }
        public int Reservation { get; set; }
        public int NightStyed { get; set; }
        public DateTime? LastVisit { get; set; }
        public string? Mobile { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
    }
}
