using Payslips.Model;
using Payslips.Model.Interface;
using System.Collections.Generic;
using Xunit;

namespace PayslipTest
{
    /// <summary>
    /// PaySlipTest will test the functionality of class PaySlip.
    /// </summary>
    public class PaySlipTest
    {
        private ITaxCalculator CreateTaxCalculator() 
        {
            var slabs = new List<TaxSlab>();    

            slabs.Add(new TaxSlab(0, 20000, 0));
            slabs.Add(new TaxSlab(20001, 40000, 0.1));
            slabs.Add(new TaxSlab(40001, 80000, 0.2));
            slabs.Add(new TaxSlab(80001, 180000, 0.3));
            slabs.Add(new TaxSlab(180001, double.MaxValue, 0.4));

            return new TaxCalculator(slabs);
        } 

        /// <summary>
        /// Successfully calculates the monthly gross income.
        /// </summary>
        /// <param name="employeeName">Name of the employee</param>
        /// <param name="annualIncome">Annual income of the employee</param>
        /// <param name="expectedGrossMonthlyIncome">Expected calculated monthly gross income</param>
        [Theory]
        [InlineData("Test Employee 1", 12000,1000)]
        [InlineData("Test Employee 2", 0, 0)]
        public void CheckGrossMonthlyIncome_ShouldPass(string employeeName, double annualIncome, double expectedGrossMonthlyIncome)
        {
            var paySlip = new PaySlip(CreateTaxCalculator(),employeeName,annualIncome);
            Assert.Equal(expectedGrossMonthlyIncome, paySlip.GrossMonthlyIncome);
        }

        /// <summary>
        /// Successfully calculates the monthly income tax.
        /// </summary>
        /// <param name="employeeName">Name of the employee</param>
        /// <param name="annualIncome">Annual income of the employee </param>
        /// <param name="expectedMonthlyIncomeTax">Expected calculated monthly income income</param>
        [Theory]
        [InlineData("Test Employee 1", 12000, 0)]
        [InlineData("Test Employee 2", 0, 0)]
        public void CheckMonthlyIncomeTax_ShouldPass(string employeeName, double annualIncome, double expectedMonthlyIncomeTax)
        {
            var paySlip = new PaySlip(CreateTaxCalculator(), employeeName, annualIncome);
            Assert.Equal(expectedMonthlyIncomeTax, paySlip.MonthlyIncomeTax);
        }

        /// <summary>
        /// Successfully calculates the net monthly income.
        /// </summary>
        /// <param name="employeeName">Name of the employee</param>
        /// <param name="annualIncome">Annual income of the employee</param>
        /// <param name="expectedNetMonthlyIncome">Expected calculated net monthly income</param>
        [Theory]
        [InlineData("Test Employee 1", 12000, 1000)]
        [InlineData("Test Employee 2", 0, 0)]
        public void CheckNetMonthlyIncome_ShouldPass(string employeeName, double annualIncome, double expectedNetMonthlyIncome)
        {
            var paySlip = new PaySlip(CreateTaxCalculator(), employeeName, annualIncome);
            Assert.Equal(expectedNetMonthlyIncome, paySlip.NetMonthlyIncome);
        }

        /// <summary>
        /// Successfully check the employee name in the payslip.
        /// </summary>
        /// <param name="employeeName">Name of the employee</param>
        /// <param name="annualIncome">Annual income of the employee</param>
        [Theory]
        [InlineData("Test Employee 1", 12000)]
        [InlineData("Test Employee 2", 0)]
        public void CheckEmployeeName_ShouldPass(string employeeName, double annualIncome)
        {
            var paySlip = new PaySlip(CreateTaxCalculator(), employeeName, annualIncome);
            Assert.Equal(employeeName, paySlip.Name);
        }
    }
}
