using System;
using System.Collections.Generic;
using ReplaceOneOrManyDistinctionsWithComposite.MyWork.Specifications;

namespace ReplaceOneOrManyDistinctionsWithComposite.MyWork
{
    public class ProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public void Add(Product product)
        {
            this._products.Add(product);
        }

        public List<Product> SelectBy(Specification specification)
        {
            List<Product> foundProducts = new List<Product>();

            foreach (Product product in this._products)
            {
                if (specification.IsSatisfiedBy(product))
                    foundProducts.Add(product);
            }

            return foundProducts;
        }
    }
}
