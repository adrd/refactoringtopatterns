using System;

namespace ReplaceImplicitLanguageWithInterpreter.MyWork.Specifications
{
    public class NotSpecification : Specification
    {
        private readonly Specification _specificationToNegate;

        public NotSpecification(Specification specificationToNegate)
        {
            this._specificationToNegate = specificationToNegate;
        }

        public override Boolean IsSatisfiedBy(Product product)
        {
            return !this._specificationToNegate.IsSatisfiedBy(product);
        }
    }
}