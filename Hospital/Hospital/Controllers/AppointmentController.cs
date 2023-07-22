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
    public class AppointmentController : ControllerBase
    {
        private readonly HospitalDbContext _context;
        public AppointmentController(HospitalDbContext context)
        {
            this._context = context;
        }

        
        // GET: api/<AppointmentController>
        [HttpGet]
        public ActionResult<List<AppointmentDTO>> Get()
        {
            var appointment = _context.Appointments.Include(x => x.Doctor).ToList();
            return Ok(appointment);
        }

        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public void Post([FromBody] AppointmentDTO appointmentDTO)
        {
            var Doctor = _context.Doctors.Where(x => x.DoctorId == appointmentDTO.DoctorId).FirstOrDefault();

            Appointment newAppointmentPatient = new Appointment();
            newAppointmentPatient.FirstName = appointmentDTO.FirstName;
            newAppointmentPatient.LastName = appointmentDTO.LastName;
            newAppointmentPatient.Address = appointmentDTO.Address;
            newAppointmentPatient.Contact = appointmentDTO.Contact;
            newAppointmentPatient.Age = appointmentDTO.Age;
            newAppointmentPatient.VisitDate=appointmentDTO.VisitDate;
            newAppointmentPatient.Doctor = Doctor;
            _context.Add(newAppointmentPatient);
            _context.SaveChanges();
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
