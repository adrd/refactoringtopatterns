using System;
using System.Collections.Generic;

namespace ExtractComposite.MyWork
{
    public class Tag
    {
        private Int32 _tagBegin;
        private Int32 _tagEnd;
        private String _tagContents;
        private String _tagLine;
        
        public Tag(Int32 tagBegin, Int32 tagEnd, String tagContents, String tagLine)
        {
            this._tagBegin = tagBegin;
            this._tagEnd = tagEnd;
            this._tagContents = tagContents;
            this._tagLine = tagLine;
        }
    }
}