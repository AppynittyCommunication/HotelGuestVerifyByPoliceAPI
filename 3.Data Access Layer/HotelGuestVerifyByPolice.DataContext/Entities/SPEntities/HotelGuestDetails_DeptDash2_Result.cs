using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.DataContext.Entities.SPEntities
{
    public class HotelGuestDetails_DeptDash2_Result
    {
        public string? HotelName { get; set; }
        public string? GuestName { get; set; }
        public int Age { get; set; }
        public string? VisitPurpose { get; set; } 
        
        public string? ComingFrom { get; set; }
        public int Total_Adult { get; set; }
        public int Total_Child { get; set; }
        public string? Mobile { get; set; }
        public string ? City { get; set; }
        public DateTime? CheckInDate { get; set; }


    }
}
