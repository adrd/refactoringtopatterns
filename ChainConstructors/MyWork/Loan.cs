using System;

namespace ChainConstructors.MyWork
{
    public class Loan
    {
        private readonly CapitalStrategy _strategy;
        private Single _notional;
        private Single _outstanding;
        private Int32 _rating;
        private DateTime _expiry;
        private DateTime? _maturity;

        public Loan(Single notional, Single outstanding, Int32 rating, DateTime expiry) :
            this(new TermROC(), notional, outstanding, rating, expiry, null)
        {
			
        }

        public Loan(Single notional, Single outstanding, Int32 rating, DateTime expiry, DateTime maturity) :
            this(new RevolvingTermROC(), notional, outstanding, rating, expiry, maturity)
        {
            
        }

        // Example of: catch-all constructor
        public Loan(CapitalStrategy strategy, Single notional, Single outstanding, 
                    Int32 rating, DateTime expiry, DateTime? maturity)
        {
            this._strategy = strategy;
            this._notional = notional;
            this._outstanding = outstanding;
            this._rating = rating;
            this._expiry = expiry;
            this._maturity = maturity;
        }

		public CapitalStrategy CapitalStrategy => this._strategy;
    }
}