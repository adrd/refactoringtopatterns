using System;
using System.Text;

namespace MoveCreationKnowledgeToFactory.MyWork
{
    public class StringParser
    {
        private StringBuilder _textBuffer;
        private Int32 _textBegin;
        private Int32 _textEnd;

        public INode Find(NodeReader reader, String input, Int32 position, Boolean balanceQuotes) 
        {
            return reader.GetParser().GetNodeFactory().CreateStringNode(this._textBuffer, this._textBegin, this._textEnd);
        }
    }
}