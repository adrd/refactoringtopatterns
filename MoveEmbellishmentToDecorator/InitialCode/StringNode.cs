using System;
using System.Text;

namespace MoveEmbellishmentToDecorator.InitialCode
{
    public class StringNode : AbstractNode
    {
        private readonly StringBuilder _textBuilder;
        private readonly Boolean _shouldDecode;
        private readonly Boolean _shouldRemoveEscapeCharacters = false;

        public StringNode(StringBuilder textBuilder, Int32 textBegin, Int32 textEnd) : base(textBegin, textEnd)
        {
            this._textBuilder = textBuilder;
        }

        public StringNode(StringBuilder textBuilder, Int32 textBegin, Int32 textEnd, Boolean shouldDecode) : this(textBuilder, textBegin, textEnd)
        {
            this._shouldDecode = shouldDecode;
        }

        public StringNode(StringBuilder textBuilder, Int32 textBegin, Int32 textEnd, Boolean shouldDecode, Boolean shouldRemoveEscapeCharacters) : this(textBuilder, textBegin, textEnd)
        {
            this._shouldDecode = shouldDecode;
            this._shouldRemoveEscapeCharacters = shouldRemoveEscapeCharacters;
        }

        public override String ToPlainTextString()
        {
            String result = this._textBuilder.ToString();
            
            if (this._shouldDecode)
                result = Translate.Decode(result);

            if (this._shouldRemoveEscapeCharacters)
                result = ParserUtils.RemoveEscapeCharacters(result);
            
            return result;
        }

        public override String ToHtml()
        {
            throw new NotImplementedException();
        }
    }
}