using System.Collections.Generic;
using NUnit.Framework;
using ReplaceOneOrManyDistinctionsWithComposite.InitialCode;
using ReplaceOneOrManyDistinctionsWithComposite.InitialCode.Specifications;

namespace RefactoringToPatterns.Tests.ReplaceOneOrManyDistinctionsWithComposite.InitialCode
{
    [TestFixture()]
    public class ProductRepositoryTests
    {
        private ProductRepository _repository;

        private readonly Product _fireTruck = new Product("f1234", "Fire Truck", ProductColor.Red, 8.95M, ProductSize.Medium);
        private readonly Product _barbieClassic = new Product("b7654", "Barbie Classic", ProductColor.Yellow, 15.95M, ProductSize.Small);
        private readonly Product _frisbee = new Product("f4321", "Frisbee", ProductColor.Pink, 9.99M, ProductSize.Large);
        private readonly Product _baseball = new Product("b2343", "Baseball", ProductColor.White, 8.95M, ProductSize.NotApplicable);
        private readonly Product _toyConvertible = new Product("p1112", "Toy Porsche Convertible", ProductColor.Red, 230.00M, ProductSize.NotApplicable);

        [SetUp]
        protected void Init()
        {
            this._repository = new ProductRepository();

            this._repository.Add(this._fireTruck);
            this._repository.Add(this._barbieClassic);
            this._repository.Add(this._frisbee);
            this._repository.Add(this._baseball);
            this._repository.Add(this._toyConvertible);
        }

        [Test]
        public void TestFindByColor()
        {
            // Act
            List<Product> foundProducts = this._repository.SelectBy(new ColorSpecification(ProductColor.Red));

            // Assert
            Assert.AreEqual(2, foundProducts.Count, "found 2 red products");
            Assert.IsTrue(foundProducts.Contains(this._fireTruck), "found fireTruck");
            Assert.IsTrue(foundProducts.Contains(this._toyConvertible), "found Toy Porsche Convertible");
        }

        [Test]
        public void TestFindByColorSizeAndBelowPrice()
        {
            // Arrange
            List<Specification> specs = new List<Specification>();

            // Act
            specs.Add(new ColorSpecification(ProductColor.Red));
            specs.Add(new SizeSpecification(ProductSize.Small));
            specs.Add(new BelowPriceSpecification(10.00M));

            List<Product> foundProducts = this._repository.SelectBy(specs);

            // Assert
            Assert.AreEqual(0, foundProducts.Count, "small red products below $10.00");
        }
    }
}
