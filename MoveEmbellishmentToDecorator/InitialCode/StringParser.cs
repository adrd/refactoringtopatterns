using System;
using System.Text;

namespace MoveEmbellishmentToDecorator.InitialCode
{
    public class StringParser
    {
        private StringBuilder _textBuffer;
        private Int32 _textBegin;
        private Int32 _textEnd;

        public INode Find(NodeReader reader, String input, Int32 position, Boolean balanceQuotes) 
        {
            return new StringNode(this._textBuffer, this._textBegin, this._textEnd, reader.GetParser().ShouldDecodeNodes());
        }
    }
}