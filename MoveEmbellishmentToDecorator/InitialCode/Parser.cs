using System;

namespace MoveEmbellishmentToDecorator.InitialCode
{
    public class Parser
    {
        private Boolean _shouldDecodeNodes = false;
        private String _stringContent;

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