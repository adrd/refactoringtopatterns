using System;
using System.Collections.Generic;
using System.Text;

namespace ReplaceConditionalDispatcherWithCommand.Initial_Code
{
    public class CatalogApp
    {
        public static readonly String NEW_WORKSHOP = "NEW_WORKSHOP";
        public static readonly String ALL_WORKSHOPS = "ALL_WORKSHOPS";
        public static readonly String ALL_WORKSHOPS_STYLESHEET = "ALL_WORKSHOPS_STYLESHEET";

        private HandlerResponse ExecuteActionAndGetResponse(String actionName, Dictionary<String, String> parameters)
        {
            WorkshopManager workshopManager = new WorkshopManager();

            if (actionName.Equals(NEW_WORKSHOP))
            {
                String nextWorkshopID = workshopManager.GetNextWorkshopID();

                StringBuilder newWorkshopContents =
                    workshopManager.CreateNewFileFromTemplate(
                        nextWorkshopID,
                        workshopManager.GetWorkshopDir(),
                        workshopManager.GetWorkshopTemplate()
                    );

                workshopManager.AddWorkshop(newWorkshopContents);
                parameters.Add("id", nextWorkshopID);

                this.ExecuteActionAndGetResponse(ALL_WORKSHOPS, parameters);
            }
            else if (actionName.Equals(ALL_WORKSHOPS))
            {
                XMLBuilder allWorkshopsXml = new XMLBuilder("workshops");
                WorkshopRepository repository = workshopManager.GetWorkshopRepository();

                List<String> ids = repository.GetIds();

                foreach (String id in ids)
                {
                    //String id = (String)ids.next();
                    Workshop workshop = repository.GetWorkshop(id);

                    allWorkshopsXml.AddBelowParent("workshop");
                    allWorkshopsXml.AddAttribute("id", workshop.GetID());
                    allWorkshopsXml.AddAttribute("name", workshop.GetName());
                    allWorkshopsXml.AddAttribute("status", workshop.GetStatus());
                    allWorkshopsXml.AddAttribute("duration", workshop.GetDurationAsString());
                }

                String formattedXml = this.GetFormattedData(allWorkshopsXml.ToString());

                return new HandlerResponse(new StringBuilder(formattedXml), ALL_WORKSHOPS_STYLESHEET);
            }

            return new HandlerResponse();
        }

        private String GetFormattedData(String toString)
        {
            throw new NotImplementedException();
        }
    }
}


