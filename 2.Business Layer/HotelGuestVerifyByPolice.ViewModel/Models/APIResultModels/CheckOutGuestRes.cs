using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.ViewModel.Models.APIResultModels
{
    public class CheckOutGuestRes
    {
        public int code { get; set; }
        public string? status { get; set; }
        public string? message { get; set; }
        //public string?  { get; set; }
    }
}
