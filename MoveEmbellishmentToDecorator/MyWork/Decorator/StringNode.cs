using System;
using System.Text;

namespace MoveEmbellishmentToDecorator.MyWork.Decorator
{
    // Example of: Concrete Component
    public class StringNode : AbstractNode
    {
        private readonly StringBuilder _textBuilder;
        
        public StringNode(StringBuilder textBuilder, Int32 textBegin, Int32 textEnd) : base(textBegin, textEnd)
        {
            this._textBuilder = textBuilder;
        }
        
        public static INode CreateStringNode(StringBuilder textBuilder, Int32 textBegin, Int32 textEnd, Boolean shouldDecode)
        {
            if (shouldDecode)
                return new DecodingNode(new StringNode(textBuilder, textBegin, textEnd));

            return new StringNode(textBuilder, textBegin, textEnd);
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