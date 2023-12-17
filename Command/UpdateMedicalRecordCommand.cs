using Lab5LKPZ.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Lab5LKPZ.Model;

namespace Lab5LKPZ.Command
{
    public class UpdateMedicalRecordCommand : Controller, ICommand
    {
        private readonly MedicalApiDbContext dbContext;
        private readonly int _id;
        private readonly UpdateMedicalRecordRequest updateMedicalRecordRequest;

        public UpdateMedicalRecordCommand(MedicalApiDbContext dbContext, int id, Model.UpdateMedicalRecordRequest updateMedicalRecordRequest)
        {
            this.dbContext = dbContext;
            this._id = id;
            this.updateMedicalRecordRequest =  updateMedicalRecordRequest;
        }
        public async Task<IActionResult> Execute()
        {
            var record = await dbContext.MedicalRecords.FindAsync(this._id);
            if (record != null)
            {
                record = Mapping.MedicalRecordDataMapper.MapToEntity(updateMedicalRecordRequest, record);

                if (record.FirstName == "" || record.MiddleName == "" || record.LastName == "")
                {
                    return BadRequest(record);
                }
                await dbContext.SaveChangesAsync();
                return Ok(record);
            }

            return NotFound();
        }
    }
}
