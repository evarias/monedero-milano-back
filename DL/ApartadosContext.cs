using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class ApartadosContext : DbContext
{
    public ApartadosContext()
    {
    }

    public ApartadosContext(DbContextOptions<ApartadosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DrillApartado> DrillApartados { get; set; }
    public virtual DbSet<ApartadoGetByIdDTO> ApartadoGetByIdDTO { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApartadoGetByIdDTO>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.UseCollation("Modern_Spanish_CI_AS");

        modelBuilder.Entity<DrillApartado>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DrillApartados", "Apartados");

            entity.Property(e => e.Clase)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CodigoClase)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CodigoCliente)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CodigoClienteLealtad)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CodigoSms)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CodigoSMS");
            entity.Property(e => e.Departamento)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Estatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EstatusApartado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Estilo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FolioApartado)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.FolioTrxCancelo)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.FolioTrxCedio)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.FolioTrxLiquido)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Foliocreo)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.ImportePagado).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ImportePagadoAbono).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MontoApartado).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.NumeroDepartamento)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NumeroProveedor)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NumeroSubClase)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NumeroSubDepartamento)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Plastico)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Proveedor)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Saldo).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Sku)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SubClase)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SubDepartamento)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
