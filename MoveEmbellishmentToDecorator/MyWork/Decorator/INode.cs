using System;

namespace MoveEmbellishmentToDecorator.MyWork.Decorator
{
    // Example of: Decorator Component
    public interface INode
    {
        String ToPlainTextString();
        String ToHtml();
    }
}