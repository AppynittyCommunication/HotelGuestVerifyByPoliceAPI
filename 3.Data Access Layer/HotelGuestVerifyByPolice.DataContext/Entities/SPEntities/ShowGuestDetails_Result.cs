using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestVerifyByPolice.DataContext.Entities.SPEntities
{
    public class ShowGuestDetails_Result
    {
        public string? RoomBookingId { get; set; }
        public string? GuestName { get; set; }
        public DateTime? CheckInDate { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? Gender { get; set; }
        public int Age { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? ComingFrom { get; set; }
        public string? VisitPurpose { get; set; }
        public string? GuestIdType { get; set; }
        public int NightStyed { get; set; }
        public DateTime? LastVisit { get; set; }
        public string? Address { get; set; }
        public byte[]? GuestPhoto { get; set; }
        public byte[]? GuestIDProof { get; set; }
        public string? RelationWithGuest { get; set; }
    }
}
