using System;
using System.Collections.Generic;
using ReplaceOneOrManyDistinctionsWithComposite.InitialCode.Specifications;

namespace ReplaceOneOrManyDistinctionsWithComposite.InitialCode
{
    public class ProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public void Add(Product product)
        {
            this._products.Add(product);
        }

        // one-object method
        // One solution is to delegate call from this method to below method that accepts more specifications
        public List<Product> SelectBy(Specification spec)
        {
            List<Product> foundProducts = new List<Product>();

            foreach (Product product in this._products)
            {
                if (spec.IsSatisfiedBy(product))
                    foundProducts.Add(product);
            }

            return foundProducts;
        }
        
        // many-object method
        public List<Product> SelectBy(List<Specification> specs)
        {
            List<Product> foundProducts = new List<Product>();

            foreach (Product product in this._products)
            {
                Boolean satisfiesAllSpecs = true;

                foreach (Specification productSpec in specs)
                {
                    satisfiesAllSpecs = satisfiesAllSpecs & productSpec.IsSatisfiedBy(product);
                }

                if (satisfiesAllSpecs)
                    foundProducts.Add(product);
            }

            return foundProducts;
        }
    }
}
