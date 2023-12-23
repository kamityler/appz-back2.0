using Lab5LKPZ.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5LKPZ.Command.VaccinationCommand
{
    public class GetVactinationByPatinetIdCommand: Controller, ICommand
    {
        private readonly MedicalApiDbContext dbContext;
        private readonly int id;
        public GetVactinationByPatinetIdCommand(MedicalApiDbContext dbContext, int id)
        {
            this.dbContext = dbContext;
            this.id = id;
        }
        public async Task<IActionResult> Execute()
        {
            // Отримати вакцинації для конкретного пацієнта
            var vaccinations = await dbContext.Vaccination
                .Where(v => v.PatientId == id)
                .ToListAsync();

            if (vaccinations == null || vaccinations.Count == 0)
            {
                return NotFound($"No vaccinations found for patient with ID {id}");
            }

            return Ok(vaccinations);
        }
    }
}
