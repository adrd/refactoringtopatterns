﻿using System;

namespace ReplaceConditionalLogicWithStrategy.MyWork.Strategies
{
    public class CapitalStrategyAdvisedLine : CapitalStrategy
    {
        public override Double Capital(Loan loan)
        {
            return loan.GetCommitment() * loan.GetUnusedPercentage() * base.Duration(loan) * base.RiskFactorFor(loan);
        }
    }
}