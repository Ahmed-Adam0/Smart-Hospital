namespace Smart_Hospital.Models
{
    public class Doctor : Person
    {
        public Doctor()
        {
               MedicalRecords=new HashSet<MedicalRecord>();
        }
        public string Speciality { get; set; }
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
}
