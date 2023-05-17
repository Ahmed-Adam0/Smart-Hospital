namespace Smart_Hospital.Models
{
    public class Patient : Person
    {

        public Patient()
        {
            MedicalRecords = new HashSet<MedicalRecord>();
        }

        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }

    }
}
