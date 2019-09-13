using System;

namespace ReplaceImplicitLanguageWithInterpreter.MyWork.Specifications
{
    public class PriceSpecification : Specification
    {
        private readonly Decimal _priceOfProductToFind;

        public PriceSpecification(Decimal priceOfProductToFind) => this._priceOfProductToFind = priceOfProductToFind;

        public override Boolean IsSatisfiedBy(Product product) => product.GetPrice() == this._priceOfProductToFind;
    }
}