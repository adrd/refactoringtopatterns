using System;

namespace ReplaceConditionalLogicWithStrategy.MyWork.Strategies
{
    public class CapitalStrategyTermLoan : CapitalStrategy
    {
        public override Double Capital(Loan loan)
        {
            return loan.GetCommitment() * this.Duration(loan) * base.RiskFactorFor(loan);
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

            foreach (Payment payment in loan.GetPayments())
            {
                sumOfPayments += payment.Amount;
                weightedAverage += base.YearsTo(payment.Date, loan) * payment.Amount;
            }

            if (loan.GetCommitment() != 0.0)
            {
                duration = weightedAverage / sumOfPayments;
            }

            return duration;
        }
    }
}