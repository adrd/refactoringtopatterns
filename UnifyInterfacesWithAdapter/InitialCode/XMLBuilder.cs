using System;

namespace UnifyInterfacesWithAdapter.InitialCode
{
    public class XMLBuilder : AbstractBuilder
    {
        private TagNode _rootNode;
        private TagNode _currentNode;

        public void AddChild(String childTagName) 
        {
            this.AddTo(this._currentNode, childTagName);
        }

        public void AddSibling(String siblingTagName) 
        {
            this.AddTo(this._currentNode.GetParent(), siblingTagName);
        }

        private void AddTo(TagNode parentNode, String tagName) 
        {
            this._currentNode = new TagNode(tagName);
            parentNode.Add(this._currentNode);
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