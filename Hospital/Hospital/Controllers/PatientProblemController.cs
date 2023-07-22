using Hospital.DAL;
using Hospital.DTO;
using Hospital.Model;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientProblemController : ControllerBase
    {

        private readonly HospitalDbContext _context;
        public PatientProblemController(HospitalDbContext context)
        {
            _context = context;
        }

        // GET: api/<PatientProblemController>

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PatientProblemController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var problem = _context.PatientProblems.Where(x => x.PatientId == id).ToList();
            return Ok(problem);
        }

        // POST api/<PatientProblemController>
        [HttpPost]
        public IActionResult Post([FromBody] PatientProblemDTO patientProblemDTO)
        {
            var patinet = _context.Patients.FirstOrDefault(x=> x.Id==patientProblemDTO.PatientId);
            var newProblem = new PatientProblem();
            newProblem.Problem=patientProblemDTO.Problem;
            newProblem.Patient = patinet;
            newProblem.ProblemVisitDate = patientProblemDTO.ProblemVisitDate;
            newProblem.ProblemMedications =patientProblemDTO.ProblemMedications;
            _context.Add(newProblem);
            _context.SaveChanges();
            return Ok();
        }

        // PUT api/<PatientProblemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PatientProblemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
