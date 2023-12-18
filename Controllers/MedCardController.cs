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
using Lab5LKPZ.Interfaces;
using System.Collections.Generic;

namespace Lab5LKPZ.Controllers
{
    namespace Lab5LKPZ.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class MedicalRecordsController : Controller
        {
            private readonly MedicalApiDbContext dbContext;
            private readonly CommandInvoker invoker;           // private readonly Data.MedicalApiDbContext dbContext;

            public MedicalRecordsController(Data.MedicalApiDbContext dbContext)
            {
                this.dbContext = MedicalApiDbContext.Instance;
                this.invoker = new CommandInvoker(); 
            }
            

            [HttpGet]
            public async Task<IActionResult> GetMedicalRecords()
            {
                var command = new GetMedicalRecordsCommand(dbContext);
                
                invoker.SetCommand(command);

                return await invoker.ExecuteCommand();
            }
            [HttpGet("{id}/Patients")]
            public async Task<ActionResult<IEnumerable<MedicalRecordModel>>> GetPatientsByDoctor(int id)
            {
                // Знайдемо лікаря за його id
                var doctor = await dbContext.Doctors
                    .Include(d => d.Patients)
                    .FirstOrDefaultAsync(d => d.DoctorID == id);

                if (doctor == null)
                {
                    return NotFound(); // Якщо лікар не знайдений, повертаємо 404 Not Found
                }
                var patientIds = doctor.Patients.Select(dp => dp.PatientID).ToList();

                // Завантажуємо пацієнтів з бази даних
                var patients = await dbContext.MedicalRecords
                    .Where(p => patientIds.Contains(p.PatientID))
                    .ToListAsync();
                return Ok(patients);
                // Повертаємо список пацієнтів, призначених цьому лікарю
               //return Ok(doctor.Patients);
            }


            [HttpGet("Appointments")]
            public async Task<IActionResult> GetMedicalAppointments()
            {
                var command = new GetMedicalAppointmentsCommand(dbContext);

                invoker.SetCommand(command);

                return await invoker.ExecuteCommand();
            }
            
            [HttpGet("{id:int}/Appointments")]
            public async Task<IActionResult> GetMedicalRecordAppointments([FromRoute] int id)
            {
                var command = new GetMedicalRecordAppointmentsCommand(dbContext, id);

                invoker.SetCommand(command);

                return await invoker.ExecuteCommand();
            }
            [HttpGet]
            [Route("{id:int}")]
            public async Task<IActionResult> GetMedicalRecordById([FromRoute] int id)
            {
                var command = new GetMedicalRecordByIdCommand(dbContext,id);
              
                invoker.SetCommand(command);

                return await invoker.ExecuteCommand();
        
            }
            [HttpPost]
            [Route("{id:int}/Appointments")]
            public async Task<IActionResult> AddMedicalAppointment([FromRoute] int id,[FromBody] Model.AddMedicalAppointmentModel medicalAppointment)
            {

                var command = new AddMedicalAppointmentCommand(dbContext, id, medicalAppointment);

                invoker.SetCommand(command);

                return await invoker.ExecuteCommand();

            }
            [HttpPost]
            public async Task<IActionResult> AddMedicalRecord(Model.AddMedicalRecordRequest medicalRecord)
            {
                var command = new AddMedicalRecordCommand(dbContext, medicalRecord);
           
                invoker.SetCommand(command);

                return await invoker.ExecuteCommand();
            }
            [HttpPut]
            [Route("{id:int}")]
            public async Task<IActionResult> UpdateMedicalRecord([FromRoute] int id, Model.UpdateMedicalRecordRequest updateMedicalRecordRequest)
            {
                var command = new UpdateMedicalRecordCommand(dbContext,id, updateMedicalRecordRequest);
                
                invoker.SetCommand(command);

                return await invoker.ExecuteCommand();
            }
            [HttpDelete]
            [Route("{id:int}")]
            public async Task<IActionResult> DeleteMedicalRecord([FromRoute] int id)
            {
                var command = new DeleteMedicalRecordCommand(dbContext, id);
                
                invoker.SetCommand(command);

                return await invoker.ExecuteCommand();
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
