﻿using System;
using System.Collections.Generic;
using HotelGuestVerifyByPolice.DataContext.Entities.TableEntities;
using Microsoft.EntityFrameworkCore;

namespace HotelGuestVerifyByPolice.DataContext.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AddHotelGuest> AddHotelGuests { get; set; }

    public virtual DbSet<AuthenticationPin> AuthenticationPins { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<DepartmentType> DepartmentTypes { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<HotelGuest> HotelGuests { get; set; }

    public virtual DbSet<Police> Polices { get; set; }

    public virtual DbSet<PoliceStation> PoliceStations { get; set; }

    public virtual DbSet<State> States { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=124.153.94.110;Initial Catalog=HotelGuestVerifyByPolice;Persist Security Info=False;User ID=appynitty;Password=BigV$Telecom;MultipleActiveResultSets=False;Connection Timeout=30;Encrypt=false;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthenticationPin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authenti__3214EC276C28A4C4");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__City__F2D21A9673EB0303");

            entity.Property(e => e.CityId).ValueGeneratedNever();
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<DepartmentType>(entity =>
        {
            entity.HasKey(e => e.DeptTypeId).HasName("PK__Departme__2DD71682FB3F5E4C");

            entity.Property(e => e.DeptTypeId).ValueGeneratedNever();
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.DistId).HasName("PK__District__118299D8BB3335B0");

            entity.Property(e => e.DistId).ValueGeneratedNever();
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.HotelRegNo).HasName("PK__Hotel__AC51D2283F915969");

            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<HotelGuest>(entity =>
        {
            entity.HasKey(e => e.RoomBookingId).HasName("PK__HotelGue__1FAA5777A3BFEE50");

            entity.Property(e => e.Gender).IsFixedLength();
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Police>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Police__1788CCAC87986454");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<PoliceStation>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PK__State__C3BA3B5AE571F19D");

            entity.Property(e => e.StateId).ValueGeneratedNever();
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
