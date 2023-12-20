using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Lab5LKPZ.Interfaces;

namespace Lab5LKPZ.Model
{
    public class AddMedicalRecordRequest: IMedicalRecords
    {

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string VisitDates { get; set; }
        public string PreviousIllnesses { get; set; }
        public string Surgeries { get; set; }
        public string Allergies { get; set; }
        public string Medications { get; set; }
        public string DosageInstructions { get; set; }
        // public DateTime LabTestDate { get; set; }
        public string LabTestResults { get; set; }
        public string Immunizations { get; set; }
        public string DoctorsNotes { get; set; }
        public string EmergencyContacts { get; set; }
        public List<MedicalAppointmentModel> Appointments { get; set; }

    }
}
