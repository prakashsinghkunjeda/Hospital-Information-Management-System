using Hospital.DAL;
using Hospital.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private readonly HospitalDbContext _context;
        public MedicationController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: api/<MedicationController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MedicationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MedicationController>
        [HttpPost]
        public IActionResult Post([FromBody] MedicationDTO medications)
        {
            return Ok();
        }

        // PUT api/<MedicationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MedicationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
