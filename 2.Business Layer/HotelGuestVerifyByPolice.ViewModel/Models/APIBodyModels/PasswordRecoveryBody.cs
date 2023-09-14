using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.ViewModel.Models.APIBodyModels
{
    public class PasswordRecoveryBody
    {
        public bool otpstatus { get; set; }
        public string? hUserId { get; set; }
        public string? hPassword { get; set; }


       // public int opt { get; set; }
    }

    public class DeptPasswordRecoveryBody
    {
        public bool otpstatus { get; set; }
        public string? dUserId { get; set; }
        public string? dPassword { get; set; }


        // public int opt { get; set; }
    }
}
