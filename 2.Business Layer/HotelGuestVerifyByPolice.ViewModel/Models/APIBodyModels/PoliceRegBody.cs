using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.ViewModel.Models.APIBodyModels
{
    public class PoliceRegBody
    {
        public string userId { get; set; } = null!;

        // public string? Password { get; set; }
        public string? userType { get; set; }
        public int? stateId { get; set; }
        public int? distId { get; set; }
        public int? cityId { get; set; }
        public string? stationCode { get; set; }
        // public string? policeId { get; set; }
        // public string? policeName { get; set; }
        // public string? designation { get; set; }
        public string? mobile { get; set; }
        public string? email { get; set; }
        public string? otp { get; set; }
        public double? lat { get; set; }
        public double? _long { get; set; }
        public string? deviceIp { get; set; }

        public bool ? isMobileVerify { get; set; }


    }
}
