using Lab5LKPZ.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Lab5LKPZ.Command.DiseaseCommand
{
    public class GetDiseaseByPatientIdCommand:Controller, ICommand
    {
        private readonly MedicalApiDbContext dbContext;
        private readonly int _id;

        public GetDiseaseByPatientIdCommand(MedicalApiDbContext dbContext, int id)
        {
            this.dbContext = dbContext;
            this._id = id;
        }
        public async Task<IActionResult> Execute()
        {

            var record = await dbContext.MedicalRecords.Include(m => m.Diseases).FirstOrDefaultAsync(m => m.PatientID == _id);

            if (record != null)
            {
                return Ok(record.Diseases);
            }

            return NotFound();
        }
    }
}
