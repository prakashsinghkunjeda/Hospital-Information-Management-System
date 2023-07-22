using Azure.Identity;

namespace Hospital.Model
{
    public class UserCredential
    {  
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
