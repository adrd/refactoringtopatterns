using System;

namespace ReplaceConstructorsWithCreationMethods.MyWork
{
    // Var 1 - Replace Constructors With Creation Methods
	public class Loan
	{
		private double _commitment;
		private readonly double _outstanding;
		private readonly int _riskRating;
		private readonly DateTime? _maturity;
		private readonly DateTime? _expiry;
		private readonly CapitalStrategy _capitalStrategy;

  //      public Loan(double commitment, int riskRating, DateTime? maturity)
  //          : this(commitment, 0.00, riskRating, maturity, null)
		//{

		//}

		//public Loan(double commitment, int riskRating, DateTime? maturity, DateTime? expiry)
		//	: this(commitment, 0.00, riskRating, maturity, expiry)
		//{

		//}

		//private Loan(double commitment, double outstanding, 
  //                  int riskRating, DateTime? maturity, DateTime? expiry)
		//	: this(null, commitment, outstanding, riskRating, maturity, expiry)
		//{

		//}

		//public Loan(CapitalStrategy capitalStrategy, double commitment,
		//			int riskRating, DateTime? maturity, DateTime? expiry)
		//	: this(capitalStrategy, commitment, 0.00, riskRating, maturity, expiry)
		//{

		//}

		private Loan(CapitalStrategy capitalStrategy, double commitment,
					double outstanding, int riskRating,
                    DateTime? maturity, DateTime? expiry)
		{
			this._commitment = commitment;
			this._outstanding = outstanding;
			this._riskRating = riskRating;
			this._maturity = maturity;
			this._expiry = expiry;
			this._capitalStrategy = capitalStrategy;

			if (capitalStrategy == null)
			{
				if (expiry == null)
					this._capitalStrategy = new CapitalStrategyTermLoan();
				else if (maturity == null)
					this._capitalStrategy = new CapitalStrategyRevolver();
				else
					this._capitalStrategy = new CapitalStrategyRCTL();
			}
		}

		public CapitalStrategy CapitalStrategy
		{
			get
			{
				return _capitalStrategy;
			}
		}

        public static Loan CreateTermLoan(Double commitment, Int32 riskRating, DateTime? maturity)
        {
            return new Loan(null, commitment, 0, riskRating, maturity, null);
        }

        public static Loan CreateTermLoan(RiskAdjustedCapitalStrategy riskAdjustedCapitalStrategy, Double commitment, 
                                          Double outstanding, Int32 riskRating, DateTime? maturity)
        {
            return new Loan(riskAdjustedCapitalStrategy, commitment, outstanding, riskRating, maturity, null);
        }

        public static Loan CreateRevolver(Double commitment, Int32 riskRating, DateTime? maturity, DateTime? expiry)
        {
            return new Loan(null, commitment, 0.00, riskRating, maturity, expiry);
        }

        public static Loan CreateRevolver(CapitalStrategyRevolver capitalStrategyRevolver, Double commitment,
                                          Int32 riskRating, DateTime? maturity, DateTime? expiry)
        {
            return new Loan(capitalStrategyRevolver, commitment, 0.00, riskRating, maturity, expiry);
        }


        public static Loan CreateRCTL(Double commitment, Double outstanding, Int32 riskRating, DateTime? maturity, DateTime? expiry)
        {
            return new Loan(null, commitment, outstanding, riskRating, maturity, expiry);
        }

        public static Loan CreateRCTL(CapitalStrategyRCTL capitalStrategyRctl, Double commitment, Double outstanding, 
                                      Int32 riskRating, DateTime? maturity, DateTime? expiry)
        {
            return new Loan(capitalStrategyRctl, commitment, outstanding, riskRating, maturity, expiry);
        }
    }

    // Var 2 - Factory Class
    // tb constructorul din Loan sa fie facut internal pentru a limita scopul instantierii
    //public class LoanFactory
    //{
    //    public static Loan CreateTermLoan(Double commitment, Int32 riskRating, DateTime? maturity)
    //    {
    //        return new Loan(null, commitment, 0, riskRating, maturity, null);
    //    }

    //    public static Loan CreateTermLoan(RiskAdjustedCapitalStrategy riskAdjustedCapitalStrategy, Double commitment, 
    //        Double outstanding, Int32 riskRating, DateTime? maturity)
    //    {
    //        return new Loan(riskAdjustedCapitalStrategy, commitment, outstanding, riskRating, maturity, null);
    //    }

    //    public static Loan CreateRevolver(Double commitment, Int32 riskRating, DateTime? maturity, DateTime? expiry)
    //    {
    //        return new Loan(null, commitment, 0.00, riskRating, maturity, expiry);
    //    }

    //    public static Loan CreateRevolver(CapitalStrategyRevolver capitalStrategyRevolver, Double commitment,
    //        Int32 riskRating, DateTime? maturity, DateTime? expiry)
    //    {
    //        return new Loan(capitalStrategyRevolver, commitment, 0.00, riskRating, maturity, expiry);
    //    }


    //    public static Loan CreateRCTL(Double commitment, Double outstanding, Int32 riskRating, DateTime? maturity, DateTime? expiry)
    //    {
    //        return new Loan(null, commitment, outstanding, riskRating, maturity, expiry);
    //    }

    //    public static Loan CreateRCTL(CapitalStrategyRCTL capitalStrategyRctl, Double commitment, Double outstanding, 
    //        Int32 riskRating, DateTime? maturity, DateTime? expiry)
    //    {
    //        return new Loan(capitalStrategyRctl, commitment, outstanding, riskRating, maturity, expiry);
    //    }
    //}
}