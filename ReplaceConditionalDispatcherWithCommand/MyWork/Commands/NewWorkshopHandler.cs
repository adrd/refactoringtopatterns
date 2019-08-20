using System;
using System.Collections.Generic;
using System.Text;

namespace ReplaceConditionalDispatcherWithCommand.MyWork.Commands
{
    public class NewWorkshopHandler : Handler
    {
        public NewWorkshopHandler(CatalogApp catalogApp) : base(catalogApp)
        {
        }

        // Example of compose method
        public override HandlerResponse Execute(Dictionary<String, String> parameters)
        {
            this.CreateNewWorkshop(parameters);

            return this._catalogApp.ExecuteActionAndGetResponse(CatalogApp.ALL_WORKSHOPS, parameters);
        }

        private void CreateNewWorkshop(Dictionary<String, String> parameters)
        {
            String nextWorkshopID = this.WorkshopManager().GetNextWorkshopID();

            this.WorkshopManager().AddWorkshop(this.NewWorkshopContents(nextWorkshopID));

            parameters.Add("id", nextWorkshopID);
        }

        private StringBuilder NewWorkshopContents(String nextWorkshopID)
        {
            StringBuilder newWorkshopContents =
                this.WorkshopManager().CreateNewFileFromTemplate(
                    nextWorkshopID,
                    this.WorkshopManager().GetWorkshopDir(),
                    this.WorkshopManager().GetWorkshopTemplate()
                );

            return newWorkshopContents;
        }

        private WorkshopManager WorkshopManager()
        {
            return this._catalogApp.GetWorkshopManager();
        }
    }
}