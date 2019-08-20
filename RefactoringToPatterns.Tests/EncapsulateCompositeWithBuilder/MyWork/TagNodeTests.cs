using System;
using EncapsulateCompositeWithBuilder.MyWork;
using NUnit.Framework;

namespace RefactoringToPatterns.Tests.EncapsulateCompositeWithBuilder.MyWork
{
    [TestFixture]
    public class TagNodeTests
    {
        private const String SamplePrice = "2.39";

        [Test]
        public void TestSimpleTagWithOneAttributeAndValue()
        {
            String expected =
                    "<price currency=" +
                    "'" +
                    "USD" +
                    "'>" +
                    SamplePrice +
                    "</price>";

            TagNode priceTag = new TagNode("price");
            priceTag.AddAttribute("currency", "USD");
            priceTag.AddValue(SamplePrice);
            Assert.AreEqual(expected, priceTag.ToString());
        }

        [Test]
        public void TestCompositeTagoneChild()
        {
            String expected =
                    "<product>" +
                        "<price/>" +
                    "</product>"; 

            TagNode productTag = new TagNode("product");
            productTag.Add(new TagNode("price"));

            Assert.AreEqual(expected, productTag.ToString());
        }

        [Test]
        public void TestAddingChildrenAndGrandChildren()
        {
            String expected =
                    "<orders>" +
                        "<order>" +
                            "<product/>" +
                        "</order>" +
                    "</orders>";

            TagNode ordersTag = new TagNode("orders");
            TagNode orderTag = new TagNode("order");
            orderTag.Add(new TagNode("product"));
            ordersTag.Add(orderTag);

            Assert.AreEqual(expected, ordersTag.ToString());
        }

        [Test]
        public void TestParents()
        {
            TagNode root = new TagNode("root");
            Assert.Null(root.ParentNode);

            TagNode childNode = new TagNode("child");
            root.Add(childNode);

            Assert.AreEqual(root, childNode.ParentNode);
            Assert.AreEqual("root", childNode.ParentNode.Name);
        }

        [Test]
        public void TestSelfClosingSingularTag()
        {
            String expected = "<flavors/>";

            TagNode flavorsTag = new TagNode("flavors");

            Assert.AreEqual(expected, flavorsTag.ToString());
        }
    }
}
