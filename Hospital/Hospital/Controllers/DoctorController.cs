using Hospital.DAL;
using Hospital.DTO;
using Hospital.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly HospitalDbContext db;
        public DoctorController(HospitalDbContext _db)
        {
            this.db = _db;
        }

        // GET: api/<DoctorController>
        [HttpGet]
        public IActionResult Doctors()
        {
            var doctorList = db.Doctors.Where(a=>a.IsActive==true).ToList();
            return Ok (doctorList) ;
        }

        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var doctor = db.Doctors.Where(x => x.DoctorId == id).FirstOrDefault();
            return Ok (doctor);
        }
        // POST api/<DoctorController>
        [HttpPost]
        public void AddDoctor([FromBody] DoctorDTO doctorDTO)
        {   // doc specify all the properties of the doctor model
            
            Doctor newDoctor= new Doctor();//this create the new row for each new data entry
            newDoctor.FirstName = doctorDTO.FirstName;// we pass the data that is arrived in doc to the newDoctor instance
            newDoctor.LastName  = doctorDTO.LastName;
            newDoctor.Address = doctorDTO.Address;
            newDoctor.PhoneNumber= doctorDTO.PhoneNumber;
            newDoctor.Specialist= doctorDTO.Specialist;
            newDoctor.IsActive = true;
            db.Add(newDoctor);
            db.SaveChanges();

        }

        // PUT api/<DoctorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DoctorDTO doctorDTO)
        {
            var editDoctor = db.Doctors.Where(a => a.DoctorId == id).FirstOrDefault();
            editDoctor.FirstName= doctorDTO.FirstName;
            editDoctor.LastName= doctorDTO.LastName;    
            editDoctor.Address= doctorDTO.Address;
            editDoctor.PhoneNumber= doctorDTO.PhoneNumber;  
            editDoctor.Specialist = doctorDTO.Specialist;
            db.SaveChanges();
            return Ok(editDoctor);
            

        }

        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var doctor=db.Doctors.Where((a)=>a.DoctorId==id).FirstOrDefault();
            /*db.Doctors.Remove(doctor); permenant Deletion of Doctor
            // we dont use such approach since we have the realtion to other tables
            db.SaveChanges();*/
            doctor.IsActive=false;
            db.SaveChanges();
        }
    }
}
