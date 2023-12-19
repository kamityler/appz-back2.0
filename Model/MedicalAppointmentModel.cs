using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Lab5LKPZ.Model
{
    public class MedicalAppointmentModel
    {
        [Key]
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public string AppointmentType { get; set; }
        public string Diagnosis { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Doctor { get; set; }
        public string Description { get; set; }
        public string Treatment { get; set; }

        [JsonIgnore]
        public  MedicalRecordModel MedicalRecord { get; set; }
    }
}
