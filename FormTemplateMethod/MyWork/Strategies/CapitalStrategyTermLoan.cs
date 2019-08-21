using System;

namespace FormTemplateMethod.MyWork.Strategies
{
    public class CapitalStrategyTermLoan : CapitalStrategy
    {
        private readonly Double EPSILON = 0.001;

        protected override Double RiskAmountFor(Loan loan)
        {
            return loan.GetCommitment();
        }

        public override Double Duration(Loan loan)
        {
            return this.WeightedAverageDuration(loan);
        }

        private Double WeightedAverageDuration(Loan loan)
        {
            Double duration = 0.0;
            Double weightedAverage = 0.0;
            Double sumOfPayments = 0.0;

            foreach (Payment payment in loan.Payments())
            {
                sumOfPayments += payment.Amount;
                weightedAverage += this.YearsTo(payment.Date, loan) * payment.Amount;
            }

            if (Math.Abs(loan.GetCommitment()) > this.EPSILON)
            {
                duration = weightedAverage / sumOfPayments;
            }

            return duration;
        }
    }
}