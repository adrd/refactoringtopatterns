using System;

namespace UnifyInterfacesWithAdapter.MyWork.Adapter
{
    public class XMLBuilder : AbstractBuilder
    {
        protected override IXMLNode CreateNode(String name)
        {
            return new TagNode(name);
        }
    }
}