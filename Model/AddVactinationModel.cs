using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab5LKPZ.Model
{
    public class AddVactinationModel
    {
        [Key]
        public int VaccinationId { get; set; }

        [ForeignKey("MedicalRecord")]
        public int PatientId { get; set; }

        public string VaccineName { get; set; }
        public string VaccinationDate { get; set; }
        public string Description { get; set; }
        public string DoctorName { get; set; }
    }
}
