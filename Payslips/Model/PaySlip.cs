using Payslips.Model.Interface;
using System;

namespace Payslips.Model
{
    /// <summary>
    /// Payslip is the model for payslips containing all essential fields.
    /// Payslip has ITaxCalculator which is resposible for calculating the tax in this payslip.
    /// </summary>
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

        /// <summary>
        /// Return the Tax and income related information from this Payslip.
        /// </summary>
        public void GetMonthlyPayslip()
        {
            //As this is a console app we are printing the payslip as per requirement.
            //IMPROVMENT: It should return an object with the required info and then that object should be consumed by the caller.
            Console.WriteLine($"Monthly Payslip for: {Name}");
            Console.WriteLine($"Gross Monthly Income: {GrossMonthlyIncome}");
            Console.WriteLine($"Monthly Income Tax: {MonthlyIncomeTax}");
            Console.WriteLine($"Net Monthly Income: {NetMonthlyIncome}");
        }
    }
}
