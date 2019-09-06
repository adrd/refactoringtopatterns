using System;

namespace UnifyInterfacesWithAdapter.MyWork.Adapter
{
    public interface IXMLNode
    {
        void Add(IXMLNode currentNode);
        void AddAttribute(String name, String value);
        void AddValue(String value);
    }
}