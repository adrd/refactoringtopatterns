using System;

namespace MoveCreationKnowledgeToFactory.InitialCode
{
    public class Parser
    {
        private Boolean _shouldDecodeNodes = false;

        public void SetNodeDecoding(Boolean shouldDecodeNodes) 
        {
            this._shouldDecodeNodes = shouldDecodeNodes;
        }

        public Boolean ShouldDecodeNodes()
        {
            return this._shouldDecodeNodes;
        }
    }
}