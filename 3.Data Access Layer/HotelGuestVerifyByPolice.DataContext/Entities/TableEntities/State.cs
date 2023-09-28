﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelGuestVerifyByPolice.DataContext.Entities.TableEntities;

public partial class State
{
    [Column("ID")]
    public int Id { get; set; }

    [Key]
    [Column("StateID")]
    public int StateId { get; set; }

    public string? StateName { get; set; }

    public string? StateCode { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string? CountryCode { get; set; }

    public bool? IsActive { get; set; }
}
