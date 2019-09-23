using System;
using System.Text;

namespace ExtractParameter.InitialCode
{
    public class DecodingNode : Node
    {
        private Node _nodeDelegate;

        public DecodingNode(StringBuilder textBuilder, Int32 textBegin, Int32 textEnd) 
        {
            this._nodeDelegate = new StringNode(textBuilder, textBegin, textEnd);
        }
    }
}
