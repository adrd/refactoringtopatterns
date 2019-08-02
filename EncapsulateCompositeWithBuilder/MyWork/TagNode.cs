using System;
using System.Collections.Generic;
using System.Text;

namespace EncapsulateCompositeWithBuilder.MyWork
{
    public class TagNode
    {
        private readonly String _name;
        private readonly StringBuilder _attributes;
        private String _value;
        private readonly IList<TagNode> _children;
        private TagNode _parentNode;

        public TagNode(String name)
        {
            this._name = name;
            this._attributes = new StringBuilder();
            this._value = String.Empty;
            this._children = new List<TagNode>();
            this._parentNode = null;
        }

        public TagNode ParentNode
        {
            get => this._parentNode;
            private set => this._parentNode = value;
        }

        public String Name => this._name;

        public void Add(TagNode childNode)
        {
            childNode.ParentNode = this;       // child node takes current node as parent 
            this._children.Add(childNode);     // parent node adds child node to children collection
        }

        public void AddAttribute(String attribute, String value)
        {
            this._attributes.Append(" ");
            this._attributes.Append(attribute);
            this._attributes.Append("='");
            this._attributes.Append(value);
            this._attributes.Append("'");
        }

        public void AddValue(String value)
        {
            this._value = value;
        }

        public override String ToString()
        {
            String result = "<" + this._name + this._attributes + ">";

            if (this.ShouldOpenTagSelfClose())
                return result.Replace(">", "/>");

            foreach (TagNode tagNode in this._children)
            {
                result += tagNode.ToString();
            }

            result += this._value + "</" + this._name + ">";

            return result;
        }

        private Boolean ShouldOpenTagSelfClose()
        {
            return !this.HasValue() && !this.HasChildren();
        }

        private Boolean HasChildren()
        {
            return this._children.Count > 0;
        }

        private Boolean HasValue()
        {
            return !this._value.Equals(String.Empty);
        }

        public void AppendContentsTo(StringBuilder xmlResult)
        {
            this.WriteOpenTagTo(xmlResult);

            if (this.ShouldOpenTagSelfClose())
            {
                this.SelfCloseOpenTag(xmlResult);
                return;
            }

            this.WriteChildrenTo(xmlResult);

            this.WriteValueTo(xmlResult);

            this.WriteEndTagTo(xmlResult);
        }

        private void WriteOpenTagTo(StringBuilder xmlResult)
        {
            xmlResult.Append("<");
            xmlResult.Append(this._name);
            xmlResult.Append(this._attributes);
            xmlResult.Append(">");
        }

        private void SelfCloseOpenTag(StringBuilder xmlResult)
        {
            xmlResult.Remove(xmlResult.Length-1, 1).Append("/>");
        }

        private void WriteChildrenTo(StringBuilder xmlResult)
        {
            foreach (TagNode tagNode in this._children)
            {
                tagNode.AppendContentsTo(xmlResult);
            }
        }

        private void WriteValueTo(StringBuilder xmlResult)
        {
            if (this.HasValue())
                xmlResult.Append(this._value);
        }

        private void WriteEndTagTo(StringBuilder xmlResult)
        {
            xmlResult.Append("</");
            xmlResult.Append(this._name);
            xmlResult.Append(">");
        }
    }
}