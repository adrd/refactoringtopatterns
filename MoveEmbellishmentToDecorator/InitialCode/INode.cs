using System;

namespace MoveEmbellishmentToDecorator.InitialCode
{
    public interface INode
    {
        String ToPlainTextString();
        String ToHtml();
    }
}