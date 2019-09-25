using System;
using System.Text;

namespace MoveCreationKnowledgeToFactory.InitialCode
{
    public class StringParser
    {
        private StringBuilder _textBuffer;
        private Int32 _textBegin;
        private Int32 _textEnd;

        public INode Find(NodeReader reader, String input, Int32 position, Boolean balanceQuotes) 
        {
            return StringNode.CreateStringNode(this._textBuffer, this._textBegin, this._textEnd, reader.GetParser().ShouldDecodeNodes());
        }
    }
}