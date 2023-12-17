using Lab5LKPZ.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Lab5LKPZ.Command
{
    public class GetMedicalAppointmentsCommand: Controller, ICommand
    {
    
        private readonly MedicalApiDbContext dbContext;

        public GetMedicalAppointmentsCommand(MedicalApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IActionResult> Execute()
        {
            var appointments = await dbContext.MedicalAppointment.ToListAsync();
            return Ok(appointments);
        }
    }
}
