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
        public string? hUserId { get; set; }
        public string? hPassword { get; set; }

        public string? hNewPassword { get; set; }

       // public int opt { get; set; }
    }
}
