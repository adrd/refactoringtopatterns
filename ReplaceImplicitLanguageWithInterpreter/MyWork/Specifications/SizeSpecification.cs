using System;

namespace ReplaceImplicitLanguageWithInterpreter.MyWork.Specifications
{
    public class SizeSpecification : Specification
    {
        private readonly ProductSize _sizeOfProductToFind;

        public SizeSpecification(ProductSize sizeOfProductToFind) => this._sizeOfProductToFind = sizeOfProductToFind;

        public override Boolean IsSatisfiedBy(Product product) => product.GetSize() == this._sizeOfProductToFind;
    }
}