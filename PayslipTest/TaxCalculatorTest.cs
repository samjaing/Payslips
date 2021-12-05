using Payslips.Model;
using System;
using System.Collections.Generic;
using Xunit;

namespace PayslipTest
{
    public class TaxCalculatorTest
    {
        [Theory]
        [InlineData(0,0)]
        [InlineData(20000, 0)]
        [InlineData(20001, 0.1)]
        [InlineData(40000, 2000)]
        [InlineData(40001, 2000.2)]
        [InlineData(80000, 10000)]
        [InlineData(80001, 10000.3)]
        [InlineData(180000, 40000)]
        [InlineData(180001, 40000.4)]
        [InlineData(double.MaxValue, 7.190772539449263E+307)]
        public void CalculateTaxShouldPass(double annualIncome, double expectedAnnualTax)
        {
            var taxCalculator = new TaxCalculator();
            var calculatedTax = taxCalculator.CalculateTax(annualIncome);
            Assert.Equal(expectedAnnualTax, calculatedTax);
        }

        [Fact]
        public void TaxCalculatro_NoSlabs_ShouldFail()
        {
            Assert.Throws<Exception>(()=> new TaxCalculator(new List<TaxSlab>()));
        }
    }
}
