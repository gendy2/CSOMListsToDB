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
using Dapper.FluentMap;
using ProjectExtraFieldsApp.EF;
using ProjectExtraFieldsApp.FluentMap;

namespace ProjectExtraFieldsApp
{
    internal static class Program
    {
        
        public static void Main(string[] args)
        {
            
            #region Dapper
            // FluentMapper.Initialize(config =>
            // {
            //     config.AddMap(new ExtraFieldsMap());
            // });


            

            // Data d = new Data();
            // d.AddData();
            // var ddapper = new DataDapper();
            // ddapper.Insert();
            // var vals = ddapper.GetAll();
            //
            // foreach (var VARIABLE in vals)
            // {
            //     Console.WriteLine($"{VARIABLE.Title}");
            // }
            

            #endregion

            #region EFCore


            DataAccessEF dataAccessEf = new DataAccessEF();
            
            var result = dataAccessEf.Insert();

            // foreach (var item in result)
            // {
            //     Console.WriteLine($"ProjectUID : {item.ProjectUID}");
            // }

            #endregion
            Console.WriteLine($"Done..");
        }
    }
}