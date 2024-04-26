using Microsoft.AspNetCore.Mvc;
using Domain;
using Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIproyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicRepository _clinicRepository;

        public ClinicController(IClinicRepository clinicRepository)
        {
            _clinicRepository = clinicRepository ?? throw new ArgumentNullException(nameof(clinicRepository));
        }

        // GET: api/Clinic
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clinic>>> GetClinics()
        {
            var clinics = await _clinicRepository.GetClinics();
            return Ok(clinics);
        }

        // GET: api/Clinic/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clinic>> GetClinic(int id)
        {
            var clinic = await _clinicRepository.GetClinicById(id);
            if (clinic == null)
            {
                return NotFound();
            }
            return clinic;
        }

        // POST: api/Clinic
        [HttpPost]
        public async Task<ActionResult<Clinic>> PostClinic(Clinic clinic)
        {
            await _clinicRepository.AddClinic(clinic);
            return CreatedAtAction("GetClinic", new { id = clinic.Id }, clinic);
        }

        // PUT: api/Clinic/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClinic(int id, Clinic clinic)
        {
            if (id != clinic.Id)
            {
                return BadRequest();
            }
            await _clinicRepository.UpdateClinic(clinic);
            return NoContent();
        }

        // DELETE: api/Clinic/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClinic(int id)
        {
            await _clinicRepository.DeleteClinic(id);
            return NoContent();
        }
    }
}
