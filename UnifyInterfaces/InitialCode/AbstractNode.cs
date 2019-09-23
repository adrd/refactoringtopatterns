using System;

namespace UnifyInterfaces.InitialCode
{
    public abstract class AbstractNode
    {
        public String ToPlainTextString()
        {
            return String.Empty;
        }

        public String ToHtml()
        {
            return String.Empty;
        }

        public Int32 ElementBegin()
        {
            return 0;
        }

        public Int32 ElementEnd()
        {
            return 1;
        }
    }
}