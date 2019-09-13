using System.Collections.ObjectModel;
using NUnit.Framework;
using ReplaceImplicitLanguageWithInterpreter.InitialCode;

namespace RefactoringToPatterns.Tests.ReplaceImplicitLanguageWithInterpreter.InitialCode
{
    [TestFixture()]
    public class ProductFinderTests
    {
        private ProductFinder _finder;

        private readonly Product _fireTruck = new Product("f1234", "Fire Truck", ProductColor.Red, 8.95M, ProductSize.Medium);
        private readonly Product _barbieClassic = new Product("b7654", "Barbie Classic", ProductColor.Yellow, 15.95M, ProductSize.Small);
        private readonly Product _frisbee = new Product("f4321", "Frisbee", ProductColor.Pink, 9.99M, ProductSize.Large);
        private readonly Product _baseball = new Product("b2343", "Baseball", ProductColor.White, 8.95M, ProductSize.NotApplicable);
        private readonly Product _toyConvertible = new Product("p1112", "Toy Porsche Convertible", ProductColor.Red, 230.00M, ProductSize.NotApplicable);

        [SetUp]
        protected void Init()
        {
            this._finder = new ProductFinder(this.CreateProductRepository());
        }

        private ProductRepository CreateProductRepository()
        {
            ProductRepository productRepository = new ProductRepository();

            productRepository.Add(this._fireTruck);
            productRepository.Add(this._barbieClassic);
            productRepository.Add(this._frisbee);
            productRepository.Add(this._baseball);
            productRepository.Add(this._toyConvertible);

            return productRepository;
        }

        [Test]
        public void TestFindByColor()
        {
            // Act
            ReadOnlyCollection<Product> foundProducts = this._finder.ByColor(ProductColor.Red);
            
            // Assert
            Assert.AreEqual(2, foundProducts.Count, "found 2 red products");
            Assert.IsTrue(foundProducts.Contains(this._fireTruck), "found fireTruck");
            Assert.IsTrue(foundProducts.Contains(this._toyConvertible), "found Toy Porsche Convertible");
        }

        [Test]
        public void TestFindByPrice()
        {
            // Act
            ReadOnlyCollection<Product> foundProducts = this._finder.ByPrice(8.95M);

            // Assert
            Assert.AreEqual(2, foundProducts.Count, "found products that cost $8.95");

            foreach (Product foundProduct in foundProducts)
            {
                Assert.AreEqual(8.95M, foundProduct.GetPrice());
            }
        }

        [Test]
        public void TestFindByColorSizeAndBelowPrice()
        {
            // Act
            ReadOnlyCollection<Product> foundProducts = this._finder.ByColorSizeAndBelowPrice(ProductColor.Red, ProductSize.Small, 10.00M);

            // Assert
            Assert.AreEqual(0, foundProducts.Count, "found no small red products below $10.00");

            // Act
            foundProducts = this._finder.ByColorSizeAndBelowPrice(ProductColor.Red, ProductSize.Medium, 10.00M);

            // Assert
            Assert.AreEqual(this._fireTruck, foundProducts[0], "found firetruck when looking for cheap medium red toys");
        }

        [Test]
        public void TestFindBelowPriceAvoidingAColor()
        {
            // Act
            ReadOnlyCollection<Product> foundProducts = this._finder.BelowPriceAvoidingAColor(9.00M, ProductColor.White);

            // Assert
            Assert.AreEqual(1, foundProducts.Count, "found 1 non-white product < $9.00");
            Assert.IsTrue(foundProducts.Contains(this._fireTruck), "found fireTruck");

            // Act
            foundProducts = this._finder.BelowPriceAvoidingAColor(9.00M, ProductColor.Red);

            // Arrange
            Assert.AreEqual(1, foundProducts.Count, "found 1 non-red product < $9.00");
            Assert.IsTrue(foundProducts.Contains(this._baseball), "found baseball");
        }
    }
}