using Payslips.Model.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Payslips.Model.Commands
{
    public class ExitCommand : ICommand
    {
        const CommandDescription Name = CommandDescription.EXIT;

        public ExitCommand(IList<string> parsedInput)
        {
            if (!ValidateInput(parsedInput))
            {
                throw new ArgumentException("Invalid Command: wrong format");
            }
        }
        public static bool ValidateInput(IList<string> inputCommand)
        {
            if (inputCommand == null)
            {
                throw new ArgumentException("Invalid Command: wrong format");
            }
            if (!inputCommand.Any() || (inputCommand.Count() != 1))
            {
                var message = "Invalid Command: wrong format";
                throw new ArgumentException(message);
            }

            if (Name.ToString() != inputCommand.First())
            {
                var message = "Invalid Command: wrong format";
                throw new ArgumentException(message);
            }
            return true;
        }
    }
}
