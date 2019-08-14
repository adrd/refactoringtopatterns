using System;

namespace ReplaceConditionalLogicWithStrategy.MyWork.Strategies
{
    public class CapitalStrategyRevolver : CapitalStrategy
    {
        public override Double Capital(Loan loan)
        {
            return (loan.OutstandingRiskAmount() * base.Duration(loan) * base.RiskFactorFor(loan))
                 + (loan.UnusedRiskAmount() * base.Duration(loan) * this.UnusedRiskFactorFor(loan));
        }

        private Double UnusedRiskFactorFor(Loan loan)
        {
            return UnusedRiskFactors.GetFactors().ForRating(loan.GetRiskRating());
        }
    }
}