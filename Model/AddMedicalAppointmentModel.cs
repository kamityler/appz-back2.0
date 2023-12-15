using System;

namespace Lab5LKPZ.Model
{
    public class AddMedicalAppointmentModel
    {
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public string Diagnosis { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Doctor { get; set; }
        public string Description { get; set; }
        public string Treatment { get; set; }
    }
}
