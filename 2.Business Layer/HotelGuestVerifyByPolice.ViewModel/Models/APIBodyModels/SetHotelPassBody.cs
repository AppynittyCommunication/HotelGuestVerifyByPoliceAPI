using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.ViewModel.Models.APIBodyModels
{
    public class SetHotelPassBody
    {
        public string hUsername { get; set; }
        public string otp { get; set; }
        public string pass { get; set; }
    }
}
