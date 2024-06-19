using Microsoft.AspNetCore.Mvc;
using Domain;
using DataContext;
using Microsoft.EntityFrameworkCore;
using Services;

namespace APIproyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService ?? throw new ArgumentNullException(nameof(personService));
        }

        // GET: api/Person
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            var people = await _personService.GetPeople();
            return Ok(people);
        }

        // GET: api/Person/5
        [HttpGet("{nationalID}")]
        public async Task<ActionResult<Person>> GetPerson(String nationalID)
        {
            var person = await _personService.GetPersonById(nationalID);
            if (person == null)
            {
                return NotFound();
            }
            return person;
        }

        [HttpGet("ByClinic{clinicID}")]
        public async Task<ActionResult<IEnumerable<Person>>> GetVetsByClinic(String clinicID)
        {
            var person = await _personService.GetVetsByClinic(clinicID);
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
            await _personService.AddPerson(person);
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

            await _personService.UpdatePerson(person);
            return NoContent();
        }

        // DELETE: api/Person/5
        [HttpDelete("{nationalID}")]
        public async Task<IActionResult> DeletePerson(string nationalID)
        {
            await _personService.DeletePerson(nationalID);
            return NoContent();
        }
    }
}
