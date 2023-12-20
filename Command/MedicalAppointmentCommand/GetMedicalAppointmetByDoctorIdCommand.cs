using Lab5LKPZ.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5LKPZ.Command.MedicalAppointmentCommand
{
    public class GetMedicalAppointmetByDoctorIdCommand : Controller, ICommand
    {
        private readonly MedicalApiDbContext dbContext;
        private readonly int _id;

        public GetMedicalAppointmetByDoctorIdCommand(MedicalApiDbContext dbContext, int id)
        {
            this.dbContext = dbContext;
            this._id = id;
        }
        public async Task<IActionResult> Execute()
        {

            var record = await dbContext.MedicalAppointment.Where(m => m.DoctorID == _id).Include(m => m.MedicalRecord)
                .ToArrayAsync();
            if (record != null)
            {
                return Ok(record);
            }

            return NotFound();
        }
    }
}
