using Payslips.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Payslips.Model
{
    /// <summary>
    /// Tax calculator has all the information, like tax slabs, required to calculate the total tax on an annual income.
    /// </summary>
    public class TaxCalculator : ITaxCalculator
    {
        public IList<TaxSlab> Slabs { get; set; }
        public TaxCalculator()
        {
            Slabs = new List<TaxSlab>();
            //Setting the default values of the slab.
            SetSlabs(Slabs);
        }

        public TaxCalculator(IList<TaxSlab> slabs)
        {
            if (!slabs.Any())
                throw new Exception("Slabs not defined.");
            Slabs = slabs;
        }
        /// <summary>
        /// Based on the Tax Slabs, this function calculates annual tax on the annual income. 
        /// </summary>
        /// <param name="annualIncome"></param>
        /// <returns></returns>
        public double CalculateTax(double annualIncome)
        {
            if (!Slabs.Any())
                throw new Exception("Slabs are not defined to calcualte tax.");

            return Slabs.Select(slab => slab.GetTaxForSlab(annualIncome)).Sum();
        }

        /// <summary>
        /// Assigning default values to the slabs of the calculator.
        /// </summary>
        /// <param name="slabs"></param>
        private void SetSlabs(IList<TaxSlab> slabs)
        {
            //IMPROVEMENT : Ideally these values should be read from DB or a file at the start of the system.
            //Till the time we get furhter scope, it is hardcoded. 
            slabs.Add(new TaxSlab(0, 20000, 0));
            slabs.Add(new TaxSlab(20001, 40000, 0.1));
            slabs.Add(new TaxSlab(40001, 80000, 0.2));
            slabs.Add(new TaxSlab(80001, 180000, 0.3));
            slabs.Add(new TaxSlab(180001, double.MaxValue, 0.4));
        }
    }
}
