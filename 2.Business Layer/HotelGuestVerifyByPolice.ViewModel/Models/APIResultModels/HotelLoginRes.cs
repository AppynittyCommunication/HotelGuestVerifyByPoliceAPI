using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.ViewModel.Models.APIResultModels
{
    public class HotelLoginRes
    {
        public int code { get; set; }
        public string? status { get; set; }
        public string? message { get; set; }
        public bool otp { get; set; }
        public dynamic? data { get; set; }
    }

    public class HotelLoginDetails
    {
        public string? hUsername { get; set; }
        public string? hName { get; set; }
    }
}
