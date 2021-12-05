using Payslips.Model;
using Payslips.Model.Interface;
using Xunit;

namespace PayslipTest
{
    public class PaySlipTest
    {
        private ITaxCalculator CreateTaxCalculator() => new TaxCalculator();

        [Theory]
        [InlineData("Test Employee 1", 12000,1000)]
        [InlineData("Test Employee 2", 0, 0)]
        public void CheckGrossMonthlyIncome_ShouldPass(string employeeName, double annualIncome, double expectedGrossMonthlyIncome)
        {
            var paySlip = new PaySlip(CreateTaxCalculator(),employeeName,annualIncome);
            Assert.Equal(expectedGrossMonthlyIncome, paySlip.GrossMonthlyIncome);
        }

        [Theory]
        [InlineData("Test Employee 1", 12000, 0)]
        [InlineData("Test Employee 2", 0, 0)]
        public void CheckMonthlyIncomeTax_ShouldPass(string employeeName, double annualIncome, double expectedMonthlyIncomeTax)
        {
            var paySlip = new PaySlip(CreateTaxCalculator(), employeeName, annualIncome);
            Assert.Equal(expectedMonthlyIncomeTax, paySlip.MonthlyIncomeTax);
        }

        [Theory]
        [InlineData("Test Employee 1", 12000, 1000)]
        [InlineData("Test Employee 2", 0, 0)]
        public void CheckNetMonthlyIncome_ShouldPass(string employeeName, double annualIncome, double expectedNetMonthlyIncome)
        {
            var paySlip = new PaySlip(CreateTaxCalculator(), employeeName, annualIncome);
            Assert.Equal(expectedNetMonthlyIncome, paySlip.NetMonthlyIncome);
        }
    }
}
