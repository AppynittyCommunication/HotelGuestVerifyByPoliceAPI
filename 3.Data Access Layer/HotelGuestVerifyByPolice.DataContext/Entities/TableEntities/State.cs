using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelGuestVerifyByPolice.DataContext.Entities.TableEntities;

[Table("State")]
public partial class State
{
    [Column("ID")]
    public int Id { get; set; }

    [Key]
    [Column("StateID")]
    public int StateId { get; set; }

    [StringLength(50)]
    public string? StateName { get; set; }

    public bool? IsActive { get; set; }
}
