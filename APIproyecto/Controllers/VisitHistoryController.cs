using Microsoft.AspNetCore.Mvc;
using Domain;
using Services;


namespace APIproyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitHistoryController : ControllerBase
    {
        private readonly IVisitHistoryService _VisitHistoryService;

        public VisitHistoryController(IVisitHistoryService VisitHistoryService)
        {
            _VisitHistoryService = VisitHistoryService ?? throw new ArgumentNullException(nameof(VisitHistoryService));
        }

        // GET: api/VisitHistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisitHistory>>> GetVisitHistories()
        {
            var VisitHistorys = await _VisitHistoryService.GetVisitHistories();
            return Ok(VisitHistorys);
        }

        // GET: api/VisitHistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VisitHistory>> GetVisitHistory(int id)
        {
            var VisitHistory = await _VisitHistoryService.GetVisitHistoryById(id);
            if (VisitHistory == null)
            {
                return NotFound();
            }
            return VisitHistory;
        }

        [HttpGet("ByPet{id}")]
        public async Task<ActionResult<IEnumerable<VisitHistory>>> GetVisitHistoryByPet(int id)
        {
            var VisitHistory = await _VisitHistoryService.GetVisitHistoriesByPet(id);
            if (VisitHistory == null)
            {
                return NotFound();
            }
            return VisitHistory;
        }


        // POST: api/VisitHistory
        [HttpPost]
        public async Task<ActionResult<VisitHistory>> PostVisitHistory(VisitHistory VisitHistory)
        {
            await _VisitHistoryService.AddVisitHistory(VisitHistory);
            return CreatedAtAction("GetVisitHistory", new { id = VisitHistory.Id }, VisitHistory);
        }

        // PUT: api/VisitHistory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisitHistory(int id, VisitHistory VisitHistory)
        {
            if (id != VisitHistory.Id)
            {
                return BadRequest();
            }
            await _VisitHistoryService.UpdateVisitHistory(VisitHistory);
            return NoContent();
        }

        // DELETE: api/VisitHistory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisitHistory(int id)
        {
            await _VisitHistoryService.DeleteVisitHistory(id);
            return NoContent();
        }
    }
}

