using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelGuestVerifyByPolice.DataContext.Entities.TableEntities;

[Table("VisitPurpose")]
public partial class VisitPurpose
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("purpose")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Purpose { get; set; }
}
