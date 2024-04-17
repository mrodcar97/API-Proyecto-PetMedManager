using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataContext;
using Domain;


namespace APIproyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
         private readonly DataBaseContext _context;

         public UsuarioController(DataBaseContext context)
         {
             _context = context;
         }

         // GET: api/Usuario
         [HttpGet]
         public async Task<ActionResult<IEnumerable<User>>> GetUsuarios()
         {
             return await _context.Users.ToListAsync();
         }

         // GET: api/Usuario/5
         [HttpGet("{id}")]
         public async Task<ActionResult<User>> GetUsuario(int id)
         {
             var usuario = await _context.Users.FindAsync(id);

             if (usuario == null)
             {
                 return NotFound();
             }

             return usuario;
         }

         // POST: api/Usuario
         [HttpPost]
         public async Task<ActionResult<User>> PostUsuario(User usuario)
         {
             _context.Users.Add(usuario);
             await _context.SaveChangesAsync();

             return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
         }

         // PUT: api/Usuario/5
         [HttpPut("{id}")]
         public async Task<IActionResult> PutUsuario(int id, User usuario)
         {
             if (id != usuario.Id)
             {
                 return BadRequest();
             }

             _context.Entry(usuario).State = EntityState.Modified;

             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!UsuarioExists(id))
                 {
                     return NotFound();
                 }
                 else
                 {
                     throw;
                 }
             }

             return NoContent();
         }

         // DELETE: api/Usuario/5
         [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteUsuario(int id)
         {
             var usuario = await _context.Users.FindAsync(id);
             if (usuario == null)
             {
                 return NotFound();
             }

             _context.Users.Remove(usuario);
             await _context.SaveChangesAsync();

             return NoContent();
         }

         private bool UsuarioExists(int id)
         {
             return _context.Users.Any(e => e.Id == id);
         }
     }
   }

