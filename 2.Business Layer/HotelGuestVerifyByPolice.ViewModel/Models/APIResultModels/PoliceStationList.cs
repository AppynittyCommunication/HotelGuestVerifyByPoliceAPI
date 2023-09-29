using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.ViewModel.Models.APIResultModels
{
    public class PoliceStationList
    {
        public int code { get; set; }
        public string? status { get; set; }
        public string? message { get; set; }

        public dynamic? data { get; set; }


        //public bool? IsActive { get; set; } 

    }

    public class PoliceStation
    {
        public string? stationCode { get; set; }
        public string? stationName { get; set; }
    }
}
