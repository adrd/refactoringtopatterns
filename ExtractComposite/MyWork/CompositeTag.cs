using System;
using System.Collections.Generic;
using System.Text;

namespace ExtractComposite.MyWork
{
    public abstract class CompositeTag : Tag
    {
        protected Node[] _children;

        protected CompositeTag(Int32 tagBegin, Int32 tagEnd, String tagContents, String tagLine) :
                       base(tagBegin, tagEnd, tagContents, tagLine)
        {
        }

        protected IEnumerable<Node> Children()
        {
            throw new NotImplementedException();
        }

        public String ToPlainTextString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Node node in this.Children())
            {
                sb.Append(node.ToPlainTextString());
            }

            return sb.ToString();
        }
    }
}