using System;
using System.Collections.Generic;
using System.Text;

namespace Payslips.Model.Interface
{
    /// <summary>
    /// This interface should be inherited by every class which is responsible for calculation of Tax.
    /// </summary>
    public interface ITaxCalculator
    {
        /// <summary>
        /// This function will calculate the annual tax on the annual income.
        /// </summary>
        /// <param name="annualIncome"></param>
        /// <returns>double: CalculatedTax</returns>
        public double CalculateTax(double annualIncome);
    }
}
