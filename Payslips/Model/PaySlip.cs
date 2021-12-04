using Payslips.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Payslips.Model
{
    public class PaySlip : IPayslip
    {
        [Required]
        public string Name { get; set;  }

        private readonly double _annualIncome;

        [Required]
        private ITaxCalculator _calculator { get; set; }

        private PaySlip() { }

        public PaySlip(ITaxCalculator calculator, int annualIncome) 
        {
            //_calculator = calculator;
            _calculator = new TaxCalculator();
            _annualIncome = annualIncome;
        }

        private double GrossMonthlyIncome => _annualIncome / 12;
        private double MonthlyIncomeTax => _calculator.CalculateTax(_annualIncome);
        private double NetMonthlyIncome => GrossMonthlyIncome - MonthlyIncomeTax;
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
