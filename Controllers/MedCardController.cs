using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                return Ok(await this.dbContext.MedicalRecords.ToListAsync());
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

            [HttpGet]
            [Route("{id:int}")]
            public async Task<IActionResult> GetMedicalRecordById([FromRoute] int id)
            {
                var record = await dbContext.MedicalRecords.FindAsync(id);
                if (record != null)
                {
                    return Ok(record);
                }

                return NotFound();
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
        }
    }
}
