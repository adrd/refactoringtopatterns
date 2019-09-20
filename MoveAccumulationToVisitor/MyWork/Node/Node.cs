using System;
using MoveAccumulationToVisitor.MyWork.Visitor;

namespace MoveAccumulationToVisitor.MyWork.Node
{
    public class Node : AbstractNode
    {
        public override void Accept(INodeVisitor nodeVisitor)
        {
            
        }

        public String GetTagName()
        {
            throw new NotImplementedException();
        }
    }
}