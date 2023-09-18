using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.DataContext.Entities.SPEntities
{
    public class Hotel_CheckInList_Result
    {
        public string? GuestName { get; set; }
        public string? Mobile { get; set; }
        public string? Country { get; set; }
        public DateTime CheckInDate { get; set; }
        public int Total_Adult { get; set; }
        public int Total_Child { get; set;}
    }
}
