using System;
using System.Collections.Generic;

namespace UnifyInterfacesWithAdapter.MyWork.Adapter
{
    public class DOMBuilder : AbstractBuilder
    {
        public static readonly String CANNOT_ADD_BESIDE_ROOT = "Cannot add beside root";

        private Document _document;
        private readonly Stack<IXMLNode> _history = new Stack<IXMLNode>();

        protected override IXMLNode CreateNode(String name)
        {
            return new ElementAdapter(this._document.CreateElement(name), this._document);
        }

        public override void AddChild(String childTagName)
        {
            base.AddChild(childTagName);
            
            this._history.Push(this._currentNode);
        }

        public override void AddSibling(String sibling)
        {
            if (this._currentNode == this._rootNode)
                throw new RuntimeException(CANNOT_ADD_BESIDE_ROOT);

            base.AddSibling(sibling);

            this._history.Pop();
            this._history.Push(this._currentNode);
        }
    }
}