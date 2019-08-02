using System;
using System.Text;

namespace EncapsulateCompositeWithBuilder.MyWork
{
    public class TagBuilder
    {
        private readonly TagNode _rootNode;
        private TagNode _currentNode;

        private Int32 _outputBufferSize;
        private static readonly Int32 TagCharsSize = 5;
        private static readonly Int32 AttributeCharsSize = 4;

        public TagBuilder(String rootTagName)
        {
            this._rootNode = new TagNode(rootTagName);
            this._currentNode = this._rootNode;              // leaf node

            this.IncrementBufferSizeByTagLength(rootTagName);
        }

        public String ToXml()
        {
            // return this._rootNode.ToString(); // Var 1

            StringBuilder xmlResult = new StringBuilder(this._outputBufferSize); // Var 2

            this._rootNode.AppendContentsTo(xmlResult);

            return xmlResult.ToString();
        }

        public void AddChild(String childTagName)
        {
            //TagNode parentNode = this.currentNode;

            //this.currentNode = new TagNode(childTagName);
    
            //parentNode.Add(this.currentNode);

            this.AddTo(this._currentNode, childTagName);
        }

        public void AddSibling(String siblingTagName)
        {
            this.AddTo(this._currentNode.ParentNode, siblingTagName);    
        }

        private void AddTo(TagNode parentNode, String childTagName)
        {
            this._currentNode = new TagNode(childTagName);              // current node points to new node created (child node)
            parentNode.Add(this._currentNode);                          // parent node is root node when there is only a node in tree 

            this.IncrementBufferSizeByTagLength(childTagName);
        }

        public void AddToParent(String parentTagName, String childTagName)
        {
            TagNode parentNode = this.FindParentBy(parentTagName);

            if (parentNode == null)
                throw new SystemException("missing parent tag: " + parentTagName);

            this.AddTo(parentNode, childTagName);
        }

        private TagNode FindParentBy(String parentTagName)
        {
            TagNode parentNode = this._currentNode;

            while (parentNode != null)
            {
                if (parentNode.Name.Equals(parentTagName, StringComparison.OrdinalIgnoreCase))
                    return parentNode;

                parentNode = parentNode.ParentNode;
            }

            return null;
        }

        public void AddAttribute(String name, String value)
        {
            this._currentNode.AddAttribute(name, value);

            this.IncrementBufferSizeByAttributeLength(name, value);
        }

        public void AddValue(String value)
        {
            this._currentNode.AddValue(value);

            this.IncrementBufferSizeByValueLength(value);
        }

        public Int32 BufferSize()
        {
            return this._outputBufferSize;
        }

        private void IncrementBufferSizeByTagLength(String tag) {
    
            Int32 sizeOfOpenAndCloseTags = tag.Length * 2;
    
            this._outputBufferSize += (sizeOfOpenAndCloseTags + TagCharsSize);
        }

        private void IncrementBufferSizeByAttributeLength(String name, String value) {
    
            this._outputBufferSize += (name.Length + value.Length + AttributeCharsSize);
        }

        private void IncrementBufferSizeByValueLength(String value) {
    
            this._outputBufferSize += value.Length;
        }
    }
}