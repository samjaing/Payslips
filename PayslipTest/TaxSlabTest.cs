using Payslips.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PayslipTest
{
    public class TaxSlabTest
    {
        [Fact]
        public void SlabStart_GreaterThan_SlabEnd_ShouldFail()
        {
            Assert.Throws<Exception>(()=>new TaxSlab(2000,1000,4));
        }

        [Theory]
        [InlineData(0, 2000,0.1,0,0)]
        [InlineData(0, 2000, 0.1, 3000, 200)]
        [InlineData(400, 500, 0.2, 450, 10)]
        public void CalculateTaxForSlab_ShouldPass(double slabStart,double slabEnd,double taxPerUnit, double annualIncome, double expectedTaxForSlab)
        {
            var taxSlab = new TaxSlab(slabStart, slabEnd, taxPerUnit);
            var calculatedTax = taxSlab.GetTaxForSlab(annualIncome);
            Assert.Equal(expectedTaxForSlab, calculatedTax);
        }
    }
}
