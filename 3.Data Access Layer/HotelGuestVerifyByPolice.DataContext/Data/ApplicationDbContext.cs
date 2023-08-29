using System;
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

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Police> Polices { get; set; }

    public virtual DbSet<PoliceStation> PoliceStations { get; set; }

    public virtual DbSet<State> States { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=114.143.244.134;Initial Catalog=HotelGuestVerifyByPolice;Persist Security Info=False;User ID=appynitty;Password=BigV$Telecom;MultipleActiveResultSets=False;Connection Timeout=30;Encrypt=false;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__City__F2D21A9676023179");

            entity.Property(e => e.CityId).ValueGeneratedNever();
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.DistId).HasName("PK__District__118299D87AE53B4D");

            entity.Property(e => e.DistId).ValueGeneratedNever();
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.HotelRegNo).HasName("PK__Hotel__AC51D22895DDEB65");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Police>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Police__1788CCACB32CA1F2");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<PoliceStation>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PK__State__C3BA3B5A1663D02E");

            entity.Property(e => e.StateId).ValueGeneratedNever();
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
