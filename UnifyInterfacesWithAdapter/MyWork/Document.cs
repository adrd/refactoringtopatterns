using System;
using UnifyInterfacesWithAdapter.MyWork.Adapter;

namespace UnifyInterfacesWithAdapter.MyWork
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