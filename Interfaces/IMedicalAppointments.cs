using Lab5LKPZ.Model;
using System;

namespace Lab5LKPZ.Interfaces
{
    public interface IMedicalAppointments
    {
        public int PatientID { get; set; }
        public string Diagnosis { get; set; }
        public int DoctorID { get; set; }
        public string Type { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Doctor { get; set; }
        public string Description { get; set; }
        public string Treatment { get; set; }
        //public MedicalRecordModel MedicalRecord { get; set; }
    }
}
