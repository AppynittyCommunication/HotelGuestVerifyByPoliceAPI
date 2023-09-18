using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.ViewModel.Models.APIResultModels
{
    public class HotelCheckInListResult
    {
        public int code { get; set; }
        public string? status { get; set; }
        public string? message { get; set; }

        public List<GuestInOutStatusResponse>? data { get; set; }

    }
    public class GuestInOutStatusResponse
    {
        public int TotalGuest { get; set; }
        public int TodaysCheckIn { get; set; }
        public int TodaysCheckOut { get; set; }

        public List<GuestDetailsList>? guestDetails { get; set; }
    }

    public class GuestDetailsList
    {
        public string? guestName { get; set; }
       // public int roomNumber { get; set; }
        public int totalAdult { get; set; }
        public int totalChild { get; set; }       
        public string? mobile { get; set; }
        public string? country { get; set; }
        public DateTime checkInDate { get; set; }
    }

}
