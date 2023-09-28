using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.DataContext.Entities.SPEntities
{
    public class Hotel_MonthlyCheckInOutCount_Result
    {
        public int Month { get; set; }
        public string? MonthName { get; set; }
        public int CheckInCount { get; set; }
        public int CheckOutCount { get; set; }
    }
}
