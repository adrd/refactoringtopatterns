using System;

namespace MoveEmbellishmentToDecorator.MyWork.Decorator
{
    public class Tag : AbstractNode
    {
        public Tag(Int32 textBegin, Int32 textEnd) : base(textBegin, textEnd)
        {
        }

        public override String ToPlainTextString()
        {
            throw new NotImplementedException();
        }

        public override String ToHtml()
        {
            throw new NotImplementedException();
        }
    }
}