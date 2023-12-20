﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Lab5LKPZ.Interfaces;

namespace Lab5LKPZ.Model
{
    public class AddMedicalRecordRequest : IMedicalRecords
    {

        public int PatientID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string DateOfBirth { get; set; }
        public bool groupDispensary { get; set; }
        public string completionDate { get; set; }
        public string Contingents { get; set; }
        public string privilegeNumber { get; set; }
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
        public string Workplace { get; set; }
        public string Position { get; set; }
        public List<MedicalAppointmentModel> Appointments { get; set; }
        public List<Disease> Diseases { get; set; }


    }
}