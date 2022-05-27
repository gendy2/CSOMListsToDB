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

namespace ProjectExtraFieldsApp
{
    internal static class Program
    {
        
        public static void Main(string[] args)
        {
            // Data d = new Data();
            // d.AddData();
            var ddapper = new DataDapper();
            ddapper.Insert();
            // var vals = ddapper.GetAll();
            //
            // foreach (var VARIABLE in vals)
            // {
            //     Console.WriteLine($"{VARIABLE.Title}");
            // }
            
            Console.WriteLine($"Done..");
        }
    }
}