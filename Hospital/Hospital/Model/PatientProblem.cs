namespace Hospital.Model
{
    public class PatientProblem
    {
        public int Id { get; set; }
        public string Problem { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public DateTime ProblemVisitDate { get; set; }
        public string ProblemMedications { get; set; }

    }
}
