using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelGuestVerifyByPolice.DataContext.Entities.TableEntities;

[Table("Police")]
public partial class Police
{
    [Column("ID")]
    public int Id { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreateDate { get; set; }

    [Key]
    [Column("UserID")]
    [StringLength(50)]
    public string UserId { get; set; } = null!;

    [StringLength(50)]
    public string? Password { get; set; }

    [StringLength(30)]
    public string? UserType { get; set; }

    [Column("StateID")]
    public int? StateId { get; set; }

    [Column("DistID")]
    public int? DistId { get; set; }

    [Column("CityID")]
    public int? CityId { get; set; }

    public int? StationCode { get; set; }

    [Column("PoliceID")]
    [StringLength(20)]
    public string? PoliceId { get; set; }

    [StringLength(70)]
    public string? PoliceName { get; set; }

    [StringLength(30)]
    public string? Designation { get; set; }

    [StringLength(20)]
    public string? Mobile { get; set; }

    [StringLength(60)]
    public string? Email { get; set; }

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

    public double? Lat { get; set; }

    public double? Long { get; set; }

    [Column("DiviceIP")]
    [StringLength(30)]
    public string? DiviceIp { get; set; }
}
