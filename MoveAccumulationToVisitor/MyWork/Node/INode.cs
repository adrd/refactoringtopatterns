using MoveAccumulationToVisitor.MyWork.Visitor;

namespace MoveAccumulationToVisitor.MyWork.Node
{
    public interface INode
    {
        void Accept(INodeVisitor textExtractor);
    }
}