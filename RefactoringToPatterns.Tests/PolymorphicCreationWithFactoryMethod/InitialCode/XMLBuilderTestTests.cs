﻿using NUnit.Framework;
using PolymorphicCreationWithFactoryMethod.InitialCode;

namespace RefactoringToPatterns.Tests.PolymorphicCreationWithFactoryMethod.InitialCode
{
    [TestFixture()]
    public class XMLBuilderTestTests
    {
        XMLBuilderTest _xmlBuilderTest;

		[SetUp]
		public void Init()
		{
			this._xmlBuilderTest = new XMLBuilderTest();
			this._xmlBuilderTest.TestAddAboveRoot();
		}

		[Test]
		public void test_XMLBuilderTest_has_an_XMLBuilder()
		{
			Assert.IsInstanceOf(typeof(XMLBuilder), this._xmlBuilderTest.Builder);
		}
    }
}