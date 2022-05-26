using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SharePoint.Client;

namespace ProjectExtraFieldsApp
{
    public class Data
    {
        string DBConnection = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        CSOM csom= new CSOM(); 
        
        // public DataTable AddData<T>(List<T> ExtraFiels)
        // {
        //     var dt = new DataTable();
        //     var type = typeof(T);
        //     foreach (var item in ExtraFiels)
        //     {
        //         dt.Rows.Add(dt.NewRow());
        //     }
        //
        //     
        //     foreach (var prop in type.GetProperties())
        //     {
        //         DataColumn cl = new DataColumn(prop.Name);
        //         cl.DataType = prop.PropertyType;
        //         dt.Columns.Add(cl);
        //         
        //         // foreach (var item in ExtraFiels)
        //         // {
        //         //     DataRow dr = new DataRow()
        //         // }
        //     }
        //     
        //     SqlConnection con = new SqlConnection(DBConnection)
        //     {
        //         
        //     };
        //
        // }

        public void AddData()
        {
            var records = csom.FetchData();
            using (SqlConnection conn = new SqlConnection(DBConnection))
            {
                conn.Open();

                SqlCommand cmd =
                    new SqlCommand("truncate table ProjectExtraFields",conn);
                cmd.CommandType = CommandType.Text;
                var reader = cmd.ExecuteNonQuery();
                
                cmd.CommandText = "INSERT INTO ProjectExtraFields (Title, ProjectUID, Progress_Activity, Planned_Activity, Created) " +
                                  " VALUES ( @param2, @param3, @param4, @param5, @param6)";
                
                cmd.Connection = conn;
                cmd.Parameters.Add("@param2", DbType.String);
                cmd.Parameters.Add("@param3", DbType.Guid);
                cmd.Parameters.Add("@param4", DbType.String);
                cmd.Parameters.Add("@param5", DbType.String);
                cmd.Parameters.Add("@param6", DbType.DateTime);

                foreach (var item in records)
                {
                    cmd.Parameters[0].Value = item.Title;
                    cmd.Parameters[1].Value = item.ProjectUID;
                    cmd.Parameters[2].Value = item.ProgressActivity;
                    cmd.Parameters[3].Value = item.PlannedActivity;
                    cmd.Parameters[4].Value = item.Created;

                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }
    }
}