using System;

namespace IntroduceNullObject.InitialCode
{
    public class MouseEventHandler
    {
        public virtual Boolean MouseMove(GraphicsContext graphicsContext, Event @event, Int32 x, Int32 y)
        {
            throw new NotImplementedException();
        }

        public virtual Boolean MouseDown(GraphicsContext graphicsContext, Event @event, Int32 x, Int32 y)
        {
            throw new NotImplementedException();
        }

        public virtual Boolean MouseUp(GraphicsContext graphicsContext, Event @event, Int32 x, Int32 y)
        {
            throw new NotImplementedException();
        }

        public virtual Boolean MouseExit(GraphicsContext graphicsContext, Event @event, Int32 x, Int32 y)
        {
            throw new NotImplementedException();
        }
    }
}
