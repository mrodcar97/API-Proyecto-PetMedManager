using System;
using System.Collections.Generic;

namespace Domain;

public partial class Pet
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Species { get; set; } = null!;

    public string Breed { get; set; } = null!;

    public string Sex { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public byte[]? ProfilePicture { get; set; }

    public string OwnerId { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Person Owner { get; set; } = null!;

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();

    public virtual ICollection<VisitHistory> VisitHistories { get; set; } = new List<VisitHistory>();
}
