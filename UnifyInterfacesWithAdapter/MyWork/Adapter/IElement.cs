using System;

namespace UnifyInterfacesWithAdapter.MyWork.Adapter
{
    public interface IElement
    {
        void SetAttribute(String name, String value);

        void AppendChild(IElement childNode);

    }
}