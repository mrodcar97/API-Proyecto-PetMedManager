using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace DataContext;

public partial class DataBaseContext : DbContext
{
    public DataBaseContext()
    {
    }

    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Clinic> Clinics { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Pet> Pets { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VisitHistory> VisitHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Proyecto_Veterinaria;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__appointm__3214EC27692081F3");

            entity.ToTable("appointments");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.PetId).HasColumnName("Pet_ID");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.VetId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("Vet_ID");

            entity.HasOne(d => d.Pet).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointme_Pet");

            entity.HasOne(d => d.Vet).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.VetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointmen_Vet");
        });

        modelBuilder.Entity<Clinic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__clinics__3214EC27B82C3850");

            entity.ToTable("clinics");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.AdminId).HasColumnName("Admin_ID");
            entity.Property(e => e.Locality)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Province)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.HasOne(d => d.Admin).WithMany(p => p.Clinics)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("FK_Clinic_User");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.NationalId).HasName("PK__person__2C5787854CAF7AD6");

            entity.ToTable("person");

            entity.Property(e => e.NationalId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("National_ID");
            entity.Property(e => e.Address)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.ClinicId).HasColumnName("Clinic_ID");
            entity.Property(e => e.DateOfBirth).HasColumnName("Date_Of_Birth");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.LastLogin).HasColumnName("Last_Login");
            entity.Property(e => e.Locality)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.ProfilePicture).HasColumnName("Profile_Picture");
            entity.Property(e => e.Province)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.HasOne(d => d.Clinic).WithMany(p => p.People)
                .HasForeignKey(d => d.ClinicId)
                .HasConstraintName("FK_Clients_Clinics");
        });

        modelBuilder.Entity<Pet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__pets__3214EC27AAF9DFA6");

            entity.ToTable("pets");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Breed)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.DateOfBirth).HasColumnName("Date_Of_Birth");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.OwnerId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("Owner_ID");
            entity.Property(e => e.ProfilePicture).HasColumnName("Profile_Picture");
            entity.Property(e => e.Sex)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Species)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.HasOne(d => d.Owner).WithMany(p => p.Pets)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pets_Clients");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.ShiftId).HasName("PK__Shifts__C0A838E1DC874CC9");

            entity.Property(e => e.ShiftId).HasColumnName("ShiftID");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.VeterinarianId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("VeterinarianID");

            entity.HasOne(d => d.Veterinarian).WithMany(p => p.Shifts)
                .HasForeignKey(d => d.VeterinarianId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shifts_Person");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tests__3214EC27FC30D6E4");

            entity.ToTable("tests");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.PetId).HasColumnName("Pet_ID");
            entity.Property(e => e.TestType)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("Test_Type");

            entity.HasOne(d => d.Pet).WithMany(p => p.Tests)
                .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Test_Pet");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3214EC272F13ED86");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.PersonId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("Person_ID");
            entity.Property(e => e.Rango)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.HasOne(d => d.Person).WithMany(p => p.Users)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK_User_Person");
        });

        modelBuilder.Entity<VisitHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__visit_hi__3214EC2769D8982E");

            entity.ToTable("visit_history");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PetId).HasColumnName("Pet_ID");
            entity.Property(e => e.VetId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("Vet_ID");

            entity.HasOne(d => d.Pet).WithMany(p => p.VisitHistories)
                .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_History_Pet");

            entity.HasOne(d => d.Vet).WithMany(p => p.VisitHistories)
                .HasForeignKey(d => d.VetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_History_Vet");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
