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
            List<ProjectExtraFieldsModel> PEF = new List<ProjectExtraFieldsModel>();
            using (ClientContext ctx = new ClientContext(SharepointURL))
            {
                
                ctx.AuthenticationMode = ClientAuthenticationMode.Default;
                ctx.Credentials = new NetworkCredential(Username, PW, Domain);
                var RootWeb = ctx.Web;
                ctx.Load(RootWeb);
                ctx.ExecuteQuery();
                var list = ctx.Web.Lists.GetByTitle("ProjectExtraFields");
                ctx.Load(list);
                ctx.ExecuteQuery();
                // View view = list.Views.GetByTitle("All Items");
                // ctx.Load(view);
                // ctx.ExecuteQuery();
                CamlQuery camlQuery = new CamlQuery();
                // camlQuery.ViewXml = view.ViewQuery;
                var listItems = list.GetItems(camlQuery);
                ctx.Load(listItems);
                ctx.ExecuteQuery();
                // var items = listItems.ToList();
                foreach (var item in listItems)
                {
                    // ctx.Load(item);
                    // ctx.ExecuteQuery();
                    if (item != null)
                    {
                        PEF.Add(new ProjectExtraFieldsModel
                        {
                            Title = item["Title"].ToString() ?? "" ,
                            ProjectUID = new Guid(item["ProjectUID"].ToString()),
                            Created = DateTime.Parse(item["Created"].ToString()),
                            PlannedActivity = item["Planned_x0020_Activity"] == null ? String.Empty : item["Planned_x0020_Activity"].ToString().StripHtmlTags(),
                            ProgressActivity = item["Progress_x0020_Activity"] == null ? String.Empty : item["Progress_x0020_Activity"].ToString().StripHtmlTags()
                        });
                    }
                    
                }
                return PEF;

                // ctx.Load(listItems, 
                //     li => li.Include(
                //             i=>i["Id"],
                //             i=>i["Title"],
                //             i=>i["ProjectUID"],
                //             i=>i["Progress Activity"],
                //             i=>i["Planned Activity"],
                //             i=>i["Created"]
                //             )
                //     );

                ctx.ExecuteQuery();

                Console.ReadKey();

                // list.item
            }

        }
    }
    
}