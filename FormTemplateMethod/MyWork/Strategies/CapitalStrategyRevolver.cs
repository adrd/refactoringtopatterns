using System;

namespace FormTemplateMethod.MyWork.Strategies
{
    public class CapitalStrategyRevolver : CapitalStrategy
    {
        public override Double Capital(Loan loan)
        {
            return base.Capital(loan) + this.UnUsedCapital(loan);
        }

        private Double UnUsedCapital(Loan loan)
        {
            return (loan.UnusedRiskAmount() * base.Duration(loan) * this.UnusedRiskFactorFor(loan));
        }

        protected override Double RiskAmountFor(Loan loan)
        {
            return loan.OutstandingRiskAmount();
        }

        private Double UnusedRiskFactorFor(Loan loan)
        {
            return UnusedRiskFactors.GetFactors().ForRating(loan.GetRiskRating());
        }
    }
}