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

        public AuthController(IJwtService jwtService, IUserService userService, IPersonService personService)
        {
            _jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _personService = personService ?? throw new ArgumentNullException(nameof(personService));
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(User userFront)
        {
            if (userFront == null)
            {
                return BadRequest("Request is null.");
            }

            var user = await _userService.GetUserByEmail(userFront.Email);

            if (user == null || user.Password != userFront.Password)
            {
                return BadRequest("Credenciales inválidas.");
            }

            var person = await _personService.GetPersonById(user.PersonId);

            if (person == null)
            {
                return BadRequest("No se encontró el usuario.");
            }
            else
            {


            var token = _jwtService.GenerateToken(person);


            return Ok(new LoginResponse {token = token});
            }

            }
        }
    }


