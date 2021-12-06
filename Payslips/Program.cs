using Payslips.Model;
using Payslips.Model.Commands;
using Payslips.Model.Enumerations;
using Payslips.Model.Interface;
using System;
using System.Linq;

namespace Payslips
{
    class Program
    {
        static void Main(string[] args)
        {
            ITaxCalculator taxCalculator = new TaxCalculator();

            PrintWelcomeMessage();
            bool ExitFlag = false;
            while (!ExitFlag)
            {
                Console.Write("Cmd>>");
                //Get input from user.
                string inputCommand = Console.ReadLine();

                if (string.IsNullOrEmpty(inputCommand) || string.IsNullOrWhiteSpace(inputCommand))
                    continue;

                try
                {
                    //Parse the user input and ge the command which needs to execute.
                    var parsedInput = CommandParser.ParseCommand(inputCommand);
                    var commandDescription = CommandParser.GetCommandType(parsedInput.First());
                    switch (commandDescription)
                    {
                        case CommandDescription.EXIT:
                            ExitFlag = true;
                            break;
                        case CommandDescription.GENERATEMONTHLYPAYSLIP:
                            var command = new GeneratePaySlipCommand(parsedInput);
                            //IMPROVEMENT : taxCalculator should not be directly passed to PaySlip constructor
                            //It should be added to dependency injection container.
                            PaySlip paySlip = new PaySlip(taxCalculator, command.NameArgument, command.IncomeArgument);
                            paySlip.GetMonthlyPayslip();
                            break;
                        default:
                            Console.WriteLine("Command not Supported. Please try again");
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void PrintWelcomeMessage()
        {
            Console.WriteLine("This program will genereate the salary slips for the employees. \n Supported Commands:");
            Console.WriteLine("1) GenerateMonthlyPayslip \"<EmpName>\" <AnnualSalary>");
            Console.WriteLine("2) Exit");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("-----------------------------");
        }
    }
}
