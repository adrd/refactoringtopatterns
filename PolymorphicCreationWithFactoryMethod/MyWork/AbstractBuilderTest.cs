using System;

namespace PolymorphicCreationWithFactoryMethod.MyWork
{
    public abstract class AbstractBuilderTest : TestCase
    {
        public OutputBuilder Builder { get; private set; }

        // Factory Method
        protected abstract OutputBuilder CreateBuilder(String rootName);

        // Template Method
        public void TestAddAboveRoot()
        {
            String invalidResult =
                "<orders>" +
                "<order>" +
                "</order>" +
                "</orders>" +
                "<customer>" +
                "</customer>";

            this.Builder = this.CreateBuilder("orders");

            this.Builder.AddBelow("order");

            try
            {
                this.Builder.AddAbove("customer");
                this.Fail("expecting RuntimeException");
            }
            catch (RuntimeException ignored)
            {

            }
        }

        private void Fail(String failureMessage)
        {

        }
    }
}