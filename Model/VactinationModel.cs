using Lab5LKPZ.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Lab5LKPZ.Model
{
    public class VactinationModel
    {
        [Key]
        public int VaccinationId { get; set; }

        [ForeignKey("MedicalRecord")]
        public int PatientId { get; set; }

        public string VaccineName { get; set; }
        public string VaccinationDate { get; set; }
        public string Description { get; set; }
        public string DoctorName { get; set; }

        // Навігаційне властивість для зв'язку між таблицями
        [JsonIgnore]
        public MedicalRecordModel MedicalRecord { get; set; }
    }
}
