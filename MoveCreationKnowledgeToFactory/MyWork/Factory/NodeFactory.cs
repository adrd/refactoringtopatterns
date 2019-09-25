using System;
using System.Text;

namespace MoveCreationKnowledgeToFactory.MyWork.Factory
{
    public class NodeFactory
    {
        private Boolean _decodeStringNodes = false;

        public Boolean ShouldDecodeStringNodes() 
        {
            return this._decodeStringNodes;
        }

        public void SetDecodeStringNodes(Boolean decodeStringNodes) 
        {
            this._decodeStringNodes = decodeStringNodes;
        }

        public INode CreateStringNode(StringBuilder textBuilder, Int32 textBegin, Int32 textEnd) 
        {
            if (this._decodeStringNodes)
                return new DecodingNode(new StringNode(textBuilder, textBegin, textEnd));

            return new StringNode(textBuilder, textBegin, textEnd);
        }
    }
}