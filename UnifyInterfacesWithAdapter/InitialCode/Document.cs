using System;

namespace UnifyInterfacesWithAdapter.InitialCode
{
    public class Document
    {
        public IElement CreateElement(String child)
        {
            throw new NotImplementedException();
        }

        public IElement CreateTextNode(String value)
        {
            throw new NotImplementedException();
        }
    }
}