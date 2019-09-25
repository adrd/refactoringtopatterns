using System;

namespace MoveCreationKnowledgeToFactory.MyWork
{
    public class DecodingNode : INode
    {
        private readonly INode _delegateNode;

        public DecodingNode(INode delegateNode)
        {
            this._delegateNode = delegateNode;
        }

        public String ToPlainTextString()
        {
            return Translate.Decode(this._delegateNode.ToPlainTextString());
        }

        public String ToHtml()
        {
            return this._delegateNode.ToHtml();
        }
    }
}