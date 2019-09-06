using System;

namespace UnifyInterfacesWithAdapter.MyWork.Adapter
{
    public abstract class AbstractBuilder : IOutputBuilder
    {
        protected IXMLNode _rootNode;
        protected IXMLNode _currentNode;
        protected IXMLNode _parentNode;

        // Example: Introduce Polymorphic Creation with Factory Method
        protected abstract IXMLNode CreateNode(String name);

        // Example: Form Template Method 
        public virtual void AddChild(String childTagName)
        {
            IXMLNode childNode = this.CreateNode(childTagName);

            this._currentNode.Add(childNode);

            this._parentNode = this._currentNode;
            this._currentNode = childNode;
        }

        // Example: Form Template Method
        public virtual void AddSibling(String siblingTagName)
        {
            IXMLNode siblingNode = this.CreateNode(siblingTagName);

            this._currentNode.Add(siblingNode);

            this._currentNode = siblingNode;
        }

        public void AddAttribute(String name, String value)
        {
            this._currentNode.AddAttribute(name, value);
        }

        public void AddValue(String value)
        {
            this._currentNode.AddValue(value);
        }
    }
}
