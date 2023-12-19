using Lab5LKPZ.Data;
using Lab5LKPZ.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Lab5LKPZ.Command
{
    public class GetPatientsByDoctorCommand:Controller, ICommand
    {
        private readonly MedicalApiDbContext dbContext;
        private readonly int id;
        public GetPatientsByDoctorCommand(MedicalApiDbContext dbContext,int id)
        {
            this.dbContext = dbContext;
            this.id = id;
        }
        public async Task<IActionResult> Execute()
        {
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
                .Where(p => patientIds.Contains(p.PatientID)).Include(m => m.Appointments)
                .ToListAsync();
            return Ok(patients);
        }
        
}
}
