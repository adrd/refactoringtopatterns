using System;
using EncapsulateCompositeWithBuilder.MyWork;
using NUnit.Framework;

namespace RefactoringToPatterns.Tests.EncapsulateCompositeWithBuilder.MyWork
{
    [TestFixture]
    public class TagBuilderTests
    {
        [Test]
        public void TestBuildOneNode()
        {
            // Arrange 
            String expectedXml = "<flavors/>";
            
            // Act
            String actualXml = new TagBuilder("flavors").ToXml();

            // Assert
            Assert.AreEqual(expectedXml, actualXml);
        }

        [Test]
        public void TestBuildOneChild()
        {
            // Arrange
            String expectedXml =
                    "<flavors>" +
                      "<flavor/>" +
                    "</flavors>";

            // Act
            TagBuilder builder = new TagBuilder("flavors");
            builder.AddChild("flavor");
            String actualXml = builder.ToXml();

            // Assert
            Assert.AreEqual(expectedXml, actualXml);
        }

        [Test]
        public void TestBuildChildrenOfChildren()
        {
            // Arrange
            String expectedXml =
                    "<flavors>" +
                        "<flavor>" +
                            "<requirements>" +
                                "<requirement/>" +
                            "</requirements>" +
                        "</flavor>" +
                    "</flavors>";

            // Act
            TagBuilder builder = new TagBuilder("flavors");
            builder.AddChild("flavor");
            builder.AddChild("requirements");
            builder.AddChild("requirement");

            String actualXml = builder.ToXml();

            // Assert
            Assert.AreEqual(expectedXml, actualXml);
        }

        [Test]
        public void TestBuildSibling()
        {
            // Arrange
            String expectedXml =
                    "<flavors>" +
                        "<flavor1/>" +
                        "<flavor2/>" +
                    "</flavors>";

            // Act
            TagBuilder builder = new TagBuilder("flavors");
            builder.AddChild("flavor1");
            builder.AddSibling("flavor2");

            String actualXml = builder.ToXml();

            // Assert
            Assert.AreEqual(expectedXml, actualXml);
        }

        [Test]
        public void TestRepeatingChildrenAndGrandchildren()
        {
            // Arrange
            String expectedXml =
                    "<flavors>" +
                        "<flavor>" +
                            "<requirements>" +
                                "<requirement/>" +
                            "</requirements>" +
                        "</flavor>" +
                        "<flavor>" +
                            "<requirements>" +
                                "<requirement/>" +
                            "</requirements>" +
                        "</flavor>" +
                    "</flavors>";

            // Act
            TagBuilder builder = new TagBuilder("flavors");

            for (Int32 i = 0; i < 2; i++)
            {
                builder.AddToParent("flavors", "flavor");
                builder.AddChild("requirements");
                builder.AddChild("requirement");
            }

            String actualXml = builder.ToXml();

            // Assert
            Assert.AreEqual(expectedXml, actualXml);
        }

        [Test]
        public void TestParentNameNotFound()
        {
            // Arrange
            TagBuilder builder = new TagBuilder("flavors");

            // Act
            SystemException exception = Assert.Throws<SystemException>(() =>
            {
                for (Int32 i = 0; i < 2; i++)
                {
                    builder.AddToParent("favors", "flavor");
                    builder.AddChild("requirements");
                    builder.AddChild("requirement");
                }
            });

            // Assert
            const String expectedErrorMessage = "missing parent tag: favors";
            Assert.AreEqual(expectedErrorMessage, exception.Message);
        }

        [Test]
        public void TestAttributesAndValues()
        {
            // Arrange
            String expectedXml =
                    "<flavor name='Test-Driven Development'>" +
                        "<requirements>" +
                            "<requirement type='hardware'>" +
                                "1 computer for every 2 participants" +
                            "</requirement>" +
                            "<requirement type='software'>" +
                                "IDE" +
                            "</requirement>" +
                        "</requirements>" +
                    "</flavor>";

            // Act
            TagBuilder builder = new TagBuilder("flavor");
            builder.AddAttribute("name", "Test-Driven Development");
            builder.AddChild("requirements");
            builder.AddToParent("requirements", "requirement");
            builder.AddAttribute("type", "hardware");
            builder.AddValue("1 computer for every 2 participants");
            builder.AddToParent("requirements", "requirement");
            builder.AddAttribute("type", "software");
            builder.AddValue("IDE");

            String actualXml = builder.ToXml();

            // Assert
            Assert.AreEqual(expectedXml, actualXml);
        }

        [Test]
        public void TestToStringBufferSize()
        {
            // Arrange
            String expectedXml =
                    "<requirements>" +
                        "<requirement type='software'>" +
                            "IDE" +
                        "</requirement>" +
                    "</requirements>";

            // Act
            TagBuilder builder = new TagBuilder("requirements");
            builder.AddChild("requirement");
            builder.AddAttribute("type", "software");
            builder.AddValue("IDE");

            Int32 stringSize = builder.ToXml().Length;
            Int32 computedSize = builder.BufferSize();

            // Assert
            Assert.AreEqual(stringSize, computedSize);
        }
    }
}