using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelGuestVerifyByPolice.DataContext.Entities.TableEntities;

[Keyless]
[Table("PoliceStation")]
public partial class PoliceStation
{
    [Column("ID")]
    public int Id { get; set; }

    public int? StationCode { get; set; }

    [StringLength(50)]
    public string? StationName { get; set; }

    [StringLength(200)]
    public string? Address { get; set; }

    public int? PinCode { get; set; }

    public bool? IsUrban { get; set; }

    public bool? IsRular { get; set; }

    [Column("CityID")]
    public int? CityId { get; set; }

    [Column("DistID")]
    public int? DistId { get; set; }

    [Column("StateID")]
    public int? StateId { get; set; }

    public bool? IsActive { get; set; }
}
