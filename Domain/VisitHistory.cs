using System;
using System.Collections.Generic;

namespace Domain;

public partial class VisitHistory
{
    public int Id { get; set; }

    public DateOnly? Date { get; set; }

    public string? Description { get; set; }

    public int PetId { get; set; }

    public string VetId { get; set; } = null!;

    public virtual Pet Pet { get; set; } = null!;

    public virtual Person Vet { get; set; } = null!;
}
