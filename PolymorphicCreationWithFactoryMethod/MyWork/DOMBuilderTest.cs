using System;

namespace PolymorphicCreationWithFactoryMethod.MyWork
{
    public class DOMBuilderTest: AbstractBuilderTest
    {
        protected override OutputBuilder CreateBuilder(String rootName)
        {
            return new DOMBuilder(rootName);
        }

        
    }
}
