using System;

namespace ChainConstructors.InitialCode
{
    public class Loan
    {
        private readonly CapitalStrategy _strategy;
        private Single _notional;
        private Single _outstanding;
        private Int32 _rating;
        private DateTime _expiry;
        private DateTime _maturity;

        public Loan(Single notional, Single outstanding, Int32 rating, DateTime expiry)
        {
			this._strategy = new TermROC();
			this._notional = notional;
			this._outstanding = outstanding;
			this._rating = rating;
            this._expiry = expiry;
        }

        public Loan(Single notional, Single outstanding, Int32 rating, DateTime expiry, DateTime maturity) 
        {
            this._strategy = new RevolvingTermROC();
            this._notional = notional;
            this._outstanding = outstanding;
            this._rating = rating;
            this._expiry = expiry;
            this._maturity = maturity;
        }

        public Loan(CapitalStrategy strategy, Single notional, Single outstanding, 
                    Int32 rating, DateTime expiry, DateTime maturity)
        {
            this._strategy = strategy;
            this._notional = notional;
            this._outstanding = outstanding;
            this._rating = rating;
            this._expiry = expiry;
            this._maturity = maturity;
        }

		public CapitalStrategy CapitalStrategy
		{
			get
			{
				return _strategy;
			}
		}
		
    }
}