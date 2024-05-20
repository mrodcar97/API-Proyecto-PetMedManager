using Microsoft.AspNetCore.Mvc;
using Domain;
using Repositories;


namespace APIproyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitHistoryController : ControllerBase
    {
        private readonly IVisitHistoryRepository _VisitHistoryRepository;

        public VisitHistoryController(IVisitHistoryRepository VisitHistoryRepository)
        {
            _VisitHistoryRepository = VisitHistoryRepository ?? throw new ArgumentNullException(nameof(VisitHistoryRepository));
        }

        // GET: api/VisitHistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisitHistory>>> GetVisitHistories()
        {
            var VisitHistorys = await _VisitHistoryRepository.GetVisitHistories();
            return Ok(VisitHistorys);
        }

        // GET: api/VisitHistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VisitHistory>> GetVisitHistory(int id)
        {
            var VisitHistory = await _VisitHistoryRepository.GetVisitHistoryById(id);
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
            await _VisitHistoryRepository.AddVisitHistory(VisitHistory);
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
            await _VisitHistoryRepository.UpdateVisitHistory(VisitHistory);
            return NoContent();
        }

        // DELETE: api/VisitHistory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisitHistory(int id)
        {
            await _VisitHistoryRepository.DeleteVisitHistory(id);
            return NoContent();
        }
    }
}

