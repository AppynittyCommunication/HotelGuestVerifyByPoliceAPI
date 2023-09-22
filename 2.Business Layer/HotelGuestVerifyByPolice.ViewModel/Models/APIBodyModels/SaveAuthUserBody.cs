using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.ViewModel.Models.APIBodyModels
{
    public class SaveAuthUserBody
    {
        public string? authPin { get; set; }
        public string? useFor { get; set; }
        public string? userID { get; set; }
        public bool? isUse { get; set; }
        

    }
}
