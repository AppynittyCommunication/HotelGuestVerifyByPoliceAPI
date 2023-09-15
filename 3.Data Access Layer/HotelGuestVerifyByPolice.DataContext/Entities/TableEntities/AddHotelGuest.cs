using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelGuestVerifyByPolice.DataContext.Entities.TableEntities;

[Table("AddHotelGuest")]
public partial class AddHotelGuest
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("RoomBookingID")]
    [StringLength(50)]
    public string? RoomBookingId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Date { get; set; }

    [StringLength(50)]
    public string? HotelRegNo { get; set; }

    [StringLength(100)]
    public string? GuestName { get; set; }

    public int? Age { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Gender { get; set; }

    [StringLength(12)]
    public string? Mobile { get; set; }

    [StringLength(70)]
    public string? Email { get; set; }

    [StringLength(30)]
    public string? Country { get; set; }

    [StringLength(30)]
    public string? State { get; set; }

    [StringLength(30)]
    public string? City { get; set; }

    [StringLength(100)]
    public string? Address { get; set; }

    [StringLength(100)]
    public string? ComingFrom { get; set; }

    [StringLength(20)]
    public string? GuestType { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? RelationWithGuest { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? GuestIdType { get; set; }

    [Column("GuestIDProof")]
    public byte[]? GuestIdproof { get; set; }

    public byte[]? GuestPhoto { get; set; }

    public int? VerificationStatus { get; set; }

    public bool? CrimeStatus { get; set; }

    public string? RemarkByPolice { get; set; }
}
