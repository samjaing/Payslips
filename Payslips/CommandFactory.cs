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
            command = command.ToUpper();
            //Enum.TryParse successfull parese any integer string without confirming if the integer string is defined for the ENUM or not.
            //So this check ensures if the passed string is defined in the ENUM.

            if (!Enum.IsDefined(typeof(CommandDescription), command.ToUpper()))
            {
                throw new ArgumentException("Command not found.");
            }

            if (!Enum.TryParse(command, out cmd))
                throw new ArgumentException("Command not found.");

            return cmd;
        }
    }
}
