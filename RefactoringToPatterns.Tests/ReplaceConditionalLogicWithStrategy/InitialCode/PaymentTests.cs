using System;
using NUnit.Framework;
using ReplaceConditionalLogicWithStrategy.InitialCode;

namespace RefactoringToPatterns.Tests.ReplaceConditionalLogicWithStrategy.InitialCode
{
    [TestFixture()]
    public class PaymentTests
    {
        private Payment _payment;
        private DateTime _christmasDay;

        [SetUp]
        public void Init()
        {
            this._christmasDay = new DateTime(2010, 12, 25);
            this._payment = new Payment(1000.0, this._christmasDay);
        }

        [Test()]
        public void payment_is_constructed_correctly()
        {
            
            Assert.Multiple(() => {
                Assert.AreEqual(1000, this._payment.Amount);
                Assert.AreEqual(this._christmasDay, this._payment.Date);
            });

        }
    }
}
