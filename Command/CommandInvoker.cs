using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lab5LKPZ.Command
{
    public class CommandInvoker
    {
        private ICommand command;

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public async Task<IActionResult> ExecuteCommand()
        {
            return await command.Execute();
        }
    }
}
