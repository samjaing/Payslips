namespace Payslips.Model.Interface
{
    /// <summary>
    /// This interface should be implemented by every class which act as a payslip.
    /// </summary>
    public interface IPayslip
    {
        /// <summary>
        /// GetMonthlyPayslip is resposible for the retrieving the monthly payslip to present it to user.
        /// </summary>
        public void GetMonthlyPayslip();
    }
}
