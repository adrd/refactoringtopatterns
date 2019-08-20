using System;
using FormTemplateMethod.MyWork;
using NUnit.Framework;

namespace RefactoringToPatterns.Tests.FormTemplateMethod.MyWork
{
    [TestFixture()]
    public class TermLoanStrategy
    {
        private readonly int HIGH_RISK_TAKING = 5;
        private readonly double LOAN_AMOUNT = 10000.00;
        private readonly double TWO_DIGIT_PRECISION = 0.001;

        [Test()]
        public void test_term_loan_same_payments()
        {
            DateTime start = November(20, 2003);
            DateTime maturity = November(20, 2006);

            Loan termLoan = Loan.NewTermLoan(this.LOAN_AMOUNT, start, maturity, this.HIGH_RISK_TAKING);
            termLoan.Payment(1000.00, November(20, 2004));
            termLoan.Payment(1000.00, November(20, 2005));
            termLoan.Payment(1000.00, November(20, 2006));

            var termStrategy = new CapitalStrategyTermLoan();

            Assert.Multiple(() => {
                Assert.AreEqual(20027, termStrategy.Duration(termLoan), this.TWO_DIGIT_PRECISION);
                Assert.AreEqual(6008100, termStrategy.Capital(termLoan), this.TWO_DIGIT_PRECISION);
            });
        }

        private static DateTime November(int dayOfMonth, int year)
        {
            return new DateTime(year, 11, dayOfMonth);
        }
    }
}