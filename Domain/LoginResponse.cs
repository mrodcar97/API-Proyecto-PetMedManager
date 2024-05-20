namespace Domain
{
    public class LoginResponse
    {
        public string token { get; set; }

        public User user { get; set; }
        // Puedes agregar más propiedades según tus necesidades, como por ejemplo el ID del usuario, su nombre, etc.
    }
}


