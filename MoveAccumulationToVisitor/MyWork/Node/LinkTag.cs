using System;
using MoveAccumulationToVisitor.MyWork.Visitor;

namespace MoveAccumulationToVisitor.MyWork.Node
{
    public class LinkTag : Node
    {
        public override void Accept(INodeVisitor nodeVisitor)
        {
            nodeVisitor.VisitLinkTag(this);
        }

        public Char GetLinkText()
        {
            throw new NotImplementedException();
        }

        public Char GetLink()
        {
            throw new NotImplementedException();
        }
    }
}