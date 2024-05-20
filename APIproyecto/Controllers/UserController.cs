using Microsoft.AspNetCore.Mvc;
using Domain;
using Services;


namespace APIproyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var Users = await _userService.GetUsers();
            return Ok(Users);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var User = await _userService.GetUserById(id);
            if (User == null)
            {
                return NotFound();
            }
            return User;
        }

        [HttpGet("ByEmail/{Email}")]
        public async Task<ActionResult<User>> GetUserByEmail(String Email)
        {
            var User = await _userService.GetUserByEmail(Email);
            if (User == null)
            {
                return NotFound();
            }
            return User;
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User User)
        {
            await _userService.AddUser(User);
            return CreatedAtAction("GetUser", new { id = User.Id }, User);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User User)
        {
            if (id != User.Id)
            {
                return BadRequest();
            }
            await _userService.UpdateUser(User);
            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
