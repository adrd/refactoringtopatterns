using System;
using System.Collections.Generic;

namespace UnifyInterfacesWithAdapter.InitialCode
{
    public class DOMBuilder : AbstractBuilder
    {
        public static readonly String CANNOT_ADD_BESIDE_ROOT = "Cannot add beside root";

        private Document _document;
        private IElement _root;
        private IElement _parent;
        private IElement _current;
        private Stack<IElement> _history = new Stack<IElement>();

        public void AddAttribute(String name, String value) 
        {
            this._current.SetAttribute(name, value);
        }

        public void AddBelow(String child) 
        {
            IElement childNode = this._document.CreateElement(child);
            this._current.AppendChild(childNode);
            this._parent = this._current;
            this._current = childNode;
            this._history.Push(this._current);
        }

        public void AddBeside(String sibling) 
        {
            if (this._current == this._root)
                throw new RuntimeException(CANNOT_ADD_BESIDE_ROOT);

            IElement siblingNode = this._document.CreateElement(sibling);
            this._parent.AppendChild(siblingNode);
            this._current = siblingNode;

            this._history.Pop();
            this._history.Push(this._current);
        }

        public void AddValue(String value) 
        {
            this._current.AppendChild(this._document.CreateTextNode(value));
        }
    }
}