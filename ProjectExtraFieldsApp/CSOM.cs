using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.SharePoint.Client;
using System.Configuration;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Security;

namespace ProjectExtraFieldsApp
{
    public class CSOM
    {
        string SharepointURL = ConfigurationManager.AppSettings["SharepointURL"];
        string Username = ConfigurationManager.AppSettings["Username"];
        string PW = ConfigurationManager.AppSettings["Password"];
        string Domain = ConfigurationManager.AppSettings["Domain"];

        
        public List<ProjectExtraFieldsModel> FetchData()
        {
            
            using (ClientContext ctx = new ClientContext(SharepointURL))
            {
                List<ProjectExtraFieldsModel> PEF = new List<ProjectExtraFieldsModel>();    
                ctx.AuthenticationMode = ClientAuthenticationMode.Default;
                ctx.Credentials = new NetworkCredential(Username, PW, Domain);
                var RootWeb = ctx.Web;
                var list = RootWeb.Lists.GetByTitle("ProjectExtraFields");
                CamlQuery camlQuery = new CamlQuery();
                var listItems = list.GetItems(camlQuery);
                ctx.Load(listItems);
                // var filteredQuery =  ctx.LoadQuery(listItems).Where(li=>li["ProjectUID"].ToString() == "1025706c-08af-ea11-bb6a-000d3a609328");
                ctx.ExecuteQuery();
                
                foreach (var item in listItems)
                {

                    if (item != null)
                    {
                        PEF.Add(new ProjectExtraFieldsModel
                        {
                            Title = item["Title"] == null ? string.Empty : item["Title"].ToString() ,
                            ProjectUID = new Guid(item["ProjectUID"].ToString()),
                            Created = DateTime.Parse(item["Created"].ToString()),
                            Planned_Activity = item["Planned_x0020_Activity"] == null ? String.Empty : item["Planned_x0020_Activity"].ToString().StripHtmlTags(),
                            Progress_Activity = item["Progress_x0020_Activity"] == null ? String.Empty : item["Progress_x0020_Activity"].ToString().StripHtmlTags()
                        });
                    }
                    
                }
                return PEF;

            }

        }
    }
    
}