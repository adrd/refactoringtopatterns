using MoveCreationKnowledgeToFactory.MyWork.Factory;

namespace MoveCreationKnowledgeToFactory.MyWork
{
    public class Parser
    {
        private NodeFactory _nodeFactory = new NodeFactory();

        public NodeFactory GetNodeFactory() 
        {
            return this._nodeFactory;
        }

        public void SetNodeFactory(NodeFactory nodeFactory) 
        {
            this._nodeFactory = nodeFactory;
        }
    }
}