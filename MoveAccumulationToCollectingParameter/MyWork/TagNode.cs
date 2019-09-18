using System;
using System.Collections.Generic;
using System.Text;

namespace MoveAccumulationToCollectingParameter.MyWork
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

        public override String ToString()
        {
            StringBuilder result = new StringBuilder();

            this.AppendContentsTo(result);

            return result.ToString();
        }

        // Example of: Compose Method
        private void AppendContentsTo(StringBuilder result)
        {
            this.WriteOpenTagTo(result);

            this.WriteChildrenTo(result);

            this.WriteValueTo(result);

            this.WriteEndTagTo(result);
        }

        private void WriteOpenTagTo(StringBuilder result)
        {
            result.Append("<");
            result.Append(this._name);
            result.Append(" ");
            result.Append(this._attributes.ToString());
            result.Append(">");
        }

        private void WriteChildrenTo(StringBuilder result)
        {
            foreach (TagNode childNode in this._children)
            {
                childNode.AppendContentsTo(result);         // now recursive call will work
            }
        }

        private void WriteValueTo(StringBuilder result)
        {
            if (!this._value.Equals(String.Empty))
                result.Append(this._value);
        }

        private void WriteEndTagTo(StringBuilder result)
        {
            result.Append("</");
            result.Append(this._name);
            result.Append(">");
        }
    }
}
