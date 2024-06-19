using Microsoft.AspNetCore.Mvc;
using Domain;
using Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIproyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService ?? throw new ArgumentNullException(nameof(appointmentService));
        }

        // GET: api/Appointment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            var appointments = await _appointmentService.GetAppointments();
            return Ok(appointments);
        }

        // GET: api/Appointment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            var appointment = await _appointmentService.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return appointment;
        }
        // GET: api/Appointment//(fecha)
        [HttpGet("for{date}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments(string date)
        {
            if (!DateOnly.TryParse(date, out DateOnly parsedDate))
            {
                return BadRequest("Invalid date format.");
            }

            var appointments = await _appointmentService.GetAppointmentsByDate(parsedDate);

            if (appointments == null || !appointments.Any())
            {
                return NotFound();
            }

            return Ok(appointments);
        }

        // POST: api/Appointment
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
            await _appointmentService.AddAppointment(appointment);
            return CreatedAtAction("GetAppointment", new { id = appointment.Id }, appointment);
        }

        // PUT: api/Appointment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return BadRequest();
            }
            await _appointmentService.UpdateAppointment(appointment);
            return NoContent();
        }

        // DELETE: api/Appointment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            await _appointmentService.DeleteAppointment(id);
            return NoContent();
        }
    }
}
