using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using static DL.DTOs;

namespace DL;

public partial class CocteleriaContext : DbContext
{
    public CocteleriaContext()
    {
    }

    public CocteleriaContext(DbContextOptions<CocteleriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Solicitude> Solicitudes { get; set; }

    public virtual DbSet<StatusSolicitude> StatusSolicitudes { get; set; }

    public virtual DbSet<GetAll> GetAll { get; set; }
    public virtual DbSet<DeleteSolicitud> DeleteSolicitud { get; set; }
    public virtual DbSet<SolicitudGetById> SolicitudGetById { get; set; }
    public virtual DbSet<ActualizarStatusSolicitud> ActualizarStatusSolicitud { get; set; }







    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Solicitude>(entity =>
        {
            entity.HasKey(e => e.IdSolicitud).HasName("PK__Solicitu__480235194DF5DEC9");

            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FechaSolicitud)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdStatus).HasDefaultValue(1);
            entity.Property(e => e.Mensaje)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(12)
                .IsUnicode(false);

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Solicitudes)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("FK__Solicitud__IdSta__3A81B327");
        });

        modelBuilder.Entity<StatusSolicitude>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("PK__StatusSo__527D5B8089F8AB71");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GetAll>(entity =>
        {
            entity.HasNoKey();
        });
        modelBuilder.Entity<DeleteSolicitud>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<SolicitudGetById>(entity =>
        {
            entity.HasNoKey();
        });
        modelBuilder.Entity<ActualizarStatusSolicitud>(entity =>
        {
            entity.HasNoKey();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
