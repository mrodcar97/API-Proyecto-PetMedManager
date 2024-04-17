﻿using System;
using System.Collections.Generic;

namespace Domain;

public partial class Appointment
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly Hour { get; set; }

    public string VetId { get; set; } = null!;

    public int PetId { get; set; }

    public virtual Pet Pet { get; set; } = null!;

    public virtual Person Vet { get; set; } = null!;
}
