using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.ViewModel.Models.APIBodyModels
{
    public class HotelRegBody
    {
        public string? hotelName { get; set; }
        public string hotelRegNo { get; set; } = null!;

        public string? userId { get; set; }

        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? mobile { get; set; }
        public string? email { get; set; }
        public string? address { get; set; }
        public int? pinCode { get; set; }
        public int? stateId { get; set; }
        public int? distId { get; set; }
        public int? cityId { get; set; }
        public string? stationCode { get; set; }
        public double? lat { get; set; }
        public double? _long { get; set; }
        public string? diviceIp { get; set; }
        public bool? isMobileVerify { get; set; }
    }
}
