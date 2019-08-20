using System;
using System.Collections.Generic;
using ReplaceConditionalDispatcherWithCommand.MyWork.Commands;

namespace ReplaceConditionalDispatcherWithCommand.MyWork
{
    // Invoker class
    public class CatalogApp
    {
        private readonly WorkshopManager _workshopManager;

        public static readonly String NEW_WORKSHOP = "NEW_WORKSHOP";
        public static readonly String ALL_WORKSHOPS = "ALL_WORKSHOPS";

        private Dictionary<String, Handler> _handlers;

        public CatalogApp(WorkshopManager workshopManager)
        {
            this._workshopManager = workshopManager;
            this.CreateHandlers();
        }

        private void CreateHandlers()
        {
            this._handlers = new Dictionary<String, Handler>();    

            this._handlers.Add(CatalogApp.NEW_WORKSHOP, new NewWorkshopHandler(this));
            this._handlers.Add(CatalogApp.ALL_WORKSHOPS, new AllWorkshopsHandler(this));
        }

        public HandlerResponse ExecuteActionAndGetResponse(String actionName, Dictionary<String, String> parameters)
        {
            Handler handler = this.LookupHandlerBy(actionName);

            return handler.Execute(parameters);
        }

        private Handler LookupHandlerBy(String actionName)
        {
            return this._handlers[actionName];
        }

        public String GetFormattedData(String toString)
        {
            throw new NotImplementedException();
        }

        public WorkshopManager GetWorkshopManager()
        {
            return this._workshopManager;
        }
    }
}