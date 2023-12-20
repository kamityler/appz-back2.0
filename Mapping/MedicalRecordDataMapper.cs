using Lab5LKPZ.Data;
using Lab5LKPZ.Interfaces;
using Lab5LKPZ.Mapping;
using Lab5LKPZ.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace Lab5LKPZ.Mapping
{
    public static class MedicalRecordDataMapper
    {
        public static DbSet<MedicalRecordModel> MapToModel(MedicalApiDbContext dbContextRecord)
        {
            if (dbContextRecord == null)
                return null;

            return dbContextRecord.MedicalRecords;

        }

        public static MedicalRecordModel MapToEntity(IMedicalRecords MedicalRecordModel, MedicalRecordModel existingRecord = null)
        {

            if (existingRecord == null)
            {
                existingRecord = new MedicalRecordModel();


            }
            
                
                existingRecord.FirstName = MedicalRecordModel.FirstName;
                existingRecord.MiddleName = MedicalRecordModel.MiddleName;
                existingRecord.LastName = MedicalRecordModel.LastName;
            //existingRecord.DateOfBirth = MedicalRecordModel.DateOfBirth;
                existingRecord.Gender = MedicalRecordModel.Gender;
                existingRecord.Address = MedicalRecordModel.Address;
                existingRecord.PhoneNumber = MedicalRecordModel.PhoneNumber;
                existingRecord.Email = MedicalRecordModel.Email;
                existingRecord.VisitDates = MedicalRecordModel.VisitDates;
                existingRecord.PreviousIllnesses = MedicalRecordModel.PreviousIllnesses;
                existingRecord.Surgeries = MedicalRecordModel.Surgeries;
                existingRecord.Allergies = MedicalRecordModel.Allergies;
                existingRecord.Medications = MedicalRecordModel.Medications;
                existingRecord.DosageInstructions = MedicalRecordModel.DosageInstructions;
                existingRecord.LabTestResults = MedicalRecordModel.LabTestResults;
                existingRecord.Immunizations = MedicalRecordModel.Immunizations;
                existingRecord.DoctorsNotes = MedicalRecordModel.DoctorsNotes;
                existingRecord.EmergencyContacts = MedicalRecordModel.EmergencyContacts;
                existingRecord.Appointments = MedicalRecordModel.Appointments;
                existingRecord.Diseases = MedicalRecordModel.Diseases;
                return existingRecord;
            
            
        }

       
    }
}