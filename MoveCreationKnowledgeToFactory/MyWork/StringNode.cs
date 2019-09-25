using System;
using System.Text;

namespace MoveCreationKnowledgeToFactory.MyWork
{
    public class StringNode : AbstractNode
    {
        private readonly StringBuilder _textBuilder;
        
        public StringNode(StringBuilder textBuilder, Int32 textBegin, Int32 textEnd) : base(textBegin, textEnd)
        {
            this._textBuilder = textBuilder;
        }
        
        public override String ToPlainTextString()
        {
            return this._textBuilder.ToString();
        }

        public override String ToHtml()
        {
            throw new NotImplementedException();
        }
    }
}
