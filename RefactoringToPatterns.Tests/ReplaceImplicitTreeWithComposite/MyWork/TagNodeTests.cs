using System;
using NUnit.Framework;
using ReplaceImplicitTreeWithComposite.MyWork;

namespace RefactoringToPatterns.Tests.ReplaceImplicitTreeWithComposite.MyWork
{
    [TestFixture]
    public class TagNodeTests
    {
        private static readonly String SAMPLE_PRICE = "8.95";

        [Test]
        public void Test_SimpleTag_WithOneAttribute_And_Value() {

            // Arrange
            String expected =
                "<price currency=" +
                    "'" +
                       "USD" +
                    "'>" +
                        SAMPLE_PRICE +
                "</price>";

            // Act
            TagNode priceTag = new TagNode("price");
            
            priceTag.AddAttribute("currency", "USD");
            priceTag.AddValue(SAMPLE_PRICE);
            
            // Assert
            Assert.AreEqual(expected, priceTag.ToString(), "price XML");
        }

        [Test]
        public void Test_CompositeTag_OneChild() {
            
            // Arrange
            String expected =
                "<product>" +
                    "<price>" +
                    "</price>" +
                "</product>";
            
            // Act
            TagNode productTag = new TagNode("product");

            productTag.Add(new TagNode("price"));
            
            // Assert
            Assert.AreEqual(expected, productTag.ToString(), "price XML");
        }

        [Test]
        public void Test_AddingChildren_And_GrandChildren() {
            
            // Arrange
            String expected =
                "<orders>" +
                    "<order>" +
                        "<product>" +
                        "</product>" +
                    "</order>" +
                "</orders>";
            
            // Act
            TagNode ordersTag = new TagNode("orders");
            TagNode orderTag = new TagNode("order");
            TagNode productTag = new TagNode("product");
            
            ordersTag.Add(orderTag);
            orderTag.Add(productTag);
         
            // Assert
            Assert.AreEqual(expected, ordersTag.ToString(), "price XML");
        }


    }
}
