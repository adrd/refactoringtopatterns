using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ReplaceImplicitLanguageWithInterpreter.InitialCode
{
    public class ProductFinder
    {
        private readonly ProductRepository _productRepository;

        public ProductFinder(ProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public ReadOnlyCollection<Product> ByColor(ProductColor productColor)
        {
            List<Product> foundProducts = new List<Product>();

            foreach (Product product in this._productRepository.Products)
            {
                if (product.GetColor() == productColor)
                    foundProducts.Add(product);
            }

            return new ReadOnlyCollection<Product>(foundProducts);
        }

        public ReadOnlyCollection<Product> ByPrice(Decimal price)
        {
            List<Product> foundProducts = new List<Product>();

            foreach (Product product in this._productRepository.Products)
            {
                if (product.GetPrice() == price)
                    foundProducts.Add(product);
            }

            return new ReadOnlyCollection<Product>(foundProducts);
        }

        public ReadOnlyCollection<Product> ByColorSizeAndBelowPrice(ProductColor productColor, ProductSize productSize, Decimal price)
        {
            List<Product> foundProducts = new List<Product>();

            foreach (Product product in this._productRepository.Products)
            {
                if (product.GetColor() == productColor && product.GetSize() == productSize && product.GetPrice() < price)
                    foundProducts.Add(product);
            }

            return new ReadOnlyCollection<Product>(foundProducts);
        }

        public ReadOnlyCollection<Product> BelowPriceAvoidingAColor(Decimal price, ProductColor productColor)
        {
            List<Product> foundProducts = new List<Product>();

            foreach (Product product in this._productRepository.Products)
            {
                if (product.GetPrice() < price && product.GetColor() != productColor)
                    foundProducts.Add(product);
            }

            return new ReadOnlyCollection<Product>(foundProducts);
        }
    }
}