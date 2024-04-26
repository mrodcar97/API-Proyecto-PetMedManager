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
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _petRepository;

        public PetController(IPetRepository petRepository)
        {
            _petRepository = petRepository ?? throw new ArgumentNullException(nameof(petRepository));
        }

        // GET: api/Pet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets()
        {
            var pets = await _petRepository.GetPets();
            return Ok(pets);
        }

        // GET: api/Pet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetPet(int id)
        {
            var pet = await _petRepository.GetPetById(id);
            if (pet == null)
            {
                return NotFound();
            }
            return pet;
        }

        // POST: api/Pet
        [HttpPost]
        public async Task<ActionResult<Pet>> PostPet(Pet pet)
        {
            await _petRepository.AddPet(pet);
            return CreatedAtAction("GetPet", new { id = pet.Id }, pet);
        }

        // PUT: api/Pet/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPet(int id, Pet pet)
        {
            if (id != pet.Id)
            {
                return BadRequest();
            }
            await _petRepository.UpdatePet(pet);
            return NoContent();
        }

        // DELETE: api/Pet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            await _petRepository.DeletePet(id);
            return NoContent();
        }
    }
}
