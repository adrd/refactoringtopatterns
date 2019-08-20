using System;
using System.Collections.Generic;

namespace ReplaceConditionalDispatcherWithCommand.MyWork.Commands
{
    public abstract class Handler
    {
        protected CatalogApp _catalogApp;

        protected Handler(CatalogApp catalogApp)
        {
            this._catalogApp = catalogApp;
        }

        public abstract HandlerResponse Execute(Dictionary<String, String> parameters);
    }
}