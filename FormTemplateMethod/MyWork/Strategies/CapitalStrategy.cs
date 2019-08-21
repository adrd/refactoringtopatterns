using System;

namespace FormTemplateMethod.MyWork.Strategies
{
    public abstract class CapitalStrategy
    {
        private Int64 MILLIS_PER_DAY = 86400000;
        private Int64 DAYS_PER_YEAR = 365;

        protected Double RiskFactorFor(Loan loan)
        {
            return RiskFactor.GetFactors().ForRating(loan.GetRiskRating());
        }

        private Double UnusedRiskFactorFor(Loan loan)
        {
            return UnusedRiskFactors.GetFactors().ForRating(loan.GetRiskRating());
        }

        public virtual Double Duration(Loan loan)
        {
            return this.YearsTo(loan.GetExpiry(), loan);
        }

        protected Double YearsTo(DateTime? endDate, Loan loan)
        {
            DateTime? beginDate = (loan.GetToday() == null ? loan.GetStart() : loan.GetToday());
            return (Double)((endDate?.Ticks - beginDate?.Ticks) / this.MILLIS_PER_DAY / this.DAYS_PER_YEAR);
        }

        // Form Template Method
        public virtual Double Capital(Loan loan)
        {
            return this.RiskAmountFor(loan) * this.Duration(loan) * this.RiskFactorFor(loan);
        }

        protected abstract Double RiskAmountFor(Loan loan);
    }
}