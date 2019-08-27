using System;
using System.Collections.Generic;
using System.Text;

namespace ExtractComposite.MyWork
{
    public class FormTag : CompositeTag
    {
        public FormTag(Int32 tagBegin, Int32 tagEnd, String tagContents, String tagLine) : base(tagBegin, tagEnd, tagContents, tagLine)
        {
        }
    }
}