using System;

namespace ReplaceOneOrManyDistinctionsWithComposite.MyWork.Specifications
{
    public class BelowPriceSpecification : Specification
    {
        private readonly Decimal _price;

        public BelowPriceSpecification(Decimal price)
        {
            this._price = price;
        }

        public override Boolean IsSatisfiedBy(Product product)
        {
            return product.Price < this._price;
        }
    }
}