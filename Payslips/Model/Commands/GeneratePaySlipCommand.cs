using Payslips.Model.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payslips.Model.Commands
{
    public class GeneratePaySlipCommand : BaseCommand
    {
        const CommandDescription Name = CommandDescription.GENERATEMONTHLYPAYSLIP;
        
        public string NameArgument { get; set; }
        public double IncomeArgument { get; set; }
        
        public GeneratePaySlipCommand(IList<string> parsedInput)
        {
            if(!ValidateInput(parsedInput))
            {
                throw new ArgumentException("Invalid Command: wrong format");
            }

            NameArgument = parsedInput.ElementAt(1);
            IncomeArgument = GetIncomeArgument(parsedInput.ElementAt(2));
        }

        public static bool ValidateInput(IEnumerable<string> inputCommand)
        {
            if (inputCommand == null)
            {
                throw new ArgumentException("Invalid Command: wrong format");
            }
            if (!inputCommand.Any() || (inputCommand.Count() != 3))
            {
                var message = "Invalid Command: wrong format";
                throw new ArgumentException(message);
            }

            if (Name.ToString() != inputCommand.First())
            {
                var message = "Invalid Command: wrong format";
                throw new ArgumentException(message);
            }


            if (string.IsNullOrEmpty(inputCommand.ElementAt(1)))
            {
                var message = "Please provide valid name.";
                throw new ArgumentException(message);
            }

            if(GetIncomeArgument(inputCommand.ElementAt(2)) < 0 )
            {
                throw new ArgumentException("Invalid Command: Please provide a valid income.");
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
