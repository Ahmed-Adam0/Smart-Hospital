using System.ComponentModel.DataAnnotations.Schema;

namespace Smart_Hospital.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public DateTime admssiondate { get; set; }
        public DateTime dischargedate { get; set; }
        public string Diagnosis { get; set; }
        public virtual Doctor doctor { get; set; }
        [ForeignKey(nameof(doctor))]
        public int DoctorId { get; set; }
    }
}
