using System;
using System.Text;

namespace ExtractParameter.MyWork
{
    public class DecodingNode : Node
    {
        private Node _nodeDelegate;

        public DecodingNode(Node newNodeDelegate) 
        {
            this._nodeDelegate = newNodeDelegate;
        }
    }
}
