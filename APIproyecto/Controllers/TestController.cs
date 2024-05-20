using Microsoft.AspNetCore.Mvc;
using Domain;
using Repositories;


namespace APIproyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestRepository _testRepository;

        public TestController(ITestRepository testRepository)
        {
            _testRepository = testRepository ?? throw new ArgumentNullException(nameof(testRepository));
        }

        // GET: api/Test
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Test>>> GetTests()
        {
            var tests = await _testRepository.GetTests();
            return Ok(tests);
        }

        // GET: api/Test/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Test>> GetTest(int id)
        {
            var test = await _testRepository.GetTestById(id);
            if (test == null)
            {
                return NotFound();
            }
            return test;
        }

        // POST: api/Test
        [HttpPost]
        public async Task<ActionResult<Test>> PostTest(Test test)
        {
            await _testRepository.AddTest(test);
            return CreatedAtAction("GetTest", new { id = test.Id }, test);
        }

        // PUT: api/Test/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTest(int id, Test test)
        {
            if (id != test.Id)
            {
                return BadRequest();
            }
            await _testRepository.UpdateTest(test);
            return NoContent();
        }

        // DELETE: api/Test/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTest(int id)
        {
            await _testRepository.DeleteTest(id);
            return NoContent();
        }
    }
}
