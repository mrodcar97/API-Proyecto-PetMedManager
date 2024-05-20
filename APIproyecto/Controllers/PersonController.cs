using Microsoft.AspNetCore.Mvc;
using Domain;
using DataContext;
using Microsoft.EntityFrameworkCore;

namespace APIproyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly DataBaseContext _dbContext;

        public PersonController(DataBaseContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        // GET: api/Person
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            var people = await _dbContext.People.ToListAsync();
            return Ok(people);
        }

        // GET: api/Person/5
        [HttpGet("{nationalID}")]
        public async Task<ActionResult<Person>> GetPerson(String nationalID)
        {
            var person = await _dbContext.People.FindAsync(nationalID);
            if (person == null)
            {
                return NotFound();
            }
            return person;
        }

        // POST: api/Person
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _dbContext.People.Add(person);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPerson), new {nationalID = person.NationalId }, person);
        }

        // PUT: api/Person/5
        [HttpPut("{nationalID}")]
        public async Task<IActionResult> PutPerson(String nationalID, Person person)
        {
            if (nationalID != person.NationalId)
            {
                return BadRequest();
            }

            _dbContext.Entry(person).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(nationalID))
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

        // DELETE: api/Person/5
        [HttpDelete("{nationalID}")]
        public async Task<IActionResult> DeletePerson(String nationalID)
        {
            var person = await _dbContext.People.FindAsync(nationalID);
            if (person == null)
            {
                return NotFound();
            }

            _dbContext.People.Remove(person);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(String nationalID)
        {
            return _dbContext.People.Any(e => e.NationalId == nationalID);
        }
    }
}
