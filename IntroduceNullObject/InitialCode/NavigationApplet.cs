using System;

namespace IntroduceNullObject.InitialCode
{
    public class NavigationApplet : Applet
    {
        private MouseEventHandler _mouseEventHandler;
        private GraphicsContext _graphicsContext;

        public Boolean MouseMove(Event @event, Int32 x, Int32 y) 
        {
            if (this._mouseEventHandler != null)
                return this._mouseEventHandler.MouseMove(this._graphicsContext, @event, x, y);

            return true;
        }

        public Boolean MouseDown(Event @event, Int32 x, Int32 y) 
        {
            if (this._mouseEventHandler != null)
                return this._mouseEventHandler.MouseDown(this._graphicsContext, @event, x, y);

            return true;
        }

        public Boolean MouseUp(Event @event, Int32 x, Int32 y) 
        {
            if (this._mouseEventHandler != null)
                return this._mouseEventHandler.MouseUp(this._graphicsContext, @event, x, y);

            return true;
        }

        public Boolean MouseExit(Event @event, Int32 x, Int32 y) 
        {
            if (this._mouseEventHandler != null)
                return this._mouseEventHandler.MouseExit(this._graphicsContext, @event, x, y);

            return true;
        }
    }
}