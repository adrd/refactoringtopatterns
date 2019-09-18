using System;
using System.Collections.Generic;
using System.Text;

namespace MoveAccumulationToCollectingParameter.InitialCode
{
    public class TagNode
    {
        private readonly String _name;
        private String _value;
        private readonly StringBuilder _attributes;
        private readonly List<TagNode> _children;

        public TagNode(String name)
        {
            this._name = name;
            this._value = String.Empty;
            this._attributes = new StringBuilder();
            this._children = new List<TagNode>();
        }

        public void AddAttribute(String attribute, String value)
        {
            this._attributes.Append(" ");

            this._attributes.Append(attribute);
            this._attributes.Append("=");
            this._attributes.Append("'");
            this._attributes.Append(value);
            this._attributes.Append("'");

        }

        public void AddValue(String value)
        {
            this._value = value;
        }

        public void Add(TagNode childNode)
        {
            this._children.Add(childNode);
        }

        // Steps to refactor:
        // 1. Instantiate a result
        // 2. Pass a result to the first of many methods
        // 3. Obtain a result’s collected information.
        public override String ToString()
        {
            String result;

            result = "<" + this._name + this._attributes + ">";

            foreach (TagNode childNode in this._children)
            {
                result = result + childNode.ToString();
            }

            result = result + this._value;
            result = result + "</" + this._name + ">";

            return result;
        }
    }
}
