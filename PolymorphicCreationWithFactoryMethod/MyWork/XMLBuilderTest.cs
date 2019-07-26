using System;

namespace PolymorphicCreationWithFactoryMethod.MyWork
{
    public class XMLBuilderTest: AbstractBuilderTest
    {
        protected override OutputBuilder CreateBuilder(String rootName)
        {
            return new XMLBuilder(rootName);
        }

    }
}