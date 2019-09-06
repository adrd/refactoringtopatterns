using System;

namespace UnifyInterfacesWithAdapter.MyWork.Adapter
{
    // IElement = adaptee
    public class ElementAdapter : IXMLNode
    {
        public ElementAdapter(IElement element, Document document)
        {
            this.GetElement = element;
            this.GetDocument = document;
        }

        public IElement GetElement { get; }

        public Document GetDocument { get; }

        public void AddAttribute(String name, String value)
        {
            this.GetElement.SetAttribute(name, value);
        }

        public void Add(IXMLNode childNode)
        {
            ElementAdapter childElement = (ElementAdapter)childNode;

            this.GetElement.AppendChild(childElement.GetElement);

            DOMBuilder domBuilder = new DOMBuilder();
        }

        public void AddValue(String value)
        {
            this.GetElement.AppendChild(this.GetDocument.CreateTextNode(value));
        }
    }
}