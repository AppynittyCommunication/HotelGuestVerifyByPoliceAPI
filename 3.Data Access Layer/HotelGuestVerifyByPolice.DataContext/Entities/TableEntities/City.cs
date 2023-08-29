using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelGuestVerifyByPolice.DataContext.Entities.TableEntities;

[Table("City")]
public partial class City
{
    [Column("ID")]
    public int Id { get; set; }

    [Key]
    [Column("CityID")]
    public int CityId { get; set; }

    [StringLength(50)]
    public string? CityName { get; set; }

    [Column("DistID")]
    public int? DistId { get; set; }

    [Column("StateID")]
    public int? StateId { get; set; }

    public bool? IsActive { get; set; }
}
