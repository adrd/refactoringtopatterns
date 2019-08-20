using System;
using System.Collections.Generic;
using System.Text;

namespace ReplaceConditionalDispatcherWithCommand.MyWork.Commands
{
    public class AllWorkshopsHandler : Handler
    {
        private static readonly String ALL_WORKSHOPS_STYLESHEET = "ALL_WORKSHOPS_STYLESHEET";

        public AllWorkshopsHandler(CatalogApp catalogApp) : base(catalogApp)
        {
        }

        public override HandlerResponse Execute(Dictionary<String, String> parameters)
        {
            return new HandlerResponse(new StringBuilder(this.AllWorkshopsData()), AllWorkshopsHandler.ALL_WORKSHOPS_STYLESHEET);
        }

        private String AllWorkshopsData()
        {
            XMLBuilder allWorkshopsXml = new XMLBuilder("workshops");

            WorkshopRepository repository = this.WorkshopManager().GetWorkshopRepository();

            List<String> ids = repository.GetIds();

            foreach (String id in ids)
            {
                Workshop workshop = repository.GetWorkshop(id);

                allWorkshopsXml.AddBelowParent("workshop");
                allWorkshopsXml.AddAttribute("id", workshop.GetID());
                allWorkshopsXml.AddAttribute("name", workshop.GetName());
                allWorkshopsXml.AddAttribute("status", workshop.GetStatus());
                allWorkshopsXml.AddAttribute("duration", workshop.GetDurationAsString());
            }

            return this._catalogApp.GetFormattedData(allWorkshopsXml.ToString());
        }

        private WorkshopManager WorkshopManager()
        {
            return this._catalogApp.GetWorkshopManager();
        }
    }
}