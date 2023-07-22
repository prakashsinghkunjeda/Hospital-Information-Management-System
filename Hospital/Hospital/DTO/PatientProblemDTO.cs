using Hospital.Model;

namespace Hospital.DTO
{
    public class PatientProblemDTO
    {
        public int Id { get; set; }
        public string Problem { get; set; }
        public int PatientId { get; set; } 
         public DateTime ProblemVisitDate { get; set; }
        public string ProblemMedications { get; set; }
    }
}
