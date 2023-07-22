using Hospital.Model;
using Microsoft.EntityFrameworkCore;
//it is used to connect the controller with the database, and create ,manipulation
namespace Hospital.DAL
{
    public class HospitalDbContext : DbContext
    {

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options):base(options)
        {

        }
       
        
        public DbSet<Doctor> Doctors { get; set; }   
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientProblem>PatientProblems { get; set; }
        public DbSet<Medication> Medications{ get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<UserCredential> UserCredentials { get; set; }

    }
}
