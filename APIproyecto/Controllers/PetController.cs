using Microsoft.AspNetCore.Mvc;
using Domain;
using Services;


namespace APIproyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService ?? throw new ArgumentNullException(nameof(petService));
        }

        // GET: api/Pet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets()
        {
            var pets = await _petService.GetPets();
            return Ok(pets);
        }

        // GET: api/Pet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetPet(int id)
        {
            var pet = await _petService.GetPetById(id);
            if (pet == null)
            {
                return NotFound();
            }
            return pet;
        }

        [HttpGet("ByOwner{OwnerId}")]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPetByOwnerId(String OwnerId)
        {
            var pet = await _petService.GetPetByOwnerId(OwnerId);
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
            await _petService.AddPet(pet);
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
            await _petService.UpdatePet(pet);
            return NoContent();
        }

        // DELETE: api/Pet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            await _petService.DeletePet(id);
            return NoContent();
        }
    }
}
