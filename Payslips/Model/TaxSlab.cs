using System;

namespace Payslips.Model
{
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

        public double GetTaxForSlab(double annualSalary)
        {
            double taxableIncome;
            var adjustRange = SlabStart % 2 == 0 ? 0 : 1;
            
            // 0 Tax if annual salary does not lie in this slab.
            if (annualSalary < SlabStart)
            {
                taxableIncome = 0;
            }
            else if (annualSalary >= SlabEnd)
            {
                taxableIncome = (SlabEnd - (SlabStart - adjustRange));
            }
            else
            {
                taxableIncome = (annualSalary - (SlabStart - adjustRange));
            }

            return taxableIncome * TaxPerUnit;
        }
    }
}
