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

        public void AddData()
        {
            var records = csom.FetchData();
            using (SqlConnection conn = new SqlConnection(DBConnection))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[ProjectExtraFields]') AND type in (N'U'))
  CREATE TABLE [dbo].[ProjectExtraFields](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NULL,
	[ProjectUID] [uniqueidentifier] NOT NULL,
	[Progress_Activity] [nvarchar](max) NULL,
	[Planned_Activity] [nvarchar](max) NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_ProjectExtraFields] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]",conn);
                    // new SqlCommand("truncate table ProjectExtraFields",conn);
                cmd.CommandType = CommandType.Text;
                // var reader = 
                cmd.ExecuteNonQuery();
                cmd.CommandText = "truncate table ProjectExtraFields";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO ProjectExtraFields (Title, ProjectUID, Progress_Activity, Planned_Activity, Created) " +
                                  " VALUES ( @param2, @param3, @param4, @param5, @param6)";
                
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