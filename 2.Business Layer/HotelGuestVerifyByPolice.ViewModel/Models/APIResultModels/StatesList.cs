using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.ViewModel.Models.APIResultModels
{
    public class StatesList
    {
        public int code { get; set; }
        public string? status { get; set; }
        public string? message { get; set; }

        public dynamic? data { get; set; }
       

          //public bool? IsActive { get; set; } 

    }

    public class States
    {
        public int stateId { get; set; }
        public string? stateName { get; set; }
    }
}
