using System;

namespace ReplaceOneOrManyDistinctionsWithComposite.InitialCode.Specifications
{
    public class SizeSpecification : Specification
    {
        private readonly ProductSize _productSize;

        public SizeSpecification(ProductSize productSize)
        {
            this._productSize = productSize;
        }

        public override Boolean IsSatisfiedBy(Product product)
        {
            return product.Size.Equals(this._productSize);
        }
    }
}