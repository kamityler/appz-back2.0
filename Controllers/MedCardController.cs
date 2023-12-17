using Lab5LKPZ.Data;
using Lab5LKPZ.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Lab5LKPZ.Mapping;
using Lab5LKPZ.Command;

namespace Lab5LKPZ.Controllers
{
    namespace Lab5LKPZ.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class MedicalRecordsController : Controller
        {
            private readonly MedicalApiDbContext dbContext;

           // private readonly Data.MedicalApiDbContext dbContext;

            public MedicalRecordsController(Data.MedicalApiDbContext dbContext)
            {
                this.dbContext = MedicalApiDbContext.Instance;
            }
            

            [HttpGet]
            public async Task<IActionResult> GetMedicalRecords()
            {
                var command = new GetMedicalRecordsCommand(dbContext);
                var invoker = new CommandInvoker();
                invoker.SetCommand(command);

                return await invoker.ExecuteCommand();
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
                var command = new GetMedicalRecordByIdCommand(dbContext,id);
                var invoker = new CommandInvoker();
                invoker.SetCommand(command);

                return await invoker.ExecuteCommand();
            }

         

            [HttpPost]
            [Route("{id:int}/Appointments")]

            public async Task<IActionResult> AddMedicalAppointment([FromRoute] int id,[FromBody] Model.AddMedicalAppointmentModel medicalAppointment)
            {

                var record = MedicalAppointmentDataMapper.MapToEntity(medicalAppointment);
                record.PatientID = id;
                var medicalRecord = await dbContext.MedicalRecords
                        .Include(m => m.Appointments) // Якщо ви хочете включити призначення
                        .FirstOrDefaultAsync(m => m.PatientID == id);

                if (medicalRecord == null)
                {
                    return BadRequest(); // Повертаємо 404, якщо медичний запис не знайдено
                }
                await dbContext.MedicalAppointment.AddAsync(record);

                await dbContext.SaveChangesAsync();
                return Ok(record);

          
            }
            [HttpPost]
            public async Task<IActionResult> AddMedicalRecord(Model.AddMedicalRecordRequest medicalRecord)
            {
                var record = Mapping.MedicalRecordDataMapper.MapToEntity(medicalRecord);

                if (record.FirstName == null || record.LastName == null || record.MiddleName == null || Regex.IsMatch(record.FirstName, @"\d"))
                {
                    return BadRequest();
                }
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

                    record = Mapping.MedicalRecordDataMapper.MapToEntity(updateMedicalRecordRequest, record);
                  
                    //  record.LastName = updateMedicalRecordRequest.LastName;
                  //  record.FirstName = updateMedicalRecordRequest.FirstName;
                  //  record.MiddleName = updateMedicalRecordRequest.MiddleName;
                  ////  record.DateOfBirth = updateMedicalRecordRequest.DateOfBirth;
                  //  record.Gender = updateMedicalRecordRequest.Gender;
                  //  record.Address = updateMedicalRecordRequest.Address;
                  //  record.PhoneNumber = updateMedicalRecordRequest.PhoneNumber;
                  //  record.Email = updateMedicalRecordRequest.Email;
                  //  record.VisitDates = updateMedicalRecordRequest.VisitDates;
                  //  record.PreviousIllnesses = updateMedicalRecordRequest.PreviousIllnesses;
                  //  record.Surgeries = updateMedicalRecordRequest.Surgeries;
                  //  record.Allergies = updateMedicalRecordRequest.Allergies;
                  //  record.Medications = updateMedicalRecordRequest.Medications;
                  //  record.DosageInstructions = updateMedicalRecordRequest.DosageInstructions;
                  ////  record.LabTestDate = updateMedicalRecordRequest.LabTestDate;
                  //  record.LabTestResults = updateMedicalRecordRequest.LabTestResults;
                  //  record.Immunizations = updateMedicalRecordRequest.Immunizations;
                  //  record.DoctorsNotes = updateMedicalRecordRequest.DoctorsNotes;
                  //  record.EmergencyContacts = updateMedicalRecordRequest.EmergencyContacts;
                    if(record.FirstName == "" || record.MiddleName=="" || record.LastName == "")
                    {
                        return BadRequest(record);
                    }
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
