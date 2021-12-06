using Payslips.Model.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Payslips.Model.Commands
{
    /// <summary>
    /// ExitCommand will have all the functionality required to run 'Exit' console command .
    /// </summary>
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

        /// <summary>
        /// Validate if user input is sufficient and valid to execuet the command.
        /// </summary>
        /// <param name="inputCommand"></param>
        /// <returns></returns>
        public static bool ValidateInput(IList<string> inputCommand)
        {
            if (inputCommand == null)
            {
                throw new ArgumentException("Invalid Command: wrong format");
            }

            //Checking if Command has required number of arguments.
            if (!inputCommand.Any() || (inputCommand.Count() != 1))
            {
                var message = "Invalid Command: wrong format";
                throw new ArgumentException(message);
            }

            //Checking if input as correct command name.
            if (Name.ToString() != inputCommand.First())
            {
                var message = "Invalid Command: wrong format";
                throw new ArgumentException(message);
            }
            return true;
        }
    }
}
