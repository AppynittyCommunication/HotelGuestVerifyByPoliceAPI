using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelGuestVerifyByPolice.DataContext.Entities.TableEntities;

[Table("DepartmentType")]
public partial class DepartmentType
{
    [Column("ID")]
    public int Id { get; set; }

    [Key]
    [Column("DeptTypeID")]
    public int DeptTypeId { get; set; }

    [StringLength(50)]
    public string? DeptTypeName { get; set; }

    public bool? IsActive { get; set; }
}
