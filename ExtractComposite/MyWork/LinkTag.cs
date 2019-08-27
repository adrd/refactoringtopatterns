using System;

namespace ExtractComposite.MyWork
{
    public class LinkTag : CompositeTag
    {
        public LinkTag(Int32 tagBegin, Int32 tagEnd, String tagContents, String tagLine) : base(tagBegin, tagEnd, tagContents, tagLine)
        {
        }
    }
}
