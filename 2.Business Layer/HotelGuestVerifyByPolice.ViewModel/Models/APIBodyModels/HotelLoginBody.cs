using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.ViewModel.Models.APIBodyModels
{
    public class HotelLoginBody
    {
        public string? hUsername { get; set; }
        public string? hPassword { get; set; }
    }
}
