using Payslips.Model.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Payslips.Model.Commands
{
    public class GeneratePaySlipCommand : ICommand
    {
        const CommandDescription Name = CommandDescription.GENERATEMONTHLYPAYSLIP;
        
        public string NameArgument { get; set; }
        public double IncomeArgument { get; set; }

        private const string CommandFormat = "GenerateMonthlyPayslip \"<EmpName>\" <AnnualSalary>";
        
        public GeneratePaySlipCommand(IList<string> parsedInput)
        {
            if(!ValidateInput(parsedInput))
            {
                throw new ArgumentException($"Invalid Command: wrong format.\n Correct usage {CommandFormat}");
            }

            NameArgument = parsedInput.ElementAt(1);
            IncomeArgument = GetIncomeArgument(parsedInput.ElementAt(2));
        }

        public static bool ValidateInput(IEnumerable<string> inputCommand)
        {
            if (inputCommand == null)
            {
                throw new ArgumentException($"Invalid Command: wrong format.\n Correct usage {CommandFormat}");
            }
            if (!inputCommand.Any() || (inputCommand.Count() != 3))
            {
                throw new ArgumentException($"Invalid Command: wrong number of arguments.\n Correct usage {CommandFormat}");
            }

            if (Name.ToString() != inputCommand.First().ToUpper())
            {
                throw new ArgumentException($"Invalid Command: wrong format.\n Correct usage {CommandFormat}");
            }


            if (string.IsNullOrEmpty(inputCommand.ElementAt(1)))
            {
                throw new ArgumentException($"Invalid Command: Please provide valid name.\n Correct usage {CommandFormat}");
            }

            if(GetIncomeArgument(inputCommand.ElementAt(2)) < 0 )
            {
                throw new ArgumentException("Invalid Command: Please provide a valid income.\n Correct usage {CommandFormat}");
            }
            return true;
        }

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
