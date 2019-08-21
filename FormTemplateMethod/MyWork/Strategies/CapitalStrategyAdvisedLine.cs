using System;

namespace FormTemplateMethod.MyWork.Strategies
{
    public class CapitalStrategyAdvisedLine : CapitalStrategy
    {
        protected override Double RiskAmountFor(Loan loan)
        {
            return loan.GetCommitment() * loan.GetUnusedPercentage();
        }
    }
}