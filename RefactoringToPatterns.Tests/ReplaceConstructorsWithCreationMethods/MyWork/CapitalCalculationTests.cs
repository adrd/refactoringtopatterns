﻿using System;
using NUnit.Framework;
using ReplaceConstructorsWithCreationMethods.MyWork;

namespace RefactoringToPatterns.Tests.ReplaceConstructorsWithCreationMethods.MyWork
{
    [TestFixture]
    public class CapitalCalculationTests
    {
        private readonly DateTime? _maturity = new DateTime(2020, 10, 2);
        private readonly DateTime? _expiry = new DateTime(2021, 10, 2);

        private const double Commitment = 3.0;
        private const double Outstanding = 12.9;
        private RiskAdjustedCapitalStrategy _riskAdjustedCapitalStrategy = 
            new RiskAdjustedCapitalStrategy();
        const int RiskRating = 5;

        [SetUp]
        public void Init()
        {
        }

        [Test]
        public void test_term_loan_no_payments()
        {
            //Loan loan = new Loan(Commitment, RiskRating, _maturity);
            //Assert.IsInstanceOf(typeof(CapitalStrategyTermLoan), loan.CapitalStrategy);

            Loan termLoan = Loan.CreateTermLoan(Commitment, RiskRating, this._maturity);

            Assert.IsInstanceOf(typeof(CapitalStrategyTermLoan), termLoan.CapitalStrategy);
        }

        [Test]
        public void test_term_loan_one_payment()
        {
            //Loan loan = new Loan(Commitment, RiskRating, _maturity);
            //Assert.IsInstanceOf(typeof(CapitalStrategyTermLoan), loan.CapitalStrategy);

            Loan termLoan = Loan.CreateTermLoan(Commitment, RiskRating, this._maturity);

            Assert.IsInstanceOf(typeof(CapitalStrategyTermLoan), termLoan.CapitalStrategy);
        }

        [Test]
        public void test_revolver_loan_no_payments()
        {
            //Loan loan = new Loan(Commitment, RiskRating, null, _expiry);
            //Assert.IsInstanceOf(typeof(CapitalStrategyRevolver), loan.CapitalStrategy);

            Loan revolver = Loan.CreateRevolver(Commitment, RiskRating, null, this._expiry);

            Assert.IsInstanceOf(typeof(CapitalStrategyRevolver), revolver.CapitalStrategy);
        }

        [Test]
        public void test_RCTL_loan_one_payment()
        {
            //Loan loan = new Loan(Commitment, Outstanding, RiskRating, _maturity, _expiry);
            //Assert.IsInstanceOf(typeof(CapitalStrategyRCTL), loan.CapitalStrategy);

            Loan rctl = Loan.CreateRCTL(Commitment, Outstanding, RiskRating, this._maturity, this._expiry);

            Assert.IsInstanceOf(typeof(CapitalStrategyRCTL), rctl.CapitalStrategy);
        }

        [Test]
        public void test_term_loan_with_risk_adjusted_capital_strategy()
        {
            //Loan loan = new Loan(_riskAdjustedCapitalStrategy, 
            //                     Commitment, Outstanding, RiskRating, 
            //                     _maturity, null);
            
            //Assert.IsInstanceOf(typeof(RiskAdjustedCapitalStrategy), loan.CapitalStrategy);

            Loan termLoan = Loan.CreateTermLoan(this._riskAdjustedCapitalStrategy, Commitment, Outstanding, RiskRating,
                                this._maturity);

            Assert.IsInstanceOf(typeof(RiskAdjustedCapitalStrategy), termLoan.CapitalStrategy);
        }
    }
}