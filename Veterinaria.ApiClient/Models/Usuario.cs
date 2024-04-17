using System;
using System.Collections.Generic;
using System.Text;

namespace Veterinaria.ApiClient.Models
{
    public class Usuario
    {

        public int Id { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Rango { get; set; } = null!;
    }
}
