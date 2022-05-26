using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.SharePoint.Client;

namespace ProjectExtraFieldsApp
{
    public static class Helper
    {
        public static string StripHtmlTags(this string source)  
        {  
            return Regex.Replace(source, "<.*?>|&.*?;", string.Empty);  
        }

        public static void print<T>(this IEnumerable<T> enumerator)
        {
            var type = typeof(T);
            foreach (var item in enumerator)
            {
                foreach (var prop in type.GetProperties())
                {
                    Console.Write($"{prop.Name} : {item}, ");
                }
                Console.WriteLine();
            }

        }
        
        public static T GetValue<T>(this ListItem item, string fieldName) where T : class
        {
            object o = item[fieldName];
            if (o == null || !(o is T)) return null;
            return (T)o;
        }
        
        
    }
}