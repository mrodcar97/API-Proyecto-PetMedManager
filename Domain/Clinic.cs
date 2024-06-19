using System;
using System.Collections.Generic;

namespace Domain;

public partial class Clinic
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Province { get; set; } = null!;

    public string Locality { get; set; } = null!;

    public string? Address { get; set; }

    public int? AdminId { get; set; }

    public virtual User? Admin { get; set; }

    public virtual ICollection<Person>? People { get; set; } = new List<Person>();
}
