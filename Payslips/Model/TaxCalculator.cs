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
        public double CalculateTax(double annualIncome)
        {
            if (!Slabs.Any())
                throw new Exception("Slabs are not defined to calcualte tax.");

            return Slabs.Select(slab => slab.GetTaxForSlab(annualIncome)).Sum();
        }
    }
}
