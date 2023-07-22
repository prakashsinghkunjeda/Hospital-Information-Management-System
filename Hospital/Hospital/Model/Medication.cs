namespace Hospital.Model
{
    public class Medication
    {
        public int Id { get; set; }
        public string Medicine { get; set; }
        
        public PatientProblem PatientProblem { get; set; }


    }
}
