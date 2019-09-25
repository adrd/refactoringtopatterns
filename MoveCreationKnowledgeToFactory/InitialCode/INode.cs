using System;

namespace MoveCreationKnowledgeToFactory.InitialCode
{
    public interface INode
    {
        String ToPlainTextString();
        String ToHtml();
    }
}