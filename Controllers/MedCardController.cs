using Lab5LKPZ.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5LKPZ.Controllers
{
    namespace Lab5LKPZ.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class MedicalRecordsController : Controller
        {
            private readonly Data.BooksApiDbContext dbContext;

            public MedicalRecordsController(Data.BooksApiDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            

            [HttpGet]
            public async Task<IActionResult> GetMedicalRecords()
            {
                return Ok(await this.dbContext.MedicalRecords.Include(m => m.Appointments).ToListAsync());
            }

            [HttpGet("Appointments")]
            public async Task<IActionResult> GetMedicalAppointments()
            {
                var appointments = await dbContext.MedicalAppointment.ToListAsync();
                return Ok(appointments);
            }
            [HttpGet("{id:int}/Appointments")]
            public async Task<IActionResult> GetMedicalRecordAppointments([FromRoute] int id)
            {
                var record = await dbContext.MedicalRecords.Include(m => m.Appointments).FirstOrDefaultAsync(m => m.PatientID == id);

                if (record != null)
                {
                    return Ok(record.Appointments);
                }

                return NotFound();
            }
            [HttpGet]
            [Route("{id:int}")]
            public async Task<IActionResult> GetMedicalRecordById([FromRoute] int id)
            {
                try
                {
                    var medicalRecord = await dbContext.MedicalRecords
                        .Include(m => m.Appointments) // Якщо ви хочете включити призначення
                        .FirstOrDefaultAsync(m => m.PatientID == id);

                    if (medicalRecord == null)
                    {
                        return NotFound(); // Повертаємо 404, якщо медичний запис не знайдено
                    }

                    return Ok(medicalRecord); // Повертаємо успішний результат знайденого медичного запису
                }
                catch (Exception ex)
                {
                    // Обробка можливих помилок
                    return StatusCode(500, $"Internal Server Error: {ex.Message}");
                }
            }

         

            [HttpPost]
            [Route("{id:int}/Appointments")]

            public async Task<IActionResult> AddMedicalAppointment([FromRoute] int id,[FromBody] Model.AddMedicalAppointmentModel medicalAppointment)
            {

                var record = new Model.MedicalAppointmentModel()
                {
                    PatientID = id,
                    Diagnosis = medicalAppointment.Diagnosis,
                    AppointmentDate = medicalAppointment.AppointmentDate,
                    Doctor = medicalAppointment.Doctor,
                    Description = medicalAppointment.Description,
                    Treatment = medicalAppointment.Treatment
                };

                await dbContext.MedicalAppointment.AddAsync(record);
                await dbContext.SaveChangesAsync();
                return Ok(record);

          
            }
            [HttpPost]
            public async Task<IActionResult> AddMedicalRecord(Model.MedicalRecordModel medicalRecord)
            {
                var record = new Model.MedicalRecordModel()
                {
                    LastName = medicalRecord.LastName,
                    FirstName = medicalRecord.FirstName,
                    MiddleName = medicalRecord.MiddleName,
                    DateOfBirth = medicalRecord.DateOfBirth,
                    Gender = medicalRecord.Gender,
                    Address = medicalRecord.Address,
                    PhoneNumber = medicalRecord.PhoneNumber,
                    Email = medicalRecord.Email,
                    VisitDates = medicalRecord.VisitDates,
                    PreviousIllnesses = medicalRecord.PreviousIllnesses,
                    Surgeries = medicalRecord.Surgeries,
                    Allergies = medicalRecord.Allergies,
                    Medications = medicalRecord.Medications,
                    DosageInstructions = medicalRecord.DosageInstructions,
                    LabTestDate = medicalRecord.LabTestDate,
                    LabTestResults = medicalRecord.LabTestResults,
                    Immunizations = medicalRecord.Immunizations,
                    DoctorsNotes = medicalRecord.DoctorsNotes,
                    EmergencyContacts = medicalRecord.EmergencyContacts
                };

                await dbContext.MedicalRecords.AddAsync(record);
                await dbContext.SaveChangesAsync();
                return Ok(record);
            }

            [HttpPut]
            [Route("{id:int}")]
            public async Task<IActionResult> UpdateMedicalRecord([FromRoute] int id, Model.UpdateMedicalRecordRequest updateMedicalRecordRequest)
            {
                var record = await dbContext.MedicalRecords.FindAsync(id);
                if (record != null)
                {
                    record.LastName = updateMedicalRecordRequest.LastName;
                    record.FirstName = updateMedicalRecordRequest.FirstName;
                    record.MiddleName = updateMedicalRecordRequest.MiddleName;
                    record.DateOfBirth = updateMedicalRecordRequest.DateOfBirth;
                    record.Gender = updateMedicalRecordRequest.Gender;
                    record.Address = updateMedicalRecordRequest.Address;
                    record.PhoneNumber = updateMedicalRecordRequest.PhoneNumber;
                    record.Email = updateMedicalRecordRequest.Email;
                    record.VisitDates = updateMedicalRecordRequest.VisitDates;
                    record.PreviousIllnesses = updateMedicalRecordRequest.PreviousIllnesses;
                    record.Surgeries = updateMedicalRecordRequest.Surgeries;
                    record.Allergies = updateMedicalRecordRequest.Allergies;
                    record.Medications = updateMedicalRecordRequest.Medications;
                    record.DosageInstructions = updateMedicalRecordRequest.DosageInstructions;
                    record.LabTestDate = updateMedicalRecordRequest.LabTestDate;
                    record.LabTestResults = updateMedicalRecordRequest.LabTestResults;
                    record.Immunizations = updateMedicalRecordRequest.Immunizations;
                    record.DoctorsNotes = updateMedicalRecordRequest.DoctorsNotes;
                    record.EmergencyContacts = updateMedicalRecordRequest.EmergencyContacts;

                    await dbContext.SaveChangesAsync();
                    return Ok(record);
                }

                return NotFound();
            }

            [HttpDelete]
            [Route("{id:int}")]
            public async Task<IActionResult> DeleteMedicalRecord([FromRoute] int id)
            {
                var record = await dbContext.MedicalRecords.FindAsync(id);
                if (record != null)
                {
                    dbContext.MedicalRecords.Remove(record);
                    await dbContext.SaveChangesAsync();
                    return Ok(record);
                }

                return NotFound();
            }
            [HttpGet("GetPatients")]
            public async Task<IActionResult> GetPatients(
            [FromQuery] string lastName,
            [FromQuery] string firstName,
            [FromQuery] string middleName)
            {
                var patientsQuery = dbContext.MedicalRecords.AsQueryable();

                if (!string.IsNullOrEmpty(lastName))
                {
                    patientsQuery = patientsQuery.Where(p => p.LastName == lastName);
                }

                if (!string.IsNullOrEmpty(firstName))
                {
                    patientsQuery = patientsQuery.Where(p => p.FirstName == firstName);
                }

                if (!string.IsNullOrEmpty(middleName))
                {
                    patientsQuery = patientsQuery.Where(p => p.MiddleName == middleName);
                }

                var patients = await patientsQuery.ToListAsync();

                if (patients.Any())
                {
                    return Ok(patients);
                }

                return NotFound();
            }
        }
    }
}
