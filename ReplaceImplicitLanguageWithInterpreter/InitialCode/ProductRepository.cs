using System.Collections.Generic;

namespace ReplaceImplicitLanguageWithInterpreter.InitialCode
{
    public class ProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public void Add(Product product)
        {
            this._products.Add(product);
        }

        public IEnumerable<Product> Products => this._products;
    }
}