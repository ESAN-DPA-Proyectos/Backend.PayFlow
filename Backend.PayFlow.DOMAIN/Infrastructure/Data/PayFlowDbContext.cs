using System;
using System.Collections.Generic;
using Backend.PayFlow.DOMAIN.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.PayFlow.DOMAIN.Infrastructure.Data;

public partial class PayFlowDbContext : DbContext
{
    public PayFlowDbContext()
    {
    }

    public PayFlowDbContext(DbContextOptions<PayFlowDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fondos> Fondos { get; set; }

    public virtual DbSet<HistorialSesiones> HistorialSesiones { get; set; }

    public virtual DbSet<HistorialValidaciones> HistorialValidaciones { get; set; }

    public virtual DbSet<Notificaciones> Notificaciones { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<SeguimientoTransaccion> SeguimientoTransaccion { get; set; }

    public virtual DbSet<Transacciones> Transacciones { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fondos>(entity =>
        {
            entity.HasKey(e => e.IdFondo).HasName("PK__Fondos__F6A42E7D52817B5D");

            entity.Property(e => e.AportePorAsociado).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValue("Activo");
            entity.Property(e => e.Meta).HasColumnType("money");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.SaldoActual)
                .HasDefaultValue(0m)
                .HasColumnType("money");
        });

        modelBuilder.Entity<HistorialSesiones>(entity =>
        {
            entity.HasKey(e => e.IdSesion).HasName("PK__Historia__22EC535B5486BEA0");

            entity.Property(e => e.DireccionIp)
                .HasMaxLength(45)
                .HasColumnName("DireccionIP");
            entity.Property(e => e.FechaHora)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TipoAcceso).HasMaxLength(50);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.HistorialSesiones)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Historial__IdUsu__5CD6CB2B");
        });

        modelBuilder.Entity<HistorialValidaciones>(entity =>
        {
            entity.HasKey(e => e.IdHistorial).HasName("PK__Historia__9CC7DBB4EC3DCEC0");

            entity.Property(e => e.FechaValidacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Observacion).HasMaxLength(255);
            entity.Property(e => e.Resultado).HasMaxLength(20);
            entity.Property(e => e.TipoValidacion).HasMaxLength(20);

            entity.HasOne(d => d.IdTransaccionNavigation).WithMany(p => p.HistorialValidaciones)
                .HasForeignKey(d => d.IdTransaccion)
                .HasConstraintName("FK__Historial__IdTra__4D94879B");

            entity.HasOne(d => d.ValidadoPorNavigation).WithMany(p => p.HistorialValidaciones)
                .HasForeignKey(d => d.ValidadoPor)
                .HasConstraintName("FK__Historial__Valid__5165187F");
        });

        modelBuilder.Entity<Notificaciones>(entity =>
        {
            entity.HasKey(e => e.IdNotificacion).HasName("PK__Notifica__F6CA0A8528B2F5F3");

            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValue("Pendiente");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Mensaje).HasMaxLength(255);
            entity.Property(e => e.TipoNotificacion).HasMaxLength(50);

            entity.HasOne(d => d.IdTransaccionNavigation).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.IdTransaccion)
                .HasConstraintName("FK__Notificac__IdTra__5812160E");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Notificac__IdUsu__571DF1D5");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Roles__2A49584C3BF69D4C");

            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<SeguimientoTransaccion>(entity =>
        {
            entity.HasKey(e => e.IdSeguimiento).HasName("PK__Seguimie__5643F60F563F0143");

            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.Hito).HasMaxLength(50);

            entity.HasOne(d => d.IdTransaccionNavigation).WithMany(p => p.SeguimientoTransaccion)
                .HasForeignKey(d => d.IdTransaccion)
                .HasConstraintName("FK__Seguimien__IdTra__5441852A");
        });

        modelBuilder.Entity<Transacciones>(entity =>
        {
            entity.HasKey(e => e.IdTransaccion).HasName("PK__Transacc__334B1F7793036BEF");

            entity.Property(e => e.BeneficiarioNombre).HasMaxLength(150);
            entity.Property(e => e.Comprobante).HasMaxLength(255);
            entity.Property(e => e.Concepto).HasMaxLength(255);
            entity.Property(e => e.CuentaBeneficiario).HasMaxLength(50);
            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MetodoPago).HasMaxLength(30);
            entity.Property(e => e.Monto).HasColumnType("money");
            entity.Property(e => e.OrigenRol).HasMaxLength(50);
            entity.Property(e => e.Referencia).HasMaxLength(50);
            entity.Property(e => e.Tipo).HasMaxLength(20);

            entity.HasOne(d => d.IdFondoNavigation).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.IdFondo)
                .HasConstraintName("FK__Transacci__IdFon__4AB81AF0");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Transacci__IdUsu__49C3F6B7");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__5B65BF971E83BEE2");

            entity.HasIndex(e => e.Correo, "UQ__Usuarios__60695A1992DAE188").IsUnique();

            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.ContrasenaHash).HasMaxLength(255);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Dni)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DNI");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValue("Activo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Usuario).HasMaxLength(100);

            entity.HasMany(d => d.IdRol).WithMany(p => p.IdUsuario)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuarioRoles",
                    r => r.HasOne<Roles>().WithMany()
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UsuarioRo__IdRol__403A8C7D"),
                    l => l.HasOne<Usuarios>().WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UsuarioRo__IdUsu__3F466844"),
                    j =>
                    {
                        j.HasKey("IdUsuario", "IdRol").HasName("PK__UsuarioR__89C12A13BD0DA2F3");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
