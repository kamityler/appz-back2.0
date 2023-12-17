using Lab5LKPZ.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Lab5LKPZ.Model;
using System.Text.RegularExpressions;

namespace Lab5LKPZ.Command
{
    public class AddMedicalRecordCommand: Controller, ICommand
    {
        private readonly MedicalApiDbContext dbContext;
        private readonly AddMedicalRecordRequest medicalRecord;

        public AddMedicalRecordCommand(MedicalApiDbContext dbContext, AddMedicalRecordRequest medicalRecord)
        {
            this.dbContext = dbContext;
            this.medicalRecord = medicalRecord;
        }
        public async Task<IActionResult> Execute()
        {
            var record = Mapping.MedicalRecordDataMapper.MapToEntity(medicalRecord);

            if (record.FirstName == null || record.LastName == null || record.MiddleName == null || Regex.IsMatch(record.FirstName, @"\d"))
            {
                return BadRequest();
            }
            await dbContext.MedicalRecords.AddAsync(record);

            await dbContext.SaveChangesAsync();
            return Ok(record);
        }
    }
}
