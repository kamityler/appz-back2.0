using Lab5LKPZ.Interfaces;
using System;

namespace Lab5LKPZ.Model
{
    public class AddMedicalAppointmentModel : IMedicalAppointments
    {
        
        public int PatientID { get; set; }
        public string Diagnosis { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Doctor { get; set; }
        public string Description { get; set; }
        public string Treatment { get; set; }
        public string AppointmentType { get; set; }
    }
}
