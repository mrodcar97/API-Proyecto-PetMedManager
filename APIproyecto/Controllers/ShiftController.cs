using Domain;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIproyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftService _shiftService;

        public ShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService ?? throw new ArgumentNullException(nameof(shiftService));
        }

        // GET: api/Shift
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shift>>> GetShifts()
        {
            var shifts = await _shiftService.GetShifts();
            return Ok(shifts);
        }

        // GET: api/Shift/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shift>> GetShift(int id)
        {
            var shift = await _shiftService.GetShiftById(id);
            if (shift == null)
            {
                return NotFound();
            }
            return shift;
        }

        // GET: api/Shift/for(date)
        [HttpGet("for{date}")]
        public async Task<ActionResult<IEnumerable<Shift>>> GetShifts(string date)
        {
            if (!DateOnly.TryParse(date, out DateOnly parsedDate))
            {
                return BadRequest("Invalid date format.");
            }

            var shifts = await _shiftService.GetShiftsByDate(parsedDate);

            if (shifts == null || !shifts.Any())
            {
                return NotFound();
            }

            return Ok(shifts);
        }

        // GET: api/Shift/forMonth(date)
        [HttpGet("forMonth/{year:int}/{month:int}")]
        public async Task<ActionResult<List<Shift>>> GetShiftsForMonth(int year, int month)
        {
            try
            {
                var shifts = await _shiftService.GetShiftsForMonth(year, month);
                if (shifts == null || shifts.Count == 0)
                {
                    return NotFound("No shifts found for the specified month.");
                }
                return Ok(shifts);
            }
            catch (Exception ex)
            {
                // Log the exception (ex)
                return StatusCode(500, "Internal server error.");
            }
        }

        // POST: api/Shift
        [HttpPost]
        public async Task<ActionResult<Shift>> PostShift(Shift shift)
        {
            await _shiftService.AddShift(shift);
            return CreatedAtAction("GetShift", new { id = shift.ShiftId }, shift);
        }

        // PUT: api/Shift/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShift(int id, Shift shift)
        {
            if (id != shift.ShiftId)
            {
                return BadRequest();
            }
            await _shiftService.UpdateShift(shift);
            return NoContent();
        }

        // DELETE: api/Shift/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShift(int id)
        {
            await _shiftService.DeleteShift(id);
            return NoContent();
        }
    }
}
