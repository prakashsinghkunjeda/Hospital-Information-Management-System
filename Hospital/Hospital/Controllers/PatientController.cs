using Hospital.DAL;
using Hospital.DTO;
using Hospital.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly HospitalDbContext _context;
        public PatientController(HospitalDbContext context)
        {
            this._context = context;
        }
        // GET: api/<PatientController>
       
        [HttpGet]
        public ActionResult<List<PatientDTO>> Get()
        {
            /* var Patient = _context.Patients.Where(a => a.IsActive == true).ToList();
             return Ok(Patient);*/
            var patient = _context.Patients.Include(x => x.Doctor).ToList();
            return Ok(patient);
        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var PatientRow = _context.Patients.Where(x => x.Id == id).Include(x => x.Doctor).FirstOrDefault();
            return Ok(PatientRow);
        }

        // POST api/<PatientController>
        [HttpPost]
        public void Post([FromBody] PatientDTO patientDTO)
        {
            var Doctor = _context.Doctors.Where(x => x.DoctorId == patientDTO.DoctorId).FirstOrDefault();

            Patient newPatient = new Patient();
            newPatient.FirstName = patientDTO.FirstName;
            newPatient.LastName = patientDTO.LastName;
            newPatient.Address = patientDTO.Address;
            newPatient.Contact = patientDTO.Contact;
            newPatient.Age = patientDTO.Age;
            newPatient.Doctor = Doctor;
            _context.Add(newPatient);
            _context.SaveChanges();
        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var patient = _context.Patients.Where((a) => a.Id == id).FirstOrDefault();
            patient.IsActive = false;
            _context.SaveChanges();
        }
    }
}
