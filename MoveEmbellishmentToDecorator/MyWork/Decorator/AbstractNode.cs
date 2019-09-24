﻿using System;

namespace MoveEmbellishmentToDecorator.MyWork.Decorator
{
    public abstract class AbstractNode : INode
    {
        protected Int32 nodeBegin;
        protected Int32 nodeEnd;

        protected AbstractNode(Int32 nodeBegin, Int32 nodeEnd)
        {
            this.nodeBegin = nodeBegin;
            this.nodeEnd = nodeEnd;
        }

        public abstract String ToPlainTextString();

        public abstract String ToHtml();

        public void Accept(NodeVisitor visitor)
        {
        }

        public Int32 ElementBegin()
        {
            throw new NotImplementedException();
        }

        public Int32 ElementEnd()
        {
            throw new NotImplementedException();
        }
    }
}
