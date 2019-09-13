using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReplaceImplicitLanguageWithInterpreter.MyWork.Specifications;

namespace ReplaceImplicitLanguageWithInterpreter.MyWork
{
    public class ProductFinder
    {
        private readonly ProductRepository _productRepository;

        public ProductFinder(ProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public ReadOnlyCollection<Product> SelectBy(Specification priceSpecification)
        {
            List<Product> foundProducts = new List<Product>();

            foreach (Product product in this._productRepository.Products)
            {
                if (priceSpecification.IsSatisfiedBy(product))
                    foundProducts.Add(product);
            }

            return new ReadOnlyCollection<Product>(foundProducts);
        }
    }
}