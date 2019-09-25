using System;

namespace MoveCreationKnowledgeToFactory.MyWork
{
    public interface INode
    {
        String ToPlainTextString();
        String ToHtml();
    }
}