using Lab5LKPZ.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace Lab5LKPZ.Command
{
    public class GetMedicalRecordAppointmentsCommand: Controller, ICommand
    {
        private readonly MedicalApiDbContext dbContext;
        private readonly int _id;

        public GetMedicalRecordAppointmentsCommand(MedicalApiDbContext dbContext, int id)
        {
            this.dbContext = dbContext;
            this._id = id;
        }
        public async Task<IActionResult> Execute()
        {
            
            var record = await dbContext.MedicalRecords.Include(m => m.Appointments).FirstOrDefaultAsync(m => m.PatientID == _id);

            if (record != null)
            {
                return Ok(record.Appointments);
            }

            return NotFound();
            }
    }
}
