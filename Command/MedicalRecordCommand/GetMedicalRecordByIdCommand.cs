using Lab5LKPZ.Data;
using Lab5LKPZ.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Lab5LKPZ.Command
{
    public class GetMedicalRecordByIdCommand: Controller, ICommand
    {
        private readonly MedicalApiDbContext dbContext;
        private readonly int _id;

        public GetMedicalRecordByIdCommand(MedicalApiDbContext dbContext,int id)
        {
            this.dbContext = dbContext;
            this._id = id;
        }
        public async Task<IActionResult> Execute()
        {
            try
            {
                var medicalRecord = await dbContext.MedicalRecords
                    .Include(m => m.Diseases) // Якщо ви хочете включити призначення
                    .FirstOrDefaultAsync(m => m.PatientID == this._id);



                return Ok(medicalRecord); // Повертаємо успішний результат знайденого медичного запису
            }
            catch (Exception ex)
            {
                // Обробка можливих помилок
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
