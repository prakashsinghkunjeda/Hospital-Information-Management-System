namespace Hospital.DTO
{
    public class DoctorDTO
    {
        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Specialist { get; set; }
        public bool IsActive { get; set; }
    }
}
