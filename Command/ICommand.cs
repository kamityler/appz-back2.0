using Lab5LKPZ.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lab5LKPZ.Command
{
    public interface ICommand
    {
        Task<IActionResult> Execute();
    }
}
