using System;

namespace UnifyInterfacesWithAdapter.InitialCode
{
    public interface IElement
    {
        void SetAttribute(String name, String value);

        void AppendChild(IElement childNode);

    }
}