using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.ViewModel.Models.APIResultModels
{
    public class CheckHotelUsernameRes
    {
        public int code { get; set; }
        public string? otp { get; set; }
        public string? userid { get; set; }
        public string? status { get; set; }
        public string? message { get; set; }
    }

    public class CheckDeptUsernameRes
    {
        public int code { get; set; }
        public string? otp { get; set; }
        public string? userid { get; set; }
        public string? status { get; set; }
        public string? message { get; set; }
    }

}
