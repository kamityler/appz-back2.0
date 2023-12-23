using Lab5LKPZ.Data;
using Lab5LKPZ.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Lab5LKPZ.Command.VaccinationCommand
{
    public class AddVactinationByPatinetIdCommand:Controller, ICommand
    {
        private readonly MedicalApiDbContext dbContext;
        private readonly int id;
        private readonly AddVactinationModel vactination;

        public AddVactinationByPatinetIdCommand(MedicalApiDbContext dbContext, int id, AddVactinationModel vactination)
        {
            this.dbContext = dbContext;
            this.id = id;
            this.vactination = vactination;
        }
        public async Task<IActionResult> Execute()
        {
            var patient = await dbContext.MedicalRecords.FindAsync(id);
            if (patient == null)
            {
                return NotFound($"Patient with ID {id} not found");
            }

            VactinationModel newVaccination = new VactinationModel
            {
                PatientId = this.id,
                Description = vactination.Description,
                DoctorName = vactination.DoctorName,
                VaccinationDate = vactination.VaccinationDate,
                VaccineName = vactination.VaccineName,
            };


            dbContext.Vaccination.Add(newVaccination);
            await dbContext.SaveChangesAsync();

           
            return Ok(newVaccination);
        }
    }
}

