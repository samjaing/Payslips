using Payslips.Model.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Payslips.Model.Commands
{
    /// <summary>
    /// GeneratePaySlipCommand will have all the functionality required to run 'GeneratePaySlipCommand' console command .
    /// </summary>
    public class GeneratePaySlipCommand : ICommand
    {
        const CommandDescription Name = CommandDescription.GENERATEMONTHLYPAYSLIP;
        public string NameArgument { get; set; }
        public double IncomeArgument { get; set; }
        private const string CommandFormat = "GenerateMonthlyPayslip \"<EmpName>\" <AnnualSalary> \n Employeename must be in quotes \"\""  ;
        
        public GeneratePaySlipCommand(IList<string> parsedInput)
        {
            if(!ValidateInput(parsedInput))
            {
                throw new ArgumentException($"Invalid Command: wrong format.\n Correct usage {CommandFormat}");
            }

            NameArgument = parsedInput.ElementAt(1);
            IncomeArgument = GetIncomeArgument(parsedInput.ElementAt(2));
        }

        /// <summary>
        /// Validate if user input is sufficient and valid to execuet the command.
        /// </summary>
        /// <param name="inputCommand"></param>
        /// <returns></returns>
        public static bool ValidateInput(IEnumerable<string> inputCommand)
        {
            if (inputCommand == null)
            {
                throw new ArgumentException($"Invalid Command: wrong format.\n Correct usage {CommandFormat}");
            }
            //Checking if Command has required number of arguments.
            if (!inputCommand.Any() || (inputCommand.Count() != 3))
            {
                throw new ArgumentException($"Invalid Command: wrong number of arguments.\n Correct usage {CommandFormat}");
            }
            //Checking if input as correct command name.
            if (Name.ToString() != inputCommand.First().ToUpper())
            {
                throw new ArgumentException($"Invalid Command: wrong format.\n Correct usage {CommandFormat}");
            }

            //Check if emplyee name is provided or not.
            if (string.IsNullOrEmpty(inputCommand.ElementAt(1)))
            {
                throw new ArgumentException($"Invalid Command: Please provide valid name.\n Correct usage {CommandFormat}");
            }

            // Checking if income provided is a valid number.
            if(GetIncomeArgument(inputCommand.ElementAt(2)) < 0 )
            {
                throw new ArgumentException("Invalid Command: Please provide a valid income.\n Correct usage {CommandFormat}");
            }
            return true;
        }

        /// <summary>
        /// Checking of the input string is a valid number of double type.
        /// </summary>
        /// <param name="incomeString"></param>
        /// <returns></returns>
        private static double GetIncomeArgument(string incomeString)
        {
            double validIncome;
            if (!double.TryParse(incomeString, out validIncome))
            {
                throw new ArgumentException($"Invalid value for annual income: {incomeString} ");
            }

            return validIncome;
        }
    }
}
