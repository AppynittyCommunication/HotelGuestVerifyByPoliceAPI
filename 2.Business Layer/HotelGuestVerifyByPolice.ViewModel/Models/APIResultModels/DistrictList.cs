using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.ViewModel.Models.APIResultModels
{
    public class DistrictList
    {
        public int code { get; set; }
        public string? status { get; set; }
        public string? message { get; set; }

        public dynamic? data { get; set; }


        //public bool? IsActive { get; set; } 

    }

    public class District
    {
        public int distId { get; set; }
        public string? distName { get; set; }
    }
}