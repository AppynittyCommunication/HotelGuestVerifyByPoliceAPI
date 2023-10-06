using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelGuestVerifyByPolice.DataContext.Entities.TableEntities;

[Table("Hotel")]
[Index("UserId", Name = "UQ__Hotel__1788CCAD7BB3AD24", IsUnique = true)]
public partial class Hotel
{
    [Column("ID")]
    public int Id { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreateDate { get; set; }

    [Column("UserID")]
    [StringLength(50)]
    public string? UserId { get; set; }

    [StringLength(50)]
    public string? Password { get; set; }

    [StringLength(50)]
    public string? FirstName { get; set; }

    [StringLength(50)]
    public string? LastName { get; set; }

    [Key]
    [StringLength(50)]
    public string HotelRegNo { get; set; } = null!;

    [StringLength(100)]
    public string? HotelName { get; set; }

    [StringLength(20)]
    public string? Mobile { get; set; }

    [StringLength(60)]
    public string? Email { get; set; }

    [StringLength(200)]
    public string? Address { get; set; }

    public int? PinCode { get; set; }

    [Column("StateID")]
    public int? StateId { get; set; }

    [Column("DistID")]
    public int? DistId { get; set; }

    [Column("CityID")]
    public int? CityId { get; set; }

    public int? StationCode { get; set; }

    public double? Lat { get; set; }

    public double? Long { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsMobileVerify { get; set; }

    public bool? IsEmailVerify { get; set; }

    public bool? ApprovalStatus { get; set; }

    [Column("OTP")]
    [StringLength(6)]
    public string? Otp { get; set; }

    [Column("OTPUse")]
    public int? Otpuse { get; set; }

    [Column("OTPUseDateTime", TypeName = "datetime")]
    public DateTime? OtpuseDateTime { get; set; }

    [Column("DiviceIP")]
    [StringLength(30)]
    public string? DiviceIp { get; set; }
}
