using Microsoft.VisualBasic;

namespace Hospital.DTO
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public int Age { get; set; }
        public int DoctorId { get; set; }
        public DateTime VisitDate { get; set;}
    }
}
