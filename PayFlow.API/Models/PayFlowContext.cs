using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PayFlow.API.Models;

public partial class PayFlowContext : DbContext
{
    public PayFlowContext()
    {
    }

    public PayFlowContext(DbContextOptions<PayFlowContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fondos> Fondos { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<SeguimientoTransaccion> SeguimientoTransaccion { get; set; }

    public virtual DbSet<Transacciones> Transacciones { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    public virtual DbSet<Validaciones> Validaciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = Environment.GetEnvironmentVariable("PAYFLOW_DB_CONNECTION");
            if (!string.IsNullOrEmpty(connectionString))
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            else
            {
                throw new InvalidOperationException("La cadena de conexión no está configurada en las variables de entorno.");
            }
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fondos>(entity =>
        {
            entity.HasKey(e => e.IdFondo).HasName("PK__Fondos__F6A42E7D1E5F6F33");

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

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Roles__2A49584C4D42B286");

            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<SeguimientoTransaccion>(entity =>
        {
            entity.HasKey(e => e.IdSeguimiento).HasName("PK__Seguimie__5643F60F4652F198");

            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.Hito).HasMaxLength(50);

            entity.HasOne(d => d.IdTransaccionNavigation).WithMany(p => p.SeguimientoTransaccion)
                .HasForeignKey(d => d.IdTransaccion)
                .HasConstraintName("FK__Seguimien__IdTra__5165187F");
        });

        modelBuilder.Entity<Transacciones>(entity =>
        {
            entity.HasKey(e => e.IdTransaccion).HasName("PK__Transacc__334B1F7742D83D59");

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
            entity.Property(e => e.Referencia).HasMaxLength(50);
            entity.Property(e => e.Tipo).HasMaxLength(20);

            entity.HasOne(d => d.IdFondoNavigation).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.IdFondo)
                .HasConstraintName("FK__Transacci__IdFon__47DBAE45");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Transacciones)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Transacci__IdUsu__46E78A0C");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__5B65BF97B8A85BC7");

            entity.HasIndex(e => e.Correo, "UQ__Usuarios__60695A194AD06623").IsUnique();

            entity.Property(e => e.Alias).HasMaxLength(100);
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

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuarios__IdRol__3B75D760");
        });

        modelBuilder.Entity<Validaciones>(entity =>
        {
            entity.HasKey(e => e.IdValidacion).HasName("PK__Validaci__5407AA74E522D479");

            entity.Property(e => e.FechaValidacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Observacion).HasMaxLength(255);
            entity.Property(e => e.Resultado).HasMaxLength(20);
            entity.Property(e => e.TipoValidacion).HasMaxLength(20);

            entity.HasOne(d => d.IdTransaccionNavigation).WithMany(p => p.Validaciones)
                .HasForeignKey(d => d.IdTransaccion)
                .HasConstraintName("FK__Validacio__IdTra__4AB81AF0");

            entity.HasOne(d => d.ValidadoPorNavigation).WithMany(p => p.Validaciones)
                .HasForeignKey(d => d.ValidadoPor)
                .HasConstraintName("FK__Validacio__Valid__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
