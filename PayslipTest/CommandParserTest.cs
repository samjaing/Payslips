using Payslips;
using Payslips.Model.Enumerations;
using System;
using System.Linq;
using Xunit;

namespace PayslipTest
{
    public class CommandParserTest
    {
        [Theory]
        [InlineData("exit", CommandDescription.EXIT)]
        [InlineData("EXIT", CommandDescription.EXIT)]
        [InlineData("Exit", CommandDescription.EXIT)]
        [InlineData("eXit", CommandDescription.EXIT)]
        [InlineData("GenerateMonthlyPaySlip", CommandDescription.GENERATEMONTHLYPAYSLIP)]
        [InlineData("GENERATEMONTHLYPAYSLIP", CommandDescription.GENERATEMONTHLYPAYSLIP)]
        [InlineData("generatemonthlypayslip", CommandDescription.GENERATEMONTHLYPAYSLIP)]
        public void GetCommandType_ShouldPass(string inputCommand, CommandDescription expectedCommand)
        {
            var commandType = CommandParser.GetCommandType(inputCommand);
            Assert.Equal(expectedCommand, commandType);
        }

        [Theory]
        [InlineData("123")]
        [InlineData("")]
        public void GetCommandType_ShouldFail(string inputCommand)
        {
            Assert.Throws<ArgumentException>(()=> CommandParser.GetCommandType(inputCommand));
        }

        [Theory]
        [InlineData("123",1)]
        [InlineData("GenerateMonthlyPaySlip \"Test NAme\" 234", 3)]
        [InlineData("Exit   ", 1)]
        [InlineData("GenerateMonthlyPaySlip      \"Test   NAme\"    234", 3)]

        public void ParseCommand_ShouldPass(string inputCommand, int expectedCount)
        {
            var parsedCommand = CommandParser.ParseCommand(inputCommand);
            Assert.Equal(expectedCount, parsedCommand.Count());
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void ParseCommand_ShouldFail(string inputCommand)
        {
            Assert.Throws<ArgumentException>(() => CommandParser.ParseCommand(inputCommand));
        }
    }
}
