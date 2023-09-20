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
        public int todaysCheckOut { get; set;}
    }


}
