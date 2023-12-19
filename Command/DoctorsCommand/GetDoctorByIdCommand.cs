using Lab5LKPZ.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace Lab5LKPZ.Command.DoctorsCommand
{
    public class GetDoctorByIdCommand:Controller, ICommand
    {

        private readonly MedicalApiDbContext dbContext;
        private readonly int id;
        public GetDoctorByIdCommand(MedicalApiDbContext dbContext, int id)
        {
            this.dbContext = dbContext;
            this.id = id;
        }
        public async Task<IActionResult> Execute()
        {
            //var patientIds = doctor.Patients.Select(dp => dp.PatientID).ToList();

            //// Завантажуємо пацієнтів з бази даних
            //var patients = await dbContext.MedicalRecords
            //    .Where(p => patientIds.Contains(p.PatientID)).Include(m => m.Appointments)
            //    .ToListAsync();
            //var patients = await dbContext.Doctors.Select(p => p.Patients).ToListAsync();
            //var doctorsPatients = patients.Select(db => db.Select(p=>p.Patient)).ToList();
          
            var doctors = await dbContext.Doctors.Include(p=>p.Patients).FirstOrDefaultAsync(m => m.DoctorID == this.id);
            //var patients = doctor.Patients.Select(dp => dp.Patient).ToList();


            return Ok(doctors);
        }
    }
}
