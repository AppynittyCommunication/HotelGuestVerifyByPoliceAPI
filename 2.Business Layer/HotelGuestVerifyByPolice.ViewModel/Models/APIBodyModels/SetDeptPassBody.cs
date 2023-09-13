using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.ViewModel.Models.APIBodyModels
{
    public class SetDeptPassBody
    {
        public string? dUsername { get; set; }
        public string? otp { get; set; }
        public string? pass
        {
            get; set;
        }
    }
}
