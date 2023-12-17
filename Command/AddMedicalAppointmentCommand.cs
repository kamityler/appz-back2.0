using Lab5LKPZ.Data;
using Lab5LKPZ.Interfaces;
using Lab5LKPZ.Mapping;
using Lab5LKPZ.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab5LKPZ.Command
{
    public class AddMedicalAppointmentCommand: Controller, ICommand
    {
        private readonly MedicalApiDbContext dbContext;
        private readonly int id;
        private readonly AddMedicalAppointmentModel medicalAppointment;

        public AddMedicalAppointmentCommand(MedicalApiDbContext dbContext, int id, AddMedicalAppointmentModel medicalAppointment)
        {
            this.dbContext = dbContext;
            this.id = id;
            this.medicalAppointment = medicalAppointment;
        }
        public async Task<IActionResult> Execute()
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

    }
}
