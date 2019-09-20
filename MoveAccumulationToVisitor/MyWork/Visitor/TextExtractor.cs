using System;
using System.Text;
using MoveAccumulationToVisitor.MyWork.Node;

namespace MoveAccumulationToVisitor.MyWork.Visitor
{
    public class TextExtractor : INodeVisitor
    {
        private Parser _parser;
        private Boolean _isPreTag;
        private Boolean _isScriptTag;
        private StringBuilder _results;

        // Example of: external accumulation method
        public String ExtractText()
        {
            this._isPreTag = false;
            this._isScriptTag = false;
            this._results = new StringBuilder();

            this._parser.FlushScanners();
            this._parser.RegisterScanners();

            foreach (INode node in this._parser.Elements())
            {
                node.Accept(this);
            }

            return this._results.ToString();
        }

        public void VisitStringNode(StringNode stringNode)
        {
            if (!this._isScriptTag)
            {
                if (this._isPreTag)
                    this._results.Append(stringNode.GetText());
                else
                {
                    String text = Translate.Decode(stringNode.GetText());

                    if (this.GetReplaceNonBreakingSpace())
                        text = text.Replace('\a', ' ');
                    if (this.GetCollapse())
                        this.Collapse(this._results, text);
                    else
                        this._results.Append(text);
                }
            }
        }

        public void VisitLinkTag(LinkTag link)
        {
            if (this._isPreTag)
                this._results.Append(link.GetLinkText());
            else
                this.Collapse(this._results, Translate.Decode(link.GetLinkText()));

            if (this.GetLinks())
            {
                this._results.Append("<");
                this._results.Append(link.GetLink());
                this._results.Append(">");
            }
        }

        public void VisitEndTag(EndTag endTag)
        {
            String tagName = endTag.GetTagName();

            if (tagName.EqualsIgnoreCase("PRE"))
                this._isPreTag = false;
            else if (tagName.EqualsIgnoreCase("SCRIPT"))
                this._isScriptTag = false;
        }

        public void VisitTag(Tag tag)
        {
            String tagName = tag.GetTagName();

            if (tagName.EqualsIgnoreCase("PRE"))
                this._isPreTag = true;
            else if (tagName.EqualsIgnoreCase("SCRIPT"))
                this._isScriptTag = true;
        }

        private Boolean GetLinks()
        {
            throw new NotImplementedException();
        }

        private void Collapse(StringBuilder results, String text)
        {
            throw new NotImplementedException();
        }

        private Boolean GetCollapse()
        {
            throw new NotImplementedException();
        }

        private Boolean GetReplaceNonBreakingSpace()
        {
            throw new NotImplementedException();
        }
    }
}
