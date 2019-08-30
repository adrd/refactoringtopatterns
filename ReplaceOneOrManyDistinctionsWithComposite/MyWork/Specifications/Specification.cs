using System;

namespace ReplaceOneOrManyDistinctionsWithComposite.MyWork.Specifications
{
    public abstract class Specification
    {
        public abstract Boolean IsSatisfiedBy(Product product);
    }
}