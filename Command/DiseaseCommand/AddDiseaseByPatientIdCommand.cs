using Lab5LKPZ.Data;
using Lab5LKPZ.Mapping;
using Lab5LKPZ.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Lab5LKPZ.Command.DiseaseCommand
{
    public class AddDiseaseByPatientIdCommand:Controller, ICommand
    {
        private readonly MedicalApiDbContext dbContext;
        private readonly int id;
        private readonly Disease Diseases;

        public AddDiseaseByPatientIdCommand(MedicalApiDbContext dbContext, int id, Disease Diseases)
        {
            this.dbContext = dbContext;
            this.id = id;
            this.Diseases = Diseases;
        }
        public async Task<IActionResult> Execute()
        {
            var record = Diseases;
            record.PatientID = id;
            var medicalRecord = await dbContext.MedicalRecords
                    .Include(m => m.Appointments) // Якщо ви хочете включити призначення
                    .FirstOrDefaultAsync(m => m.PatientID == id);

            if (medicalRecord == null)
            {
                return BadRequest(); // Повертаємо 404, якщо медичний запис не знайдено
            }
            await dbContext.Disease.AddAsync(record);

            await dbContext.SaveChangesAsync();
            return Ok(record);
        }
    }
}
