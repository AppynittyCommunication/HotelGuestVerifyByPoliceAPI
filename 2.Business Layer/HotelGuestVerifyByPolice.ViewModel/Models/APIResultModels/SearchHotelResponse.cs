using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.ViewModel.Models.APIResultModels
{
    public class SearchHotelResponse
    {
        public int code { get; set; }
        public string? status { get; set; }
        public string? message { get; set; }

        public HotelTitle? hotelTitle { get; set; }

        public List<HotelGuestInfo>? hotelGuests { get; set; }

         public LastVisitor? lastVisitors { get; set; }

    }

    public class HotelTitle
    {
        public string? hotelName { get; set; }
        public string? address { get; set; }
        public string? mobile { get; set; }
        public string? city { get; set; }
        public string? policeSation { get; set; }

    }

    public class HotelGuestInfo
    {
        public string? guestName { get; set; }
        public int reservation { get; set; }
        public int nightStayed { get; set; }
        public string? lastVisit { get; set; }
        public string? mobile { get; set; }
        public string? city { get; set; }
        public string? address { get; set; }    
        public string? country { get; set; }

    }

    public class LastVisitor
    {
        public string? guestName { get; set; }
        public int age { get; set; }
        public string? city { get; set; }
        public string? purpose { get; set; }
        public string? commingFrom { get; set; }
        public string? reservaion { get; set; }
        public string? checkInDate { get; set; }

        public byte[]? photo { get; set; }

    }
}
