using Lab5LKPZ.Data;
using Lab5LKPZ.Interfaces;
using Lab5LKPZ.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5LKPZ.Mapping
{
    public static class MedicalAppointmentDataMapper
    {
        public static MedicalAppointmentModel MapToEntity(IMedicalAppointments model, MedicalAppointmentModel existingAppointment = null)
        {
          
            if(existingAppointment == null)
            {
                existingAppointment = new MedicalAppointmentModel();
            }


            existingAppointment.PatientID = model.PatientID;
            existingAppointment.Diagnosis = model.Diagnosis;
            existingAppointment.AppointmentDate = model.AppointmentDate;
            existingAppointment.Doctor = model.Doctor;
            existingAppointment.Description = model.Description;
            existingAppointment.Treatment = model.Treatment;


            return existingAppointment;


        }
    }
}
