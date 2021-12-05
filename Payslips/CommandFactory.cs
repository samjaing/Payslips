using Payslips.Model.Commands;
using Payslips.Model.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Payslips
{
    public class CommandFactory
    {
        public ICommand GetCommand(string command)
        {
            var parsed = ParseCommand(command);

            var commandType = GetCommandType(parsed.First());

            switch (commandType)
            {
                case CommandDescription.GENERATEMONTHLYPAYSLIP:
                    return new GeneratePaySlipCommand(parsed);

                case CommandDescription.EXIT:
                    return new ExitCommand(parsed);
                default:
                    throw new ArgumentException("Command not supported.");

            }
        }

        public static bool ValidateInput(CommandDescription commandType, IList<string> input)
        {
            switch (commandType)
            {
                case CommandDescription.GENERATEMONTHLYPAYSLIP:
                    return GeneratePaySlipCommand.ValidateInput(input);

                case CommandDescription.EXIT:
                    return ExitCommand.ValidateInput(input);
                default:
                    throw new ArgumentException("Command not supported.");
            }
        }

        public static CommandDescription GetCommandDescription(string command)
        {
            var parsed = ParseCommand(command);

            return GetCommandType(parsed.First());
        }

        public static IList<string> ParseCommand(string userInput)
        {
            if (String.IsNullOrEmpty(userInput))
                throw new ArgumentException("Invalid Command.");

            var cmd = Regex.Replace(userInput.Trim(), @"\s+", @" ");


            List<string> result = new List<string>();
            var brkCmd = cmd.Split(' ').ToList();
            if (!brkCmd.Any() || String.IsNullOrEmpty(brkCmd.First()))
                throw new ArgumentException("Invalid Command.");

            result.Add(brkCmd.First());

            if (brkCmd.Count > 1)
            {
                var splitted = cmd.Split(' ', 2)[1];
                var split = splitted.Split('"').ToList();
                var add = split.Where(a => !string.IsNullOrWhiteSpace(a)).Select(a => Regex.Replace(a.Trim(), @"\s+", @" "));
                result.AddRange(add);
            }

            return result;
        }

        public static CommandDescription GetCommandType(string command)
        {
            CommandDescription cmd;

            //Enum.TryParse successfull parese any integer string without confirming if the integer string is defined for the ENUM or not.
            //So this check ensures if the passed string is defined in the ENUM.

            if (!Enum.IsDefined(typeof(CommandDescription), command))
            {
                throw new ArgumentException("Command not found.");
            }

            if (!Enum.TryParse(command, out cmd))
                throw new ArgumentException("Command not found.");

            return cmd;
        }
    }
}
