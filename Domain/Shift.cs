using System;
using System.Collections.Generic;

namespace Domain;

public partial class Shift
{
    public int ShiftId { get; set; }

    public string VeterinarianId { get; set; } = null!;

    public DateOnly Date { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public string? Notes { get; set; }

    public virtual Person? Veterinarian { get; set; } = null!;
}
