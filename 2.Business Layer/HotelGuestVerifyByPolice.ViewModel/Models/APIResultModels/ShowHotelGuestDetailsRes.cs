using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.ViewModel.Models.APIResultModels
{
    public class ShowHotelGuestDetailsRes
    {
        public int code { get; set; }
        public string? status { get; set; }
        public string? message { get; set; }

        public List<GuestDetails>? hotelGuestDetails { get; set; }

        public List<AddOnGuestDetails>? addOnGuestDetails1 { get; set; }
    }

    public class GuestDetails
    {
        public string? roomBookingId { get; set; }
        public string? guestName { get; set; }
        public string? email { get; set; }
        public string? mobile { get; set; }
        public string? gender { get; set; }
        public int ? age { get; set; }
        public string? country { get; set; }
        public string? city { get; set; }
        public int NightStyed { get; set; }
        public string? LastVisit { get; set; }
        public string? address { get; set; }
        public byte[]? guestPhoto { get; set; }

       
    }

    public class AddOnGuestDetails
    {
        public string? relationWithGuest { get; set; }
        public string? guestName { get; set; }
    }

}
