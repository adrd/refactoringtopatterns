using System;
using MoveAccumulationToVisitor.MyWork.Visitor;

namespace MoveAccumulationToVisitor.MyWork.Node
{
    public class StringNode : Node
    {
        public override void Accept(INodeVisitor nodeVisitor)
        {
            nodeVisitor.VisitStringNode(this);
        }

        public Char GetText()
        {
            throw new NotImplementedException();
        }
    }
}