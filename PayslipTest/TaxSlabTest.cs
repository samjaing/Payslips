using Payslips.Model;
using System;
using Xunit;

namespace PayslipTest
{
    /// <summary>
    /// TaxSlabTest will test the functionality of class TaxSlab.
    /// </summary>
    public class TaxSlabTest
    {
        [Fact]
        public void SlabStart_GreaterThan_SlabEnd_ShouldFail()
        {
            Assert.Throws<Exception>(()=>new TaxSlab(2000,1000,4));
        }

        /// <summary>
        /// Calculate Tax for a slab.
        /// </summary>
        /// <param name="slabStart">Starting value of the slab range.</param>
        /// <param name="slabEnd">Ending value of the slab range.</param>
        /// <param name="taxPerUnit">Tax rate per unit.</param>
        /// <param name="annualIncome">Annual income on which tax will be calculated.</param>
        /// <param name="expectedTaxForSlab">Expected tax on the provided annual income.</param>
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
