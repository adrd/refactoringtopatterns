using System;

namespace ReplaceImplicitLanguageWithInterpreter.MyWork.Specifications
{
    public class BelowPriceSpecification : Specification
    {
        private readonly Decimal _priceThreshold;

        public BelowPriceSpecification(Decimal priceThreshold) => this._priceThreshold = priceThreshold;

        public override Boolean IsSatisfiedBy(Product product) => product.GetPrice() < this._priceThreshold;
    }
}