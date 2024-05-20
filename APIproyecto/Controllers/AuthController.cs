using Microsoft.AspNetCore.Mvc;
using System.Windows;
using Services;
using Domain; // Asegúrate de importar el espacio de nombres donde está la clase LoginResponse

namespace APIproyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService;
        private readonly IPersonService _personService;

        public AuthController(IJwtService jwtService, IUserService userService)
        {
            _jwtService = jwtService;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(User userFront)
        {
            var user = await _userService.GetUserByEmail(userFront.Email);

            if (user == null || user.Password != userFront.Password)
            {
                return BadRequest("Credenciales inválidas. Verifica tu correo electrónico y contraseña.");
            }
            else
            {
                var person = await _personService.GetPersonById(user.PersonId);
                var token = _jwtService.GenerateToken(person);

                return Ok(new LoginResponse { token = token,user = user});

            }
        }
    }
}

