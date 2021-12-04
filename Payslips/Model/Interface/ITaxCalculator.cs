using System;
using System.Collections.Generic;
using System.Text;

namespace Payslips.Model.Interface
{
    public interface ITaxCalculator
    {
        public double CalculateTax(double annualIncome);
    }
}
