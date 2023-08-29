using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelGuestVerifyByPolice.DataContext.Entities.TableEntities;

[Table("District")]
public partial class District
{
    [Column("ID")]
    public int Id { get; set; }

    [Key]
    [Column("DistID")]
    public int DistId { get; set; }

    [StringLength(50)]
    public string? DistName { get; set; }

    [Column("StateID")]
    public int? StateId { get; set; }

    public bool? IsActive { get; set; }
}
