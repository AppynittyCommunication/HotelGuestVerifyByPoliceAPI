using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.ViewModel.Models.APIResultModels
{
    public class MonthlyCheckInOutRes
    {
        public int code { get; set; }
        public string? status { get; set; }
        public string? message { get; set; }

        public List<MonthlyCheckInOutCount>? monthlyCheckInOutCounts { get; set; }
    }

    public class MonthlyCheckInOutCount
    {
        public int month { get; set; }
        public string? monthName { get; set; }
        public int checkInCount { get; set; }
        public int checkOutCount { get; set;}
    }
}
