using System;

namespace ReplaceImplicitLanguageWithInterpreter.MyWork.Specifications
{
    public abstract class Specification
    {
        public abstract Boolean IsSatisfiedBy(Product product);
    }
}