using System;

namespace Payslips.Model
{
    /// <summary>
    /// TaxSlab has the information about the tax rate and the rang of amount 
    /// on which tax will be calculated using tax rate.    /// </summary>
    public class TaxSlab
    {
        public double SlabStart { get; set; }
        public double SlabEnd { get; set; }
        public double TaxPerUnit { get; set; }

        private TaxSlab(){}

        public TaxSlab(double slabStart, double slabEnd, double taxPerUnit)
        {
            //Start value of slab must be less than End value.
            if (!(slabStart < slabEnd))
            {
                throw new Exception("Slab starting value must be less than the ending value of the slab.");
            }

            SlabStart = slabStart;
            SlabEnd = slabEnd;
            TaxPerUnit = taxPerUnit;
        }
        
        /// <summary>
        /// Calute the tax based on the income range and rate for a SLAB.
        /// </summary>
        /// <param name="annualSalary"></param>
        /// <returns>Tax for the slab.</returns>
        public double GetTaxForSlab(double annualSalary)
        {
            double taxableIncome;
            var adjustmentFactor = SlabStart % 2 == 0 ? 0 : 1;
            
            // 0 Tax if annual salary does not lie in this slab.
            if (annualSalary < SlabStart)
            {
                taxableIncome = 0;
            }
            else if (annualSalary >= SlabEnd)
            {
                taxableIncome = (SlabEnd - (SlabStart - adjustmentFactor));
            }
            else
            {
                taxableIncome = (annualSalary - (SlabStart - adjustmentFactor));
            }

            return taxableIncome * TaxPerUnit;
        }
    }
}
