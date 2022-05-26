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
            Data d = new Data();
            d.AddData();
            Console.WriteLine($"Done..");
        }
    }
}