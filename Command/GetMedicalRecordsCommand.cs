using Lab5LKPZ.Data;
using Lab5LKPZ.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Lab5LKPZ.Mapping;

namespace Lab5LKPZ.Command
{
    public class GetMedicalRecordsCommand : Controller, ICommand 
    {
        private readonly MedicalApiDbContext dbContext;

        public GetMedicalRecordsCommand(MedicalApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IActionResult> Execute()
        {
            return Ok(await MedicalRecordDataMapper.MapToModel(dbContext).Include(m => m.Appointments).ToListAsync());
        }
    }
}
