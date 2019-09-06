using System;
using System.Collections.Generic;

namespace UnifyInterfacesWithAdapter.MyWork.Adapter
{
    public class TagNode : IXMLNode
    {
        private IList<IXMLNode> children = new List<IXMLNode>();

        public TagNode(String tagName)
        {
            throw new NotImplementedException();
        }

        public IXMLNode GetParent()
        {
            throw new NotImplementedException();
        }

        public void Add(IXMLNode childNode)
        {
            this.children.Add(childNode);
        }

        public void AddAttribute(String name, String value)
        {
            throw new NotImplementedException();
        }

        public void AddValue(String value)
        {
            throw new NotImplementedException();
        }
    }
}