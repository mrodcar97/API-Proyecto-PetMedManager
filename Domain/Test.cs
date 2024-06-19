using System;
using System.Collections.Generic;

namespace Domain;

public partial class Test
{
    public int Id { get; set; }

    public string TestType { get; set; } = null!;

    public DateOnly Date { get; set; }

    public byte[] Result { get; set; } = null!;

    public int PetId { get; set; }

    public virtual Pet? Pet { get; set; } = null!;
}
