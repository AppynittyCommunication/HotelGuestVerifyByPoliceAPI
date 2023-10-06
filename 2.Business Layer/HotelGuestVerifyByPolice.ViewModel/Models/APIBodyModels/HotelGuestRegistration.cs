using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.ViewModel.Models.APIBodyModels
{
    public class HotelGuestRegistration
    {
        public string? HotelRegNo { get; set; }
        public string? GuestName { get; set; }
        public string? GuestType { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Country { get; set; }
        public int? State { get; set; }
        public int? City { get; set; }
        //public string? Address { get; set; }
        public int NumberOfGuest { get; set; }
        public int Age { get; set; }
        public string? Mobile { get; set; }
        public string? CheckInDate { get; set; }
      //  public string? CheckOutDate { get; set; }
        public int? VisitPurpose { get; set; }
        public string? RoomType { get; set; }
        public int RoomNo { get; set; }
        public string? ComingFrom { get; set; }
        public int? GuestIdType { get; set; }
        public string? GuestIDProof { get; set; }
        public string? GuestPhoto { get; set; }
        public string? PaymentMode { get; set; }
        public List<AddOnGuest>? AddOnGuest { get; set; }
    }

    public class AddOnGuest
    {
        public string? GuestName { get; set; }
        public int Age { get; set; }
        public string? Mobile { get; set; }
        public int? RelationWithGuest { get; set; }
        public string? GuestType { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Country { get; set; }
        public int? State { get; set; }
        public int? City { get; set; }
        //public string? Address { get; set; }
        public string? ComingFrom { get; set; }
        public int? GuestIdType { get; set; }
        public string? GuestIDProof { get; set; }
        public string?   GuestPhoto { get; set; }
    }
}
