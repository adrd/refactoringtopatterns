using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ReplaceOneOrManyDistinctionsWithComposite.MyWork.Specifications
{
    public class CompositeSpecification : Specification
    {
        private readonly List<Specification> _specifications = new List<Specification>();

        public CompositeSpecification()
        {
            
        }

        public ReadOnlyCollection<Specification> Specifications => new ReadOnlyCollection<Specification>(this._specifications);

        public override Boolean IsSatisfiedBy(Product product)
        {
            Boolean satisfiesAllSpecs = true;

            foreach (Specification productSpec in this.Specifications)
            {
                satisfiesAllSpecs = satisfiesAllSpecs & productSpec.IsSatisfiedBy(product);
            }

            return satisfiesAllSpecs;
        }

        public void Add(Specification specification) => this._specifications.Add(specification);
    }
}