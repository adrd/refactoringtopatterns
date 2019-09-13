using System.Collections.ObjectModel;
using NUnit.Framework;
using ReplaceImplicitLanguageWithInterpreter.MyWork;
using ReplaceImplicitLanguageWithInterpreter.MyWork.Specifications;


namespace RefactoringToPatterns.Tests.ReplaceImplicitLanguageWithInterpreter.MyWork
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
            // Arrange
            ColorSpecification colorSpecification = new ColorSpecification(ProductColor.Red);
            
            // Act
            ReadOnlyCollection<Product> foundProducts = this._finder.SelectBy(colorSpecification);
            
            // Assert
            Assert.AreEqual(2, foundProducts.Count, "found 2 red products");
            Assert.IsTrue(foundProducts.Contains(this._fireTruck), "found fireTruck");
            Assert.IsTrue(foundProducts.Contains(this._toyConvertible), "found Toy Porsche Convertible");
        }

        [Test]
        public void TestFindByPrice()
        {
            // Arrange
            PriceSpecification priceSpecification = new PriceSpecification(8.95M);
            
            // Act
            ReadOnlyCollection<Product> foundProducts = this._finder.SelectBy(priceSpecification);

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
            // Arrange
            ColorSpecification colorSpecification = new ColorSpecification(ProductColor.Red);
            SizeSpecification sizeSpecification = new SizeSpecification(ProductSize.Small);
            BelowPriceSpecification belowPriceSpecification = new BelowPriceSpecification(10.00M);

            AndSpecification firstAndSpecification = new AndSpecification(colorSpecification, sizeSpecification);
            AndSpecification secondAndSpecification = new AndSpecification(firstAndSpecification, belowPriceSpecification);

            // Act
            ReadOnlyCollection<Product> foundProducts = this._finder.SelectBy(secondAndSpecification);

            // Assert
            Assert.AreEqual(0, foundProducts.Count, "found no small red products below $10.00");

            // Arrange
            colorSpecification = new ColorSpecification(ProductColor.Red);
            sizeSpecification = new SizeSpecification(ProductSize.Medium);
            belowPriceSpecification = new BelowPriceSpecification(10.00M);

            firstAndSpecification = new AndSpecification(colorSpecification, sizeSpecification);
            secondAndSpecification = new AndSpecification(firstAndSpecification, belowPriceSpecification);

            // Act
            foundProducts = this._finder.SelectBy(secondAndSpecification);

            // Assert
            Assert.AreEqual(this._fireTruck, foundProducts[0], "found firetruck when looking for cheap medium red toys");
        }

        [Test]
        public void TestFindBelowPriceAvoidingAColor()
        {
            // Arrange
            BelowPriceSpecification belowPriceSpecification = new BelowPriceSpecification(9.00M);
            ColorSpecification colorSpecification = new ColorSpecification(ProductColor.White);

            AndSpecification andSpecification = new AndSpecification(belowPriceSpecification, new NotSpecification(colorSpecification));

            // Act
            ReadOnlyCollection<Product> foundProducts = this._finder.SelectBy(andSpecification);

            // Assert
            Assert.AreEqual(1, foundProducts.Count, "found 1 non-white product < $9.00");
            Assert.IsTrue(foundProducts.Contains(this._fireTruck), "found fireTruck");

            // Arrange
            belowPriceSpecification = new BelowPriceSpecification(9.00M);
            colorSpecification = new ColorSpecification(ProductColor.Red);

            andSpecification = new AndSpecification(belowPriceSpecification, new NotSpecification(colorSpecification));

            // Act
            foundProducts = this._finder.SelectBy(andSpecification);

            // Arrange
            Assert.AreEqual(1, foundProducts.Count, "found 1 non-red product < $9.00");
            Assert.IsTrue(foundProducts.Contains(this._baseball), "found baseball");
        }
    }
}