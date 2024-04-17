using System;
using System.Collections.Generic;

namespace Domain;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Rango { get; set; } = null!;

    public string? PersonId { get; set; }

    public virtual ICollection<Clinic> Clinics { get; set; } = new List<Clinic>();

    public virtual Person? Person { get; set; }
}
