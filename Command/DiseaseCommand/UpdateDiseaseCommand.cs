using Lab5LKPZ.Data;
using Lab5LKPZ.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lab5LKPZ.Command.DiseaseCommand
{
    public class UpdateDiseaseCommand:Controller,ICommand
    {
        private readonly MedicalApiDbContext dbContext;
        private readonly int _id;
        private readonly Disease updateDisease;

        public UpdateDiseaseCommand(MedicalApiDbContext dbContext, int id, Model.Disease updateDisease)
        {
            this.dbContext = dbContext;
            this._id = id;
            this.updateDisease = updateDisease;
        }
        public async Task<IActionResult> Execute()
        {
            var record = await dbContext.Disease.FindAsync(this._id);
            if (record != null)
            {
                record.Result = updateDisease.Result;
                record.DischargeDate = updateDisease.DischargeDate;
                record.DiseaseStatus = updateDisease.DiseaseStatus;



                await dbContext.SaveChangesAsync();
                return Ok(record);
            }

            return NotFound();
        }
    }
}
