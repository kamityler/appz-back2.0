using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lab5LKPZ.Model
{
    public class DoctorPatientRelation
    {
        [Key]
        public int DoctorID { get; set; }
        [Key]
        public int PatientID { get; set; }
        [JsonIgnore]
        [ForeignKey("DoctorID")]
        public DoctorModel Doctor { get; set; }

        [ForeignKey("PatientID")]
        public MedicalRecordModel Patient { get; set; }
    }
}
