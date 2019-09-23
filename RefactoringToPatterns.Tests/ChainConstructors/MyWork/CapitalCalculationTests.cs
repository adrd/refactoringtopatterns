using System;
using ChainConstructors.MyWork;
using NUnit.Framework;

namespace RefactoringToPatterns.Tests.ChainConstructors.MyWork
{
    [TestFixture]
	public class CapitalCalculationTests
	{
        [SetUp]
		public void Init()
		{
		}

        [Test]
        public void Four_parameter_constructor_yields_loan_with_TermROC_strategy()
		{
            // Act
            Loan loan = new Loan(1.0f, 2.0f, 4, new DateTime());

            // Assert
            Assert.IsInstanceOf(typeof(TermROC), loan.CapitalStrategy);
		}

        [Test]
        public void Five_parameter_constructor_yields_revolving_TermROC_strategy() 
        {
            // Act
            Loan loan = new Loan(1.0f, 2.0f, 4, new DateTime(), new DateTime());

            // Assert
            Assert.IsInstanceOf(typeof(RevolvingTermROC), loan.CapitalStrategy);
        }
	}
}