using MoveAccumulationToVisitor.MyWork.Visitor;

namespace MoveAccumulationToVisitor.MyWork.Node
{
    public class Tag : Node
    {
        public override void Accept(INodeVisitor nodeVisitor)
        {
            nodeVisitor.VisitTag(this);
        }
    }
}