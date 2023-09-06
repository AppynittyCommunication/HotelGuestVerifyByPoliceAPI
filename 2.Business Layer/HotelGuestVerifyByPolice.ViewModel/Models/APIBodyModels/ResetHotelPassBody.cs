using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.ViewModel.Models.APIBodyModels
{
    public class ResetHotelPassBody
    {
        public string? hUsername { get; set; }
        public string? oldPass { get; set; }
        public string? newPass { get; set; }
    }
}
