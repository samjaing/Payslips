using System;
using System.ComponentModel.DataAnnotations;

namespace Payslips.Model
{
    public class TaxSlab
    {
        [Required]
        public int SlabStart { get; set; }
        [Required]
        public int SlabEnd { get; set; }
        [Required]
        public int TaxPerUnit { get; set; }

        private TaxSlab(){}

        public TaxSlab(int slabStart, int slabEnd, int taxPerUnit)
        {
            //Start value of slab must be less than End value.
            if (!(SlabStart < SlabEnd))
            {
                throw new Exception("Slab starting value must be less than the ending value of the slab.");
            }

            SlabStart = slabStart;
            SlabEnd = slabEnd;
            TaxPerUnit = taxPerUnit;
        }

        public double GetTaxForSlab(double annualSalary)
        {
            double taxableIncome = 0;
            
            // 0 Tax if annual salary does not lie in this slab.
            if (annualSalary < SlabStart)
            {
                taxableIncome = 0;
            }
            else if (annualSalary >= SlabEnd)
            {
                taxableIncome = (SlabEnd - (SlabStart - 1));
            }
            else
            {
                taxableIncome = (annualSalary - (SlabStart - 1));
            }

            return taxableIncome * TaxPerUnit;
        }
    }
}
