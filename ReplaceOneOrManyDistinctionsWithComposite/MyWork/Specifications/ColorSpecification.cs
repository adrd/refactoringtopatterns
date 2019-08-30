using System;

namespace ReplaceOneOrManyDistinctionsWithComposite.MyWork.Specifications
{
    public class ColorSpecification : Specification
    {
        private readonly ProductColor _productColor;

        public ColorSpecification(ProductColor productColor)
        {
            this._productColor = productColor;
        }

        public override Boolean IsSatisfiedBy(Product product)
        {
            return product.Color.Equals(this._productColor);
        }
    }
}
