using System;

namespace ReplaceConditionalLogicWithStrategy.MyWork.Strategies
{
    public abstract class CapitalStrategy
    {
        private static readonly Int64 MILLIS_PER_DAY = 86400000;
        private static readonly Int64 DAYS_PER_YEAR = 365;

        public abstract Double Capital(Loan loan);

        protected Double RiskFactorFor(Loan loan)
        {
            return InitialCode.RiskFactor.GetFactors().ForRating(loan.GetRiskRating());
        }

        public virtual Double Duration(Loan loan)
        {
            return this.YearsTo(loan.GetExpiry(), loan);
        }

        protected Double YearsTo(DateTime? endDate, Loan loan)
        {
            DateTime? beginDate = (loan.GetToday() == null ? loan.GetStart() : loan.GetToday());

            return (Double)((endDate?.Ticks - beginDate?.Ticks) / MILLIS_PER_DAY / DAYS_PER_YEAR);
        }
    }
}