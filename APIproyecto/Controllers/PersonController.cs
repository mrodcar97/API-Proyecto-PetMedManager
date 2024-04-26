using Microsoft.AspNetCore.Mvc;
using Domain;
using Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Repositories.Repositories;

namespace APIproyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
        }

        // GET: api/Person
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            var people = await _personRepository.GetPeople();
            return Ok(people);
        }

        // GET: api/Person/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _personRepository.GetPersonById(id);
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
            await _personRepository.AddPerson(person);
            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }
            await _personRepository.UpdatePerson(person);
            return NoContent();
        }

        // DELETE: api/Person/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            await _personRepository.DeletePerson(id);
            return NoContent();
        }
    }
}
