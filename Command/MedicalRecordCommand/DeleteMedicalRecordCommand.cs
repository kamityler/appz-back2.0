using Lab5LKPZ.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace Lab5LKPZ.Command
{
    public class DeleteMedicalRecordCommand : Controller, ICommand
    {
        private readonly MedicalApiDbContext dbContext;
        private readonly int _id;

        public DeleteMedicalRecordCommand(MedicalApiDbContext dbContext, int id)
        {
            this.dbContext = dbContext;
            _id = id;
        }
        public async Task<IActionResult> Execute()
        {
            var record = await dbContext.MedicalRecords.FindAsync(_id);
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
