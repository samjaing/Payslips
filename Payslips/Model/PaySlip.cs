using Payslips.Model.Interface;
using System;

namespace Payslips.Model
{
    public class PaySlip : IPayslip
    {
        public string Name { get; set;  }

        private readonly double _annualIncome;

        private ITaxCalculator _calculator { get; set; }

        private PaySlip() { }

        public PaySlip(ITaxCalculator calculator, string name, double annualIncome) 
        {
            Name = name;
            _calculator = calculator;
            _annualIncome = annualIncome;
        }

        public double GrossMonthlyIncome => _annualIncome / 12;
        public double MonthlyIncomeTax => _calculator.CalculateTax(_annualIncome) /12;
        public double NetMonthlyIncome => GrossMonthlyIncome - MonthlyIncomeTax;

        public void GetMonthlyPayslip()
        {
            //Change it to retrun some structure.
            Console.WriteLine($"Monthly Payslip for: {Name}");
            Console.WriteLine($"Gross Monthly Income: {GrossMonthlyIncome}");
            Console.WriteLine($"Monthly Income Tax: {MonthlyIncomeTax}");
            Console.WriteLine($"Net Monthly Income: {NetMonthlyIncome}");
        }
    }
}
