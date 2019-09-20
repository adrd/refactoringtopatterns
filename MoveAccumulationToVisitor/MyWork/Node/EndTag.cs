using MoveAccumulationToVisitor.MyWork.Visitor;

namespace MoveAccumulationToVisitor.MyWork.Node
{
    public class EndTag : Tag
    {
        public override void Accept(INodeVisitor nodeVisitor)
        {
            nodeVisitor.VisitEndTag(this);
        }
    }
}