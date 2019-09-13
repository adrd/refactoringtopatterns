using System;
using System.Collections.Generic;

namespace ReplaceImplicitLanguageWithInterpreter.MyWork.Specifications
{
    public class CompositeSpecification : Specification
    {
        private readonly IEnumerable<Specification> _specifications;

        public CompositeSpecification(IEnumerable<Specification> specifications)
        {
            this._specifications = specifications;
        }

        public override Boolean IsSatisfiedBy(Product product)
        {
            Boolean satisfiesAllSpecs = true;

            foreach (Specification specification in this._specifications)
            {
                satisfiesAllSpecs = satisfiesAllSpecs && specification.IsSatisfiedBy(product);
            }

            return satisfiesAllSpecs;
        }
    }
}