using System;
using System.Text;
using MoveEmbellishmentToDecorator.MyWork.Decorator;

namespace MoveEmbellishmentToDecorator.MyWork
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