using MoveAccumulationToVisitor.MyWork.Visitor;

namespace MoveAccumulationToVisitor.MyWork.Node
{
    public abstract class AbstractNode : INode
    {
        public abstract void Accept(INodeVisitor textExtractor);
    }
}