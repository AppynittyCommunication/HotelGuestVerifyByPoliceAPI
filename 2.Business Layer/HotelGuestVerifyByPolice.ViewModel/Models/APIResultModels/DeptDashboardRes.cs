using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.ViewModel.Models.APIResultModels
{
    public class DeptDashboardRes
    {
        public int code { get; set; }
        public string? status { get; set; }
        public string? message { get; set; }
        public string? stationName { get; set; }

        public List<HotelLocOnDashboard>? hotelLocOnDashboard { get; set; }
        public List<HotelListDetailsForDashboard>? hotelListDetailsForDashboards { get; set; }

        public List<HotelGuestDetails_DeptDash1>? hotelGuestDetails_DeptDashes { get; set; }

        public List<HotelGuestDetails_DeptDash2>? hotelGuestDetails_DeptDash2 { get; set; }
    }

    public class HotelLocOnDashboard
    {
        public string? hotelName { get; set; }   
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public double? lat { get; set; }
        public double? _long { get; set; }
    }


    public class HotelListDetailsForDashboard
    { 
        public string? stationName { get; set; }
        public int hotelCount { get; set; }
        public int totalCheckIn { get; set; }

        public int todaysCheckIn { get; set; }
        public int todaysCheckOut { get; set; }
    }


    public class HotelGuestDetails_DeptDash1
    {
        public string? roomBookingID { get; set; }
        public byte[]? guestPhoto { get; set; }
        public string? guestName { get; set; }
        public int age { get; set; }
        public string? city { get; set; }
        public string? visitPurpose { get; set; }
        public string? comingFrom { get; set; }
        public int total_Adult { get; set; }
        public int total_Child { get; set; }
        public string? hotelName { get; set; }
        public DateTime checkInDate { get; set; }
    }

    public class HotelGuestDetails_DeptDash2
    {
        public string? hotelName { get; set; }
        public string? guestName { get; set; }
        public int age { get; set; }
        public string? visitPurpose { get; set; }

        public string? comingFrom { get; set; }
       // public int total_Adult { get; set; }
      //  public int total_Child { get; set; }
        
        public string? reservation { get; set; }

        public string? mobile { get; set; }
        public string? city { get; set; }
        public DateTime? checkInDate { get; set; }
    }


}
