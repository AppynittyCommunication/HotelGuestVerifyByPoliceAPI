using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotelGuestVerifyByPolice.ViewModel.Models.APIResultModels
{
    public class ShowGuestDetailsRes
    {
        public int code { get; set; }
        public string? status { get; set; }
        public string? message { get; set; }

        public ShowGuestDetailsResData? data { get; set; }
    }

    public class ShowGuestDetailsResData
    {
        public Mainguestdetails? mainguestdetails { get; set; }
        public List<AddOnGuestDetail>? addOnGuestDetails { get; set; }
    }

    public class Mainguestdetails
    {
        public string? roomBookingId { get; set; }
        public string? name { get; set; }
        public string? checkInDate { get; set; }
        public string? mobileNo { get; set; }
        public string? relation { get; set; }
        public string? gender { get; set; }
        public int age { get; set; }
        public string? country { get; set; }
        public string? state { get; set; }
        public string? city { get; set; }
        public string? commingFrom { get; set; }
        public string? visitPurpose { get; set; }
        public string? idType { get; set; }
        public byte[]? photo { get; set; }
        public byte[]? idPhoto { get; set; }
    }

    public class AddOnGuestDetail
    {
        public string? roomBookingId { get; set; }
        public string? name { get; set; }
        public string? checkInDate { get; set; }
        public string? mobileNo { get; set; }
        public string? relation { get; set; }
        public string? gender { get; set; }
        public int age { get; set; }
        public string? country { get; set; }
        public string? state { get; set; }
        public string? city { get; set; }
        public string? commingFrom { get; set; }
        public string? visitPurpose { get; set; }
        public string? idType { get; set; }
        public byte[]? photo { get; set; }
        public byte[]? idPhoto { get; set; }
    }
}
