using System;

namespace IntroduceNullObject.MyWork
{
    public class NavigationApplet : Applet
    {
        private MouseEventHandler _mouseEventHandler = new NullMouseEventHandler();
        private GraphicsContext _graphicsContext;

        public Boolean MouseMove(Event @event, Int32 x, Int32 y)
        {
            return this._mouseEventHandler.MouseMove(this._graphicsContext, @event, x, y);
        }

        public Boolean MouseDown(Event @event, Int32 x, Int32 y)
        {
            return this._mouseEventHandler.MouseDown(this._graphicsContext, @event, x, y);
        }

        public Boolean MouseUp(Event @event, Int32 x, Int32 y)
        {
            return this._mouseEventHandler.MouseUp(this._graphicsContext, @event, x, y);
        }

        public Boolean MouseExit(Event @event, Int32 x, Int32 y)
        {
            return this._mouseEventHandler.MouseExit(this._graphicsContext, @event, x, y);
        }
    }
}