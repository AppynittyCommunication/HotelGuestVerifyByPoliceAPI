using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.ViewModel.Models.APIResultModels
{
    public class GuestCheckedInList
    {
        public int code { get; set; }
        public string? status { get; set; }
        public string? message { get; set; }

        public List<CheckedInList>? data { get; set; }
    }

    public class CheckedInList
    {
        public string? roomBookingID { get; set; }
        public string? guestName { get; set; }
        public string? guestPhoto { get; set; }
        public int roomNumber { get; set; }
        public string? reservation { get; set; }
        //public int totalAdult { get; set; }
        //public int totalChild { get; set; }       
        public string? mobile { get; set; }
        public string? state { get; set; }
        public string? country { get; set; }
        public string? checkInDate { get; set; }
    }
}
