using System;

namespace IntroduceNullObject.MyWork
{
    public sealed class NullMouseEventHandler : MouseEventHandler
    {
        public override Boolean MouseMove(GraphicsContext graphicsContext, Event @event, Int32 x, Int32 y)
        {
            return true;
        }

        public override Boolean MouseDown(GraphicsContext graphicsContext, Event @event, Int32 x, Int32 y)
        {
            return true;
        }

        public override Boolean MouseUp(GraphicsContext graphicsContext, Event @event, Int32 x, Int32 y)
        {
            return true;
        }

        public override Boolean MouseExit(GraphicsContext graphicsContext, Event @event, Int32 x, Int32 y)
        {
            return true;
        }
    }
}