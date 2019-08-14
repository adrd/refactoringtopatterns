using System;
using System.Collections.Generic;
using ReplaceConditionalLogicWithStrategy.MyWork.Strategies;

namespace ReplaceConditionalLogicWithStrategy.MyWork
{
    public class Loan
    {
        double _commitment = 1.0;
        private DateTime? _expiry;
        private DateTime? _maturity;
        private double _outstanding;
        IList<Payment> _payments = new List<Payment>();
        private DateTime? _today = DateTime.Now;
        private DateTime _start;
        
        private double _riskRating;
        private double _unusedPercentage;
        private readonly CapitalStrategy _capitalStrategy = null;

        private Loan(double commitment, double notSureWhatThisIs, DateTime start, DateTime? expiry, DateTime? maturity, int riskRating, CapitalStrategy capitalStrategy)
        {
            this._expiry = expiry;
            this._commitment = commitment;
            this._today = null;
            this._start = start;
            this._maturity = maturity;
            this._riskRating = riskRating;
            this._unusedPercentage = 1.0;

            this._capitalStrategy = capitalStrategy;
        }

        public IList<Payment> GetPayments()
        {
            return this._payments;
        }

        public DateTime GetStart()
        {
            return this._start;
        }

        public DateTime? GetToday()
        {
            return this._today;
        }

        public Double GetRiskRating()
        {
            return this._riskRating;
        }

        public Double GetCommitment()
        {
            return this._commitment;
        }

        public DateTime? GetMaturity()
        {
            return this._maturity;
        }

        public DateTime? GetExpiry()
        {
            return this._expiry; 
        }

        public static Loan NewTermLoan(Double commitment, DateTime start, DateTime maturity, Int32 riskRating)
        {
            return new Loan(commitment, commitment, start, null, 
                            maturity, riskRating, new CapitalStrategyTermLoan());
        }

        public static Loan NewRevolver(Double commitment, DateTime start, DateTime expiry, Int32 riskRating) 
        {
            return new Loan(commitment, 0, start, expiry,
                            null, riskRating, new CapitalStrategyRevolver());
        }

        public static Loan NewAdvisedLine(double commitment, DateTime start, DateTime expiry, int riskRating)
        {
            if (riskRating > 3) return null;
            Loan advisedLine = new Loan(commitment, 0, start, expiry,
                            null, riskRating, new CapitalStrategyAdvisedLine());
            advisedLine.SetUnusedPercentage(0.1);
            return advisedLine;
        }

        public void Payment(double amount, DateTime paymentDate)
        {
            _payments.Add(new Payment(amount, paymentDate));
        }

        public Double Capital() {
            return this._capitalStrategy.Capital(this);
        }

        public Double Duration()
        {
            return this._capitalStrategy.Duration(this);
        }

        

        

        

        internal double GetUnusedPercentage()
        {
            return _unusedPercentage;
        }

        public void SetUnusedPercentage(double unusedPercentage) 
        {
            _unusedPercentage = unusedPercentage;
        }

        internal Double UnusedRiskAmount()
        {
            return (_commitment - _outstanding);
        }

        

        internal double OutstandingRiskAmount()
        {
            return _outstanding;
        }
    }
}