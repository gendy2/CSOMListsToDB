using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.SharePoint.Client;
using System.Configuration;
using System.Collections.Specialized;
using System.Net;
using System.Security;
using System.Text.RegularExpressions;
using ProjectExtraFieldsApp.EF;

namespace ProjectExtraFieldsApp
{
    internal static class Program
    {
        
        public static void Main(string[] args)
        {
            
            #region EFCore
            
            ProjectsProgressUpdateRepository projectsProgressUpdateRepository = new ProjectsProgressUpdateRepository();
            var result = projectsProgressUpdateRepository.Insert();

            #endregion
            Console.WriteLine($"Done..");
            Console.ReadKey();
        }
    }
}