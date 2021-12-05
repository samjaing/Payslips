using Microsoft.Extensions.Configuration;
using Payslips.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Payslips.Model
{
    public class TaxCalculator : ITaxCalculator
    {
        [Required]
        IList<TaxSlab> Slabs { get; set; }
        //public TaxCalculator(IConfigurationBuilder builder)
        public TaxCalculator()
        {
            Slabs = new List<TaxSlab>();
            SetSlabs(Slabs);
        }

        public double CalculateTax(double annualIncome)
        {
            if (!Slabs.Any())
                throw new Exception("Slabs are not defined to calcualte tax.");

            return Slabs.Select(slab => slab.GetTaxForSlab(annualIncome)).Sum();
        }

        private void SetSlabs(IList<TaxSlab> slabs)
        {
            slabs.Add(new TaxSlab(0, 20000, 0));
            slabs.Add(new TaxSlab(20001, 40000, 0.1));
            slabs.Add(new TaxSlab(40001, 80000, 0.2));
            slabs.Add(new TaxSlab(80001, 180000, 0.3));
            slabs.Add(new TaxSlab(180001, double.MaxValue, 0.4));
        }
    }
}
