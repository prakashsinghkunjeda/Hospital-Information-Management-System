namespace Hospital.Model
{
    public class Patient
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public  string Contact { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
        public Doctor Doctor { get; set; }

          
    }
}
