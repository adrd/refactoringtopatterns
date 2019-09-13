using System;

namespace ReplaceImplicitLanguageWithInterpreter.MyWork.Specifications
{
    public class ColorSpecification : Specification
    {
        private readonly ProductColor _colorOfProductToFind;

        public ColorSpecification(ProductColor colorOfProductToFind) => this._colorOfProductToFind = colorOfProductToFind;

        public override Boolean IsSatisfiedBy(Product product) => product.GetColor() == this._colorOfProductToFind;
    }
}