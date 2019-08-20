using NUnit.Framework;
using PolymorphicCreationWithFactoryMethod.MyWork;

namespace RefactoringToPatterns.Tests.PolymorphicCreationWithFactoryMethod.MyWork
{
    [TestFixture]
    public class DOMBuilderTestTests
    {
		DOMBuilderTest _domBuilderTest;

		[SetUp]
		public void Init()
		{
            this._domBuilderTest = new DOMBuilderTest();
            this._domBuilderTest.TestAddAboveRoot();
        }

        [Test]
        public void test_DOMBuilderTest_has_a_DOMBuilder()
        {
            Assert.IsInstanceOf(typeof(DOMBuilder), this._domBuilderTest.Builder);
        }
    }
}