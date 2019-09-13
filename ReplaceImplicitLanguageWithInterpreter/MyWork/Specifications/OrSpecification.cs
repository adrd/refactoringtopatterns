﻿using System;

namespace ReplaceImplicitLanguageWithInterpreter.MyWork.Specifications
{
    public class OrSpecification : Specification
    {
        private readonly Specification _firstSpecification;
        private readonly Specification _secondSpecification;

        public OrSpecification(Specification firstSpecification, Specification secondSpecification)
        {
            this._firstSpecification = firstSpecification;
            this._secondSpecification = secondSpecification;
        }

        public override Boolean IsSatisfiedBy(Product product)
        {
            return this._firstSpecification.IsSatisfiedBy(product) || this._secondSpecification.IsSatisfiedBy(product);
        }
    }
}