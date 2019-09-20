using System;
using System.Collections;
using System.Text;

namespace MoveAccumulationToVisitor.InitialCode
{
    public class TextExtractor
    {
        private Parser _parser;

        // Example of: external accumulation method
        public String ExtractText()
        {
            Node node;
            Boolean isPreTag = false;
            Boolean isScriptTag = false;
            StringBuilder results = new StringBuilder();

            this._parser.FlushScanners();
            this._parser.RegisterScanners();

            foreach (Node element in this._parser.Elements())
            {
                node = element;
                if (node is StringNode) {
                    
                    if (!isScriptTag) {
                        StringNode stringNode = (StringNode) node;

                        if (isPreTag)
                            results.Append(stringNode.GetText());
                        else {
                            String text = Translate.Decode(stringNode.GetText());

                            if (this.GetReplaceNonBreakingSpace())
                                text = text.Replace('\a', ' ');
                            if (this.GetCollapse())
                                this.Collapse(results, text);
                            else
                                results.Append(text);
                        }
                    }

                } else if (node is LinkTag) {
                    LinkTag link = (LinkTag) node;

                    if (isPreTag)
                        results.Append(link.GetLinkText());
                    else
                        this.Collapse(results, Translate.Decode(link.GetLinkText()));

                    if (this.GetLinks()) {
                        results.Append("<");
                        results.Append(link.GetLink());
                        results.Append(">");
                    }

                } else if (node is EndTag) {
                    EndTag endTag = (EndTag) node;
                    
                    String tagName = endTag.GetTagName();

                    if (tagName.EqualsIgnoreCase("PRE"))
                        isPreTag = false;
                    else if (tagName.EqualsIgnoreCase("SCRIPT"))
                        isScriptTag = false;

                } else if (node is Tag) {
                    Tag tag = (Tag) node;
                    
                    String tagName = tag.GetTagName();
                    
                    if (tagName.EqualsIgnoreCase("PRE"))
                        isPreTag = true;
                    else if (tagName.EqualsIgnoreCase("SCRIPT"))
                        isScriptTag = true;
                }
            }

            return results.ToString();
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
