using System;
using System.Collections.Generic;

namespace Domain;

public partial class Person
{
    public string NationalId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Address { get; set; }

    public string? Province { get; set; }

    public string? Locality { get; set; }

    public string Rol { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public DateOnly? LastLogin { get; set; }

    public int? Phone { get; set; }

    public byte[]? ProfilePicture { get; set; }

    public int? ClinicId { get; set; }

    public virtual ICollection<Appointment>? Appointments { get; set; } = new List<Appointment>();

    public virtual Clinic? Clinic { get; set; }

    public virtual ICollection<Pet>? Pets { get; set; } = new List<Pet>();

    public virtual ICollection<Shift>? Shifts { get; set; } = new List<Shift>();

    public virtual ICollection<User>? Users { get; set; } = new List<User>();

    public virtual ICollection<VisitHistory>? VisitHistories { get; set; } = new List<VisitHistory>();
}
