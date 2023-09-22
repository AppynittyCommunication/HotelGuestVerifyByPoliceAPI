using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelGuestVerifyByPolice.DataContext.Entities.TableEntities;

[Table("Authentication_Pins")]
[Index("AuthPin", Name = "UQ__Authenti__C970551DB5EF2B11", IsUnique = true)]
public partial class AuthenticationPin
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? AuthPin { get; set; }

    public string? UseFor { get; set; }

    [Column("UserID")]
    [StringLength(50)]
    public string? UserId { get; set; }

    public bool? IsUse { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UseDate { get; set; }
}
