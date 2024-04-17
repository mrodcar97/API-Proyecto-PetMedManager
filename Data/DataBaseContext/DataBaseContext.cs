using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIproyecto.Models;

public partial class DataBaseContext : DbContext
{
    public DataBaseContext()
    {
    }

    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clinica> Clinicas { get; set; }

    public virtual DbSet<Mascota> Mascotas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Proyecto_Veterinaria;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clinica>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdAdmin).HasColumnName("Id_Admin");
            entity.Property(e => e.Localidad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Provincia)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Mascota>(entity =>
        {
            entity.HasKey(e => e.IdMascota).HasName("PK__mascotas__C7A382FEB2204B59");

            entity.ToTable("mascotas");

            entity.Property(e => e.IdMascota)
                .ValueGeneratedNever()
                .HasColumnName("Id_Mascota");
            entity.Property(e => e.Especie)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("Fecha_Nacimiento");
            entity.Property(e => e.FotoPerfil)
                .HasColumnType("image")
                .HasColumnName("Foto_Perfil");
            entity.Property(e => e.IdPropietario).HasColumnName("Id_Propietario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Raza)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasIndex(e => e.Email, "IX_Usuarios").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Rango)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
