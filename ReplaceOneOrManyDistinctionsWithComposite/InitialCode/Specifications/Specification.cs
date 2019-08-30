using System;

namespace ReplaceOneOrManyDistinctionsWithComposite.InitialCode.Specifications
{
    public abstract class Specification
    {
        public abstract Boolean IsSatisfiedBy(Product product);
    }
}