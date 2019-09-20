using MoveAccumulationToVisitor.MyWork.Node;

namespace MoveAccumulationToVisitor.MyWork.Visitor
{
    public interface INodeVisitor
    {
        void VisitStringNode(StringNode stringNode);
        void VisitLinkTag(LinkTag link);
        void VisitEndTag(EndTag endTag);
        void VisitTag(Tag tag);
    }
}