using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace ProjectExtraFieldsApp
{
    public class DataDapper
    {
        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
        private CSOM csom = new CSOM();

        public List<ProjectExtraFieldsModel> GetAll()
        {
            var result =  conn.Query<ProjectExtraFieldsModel>("select * from ProjectExtraFields").ToList();
            return result;
        }
        
        public ProjectExtraFieldsModel GetSingle(string projectuid)
        {
            var sql = "select * from ProjectExtraFields where projectuid = @projectuid";
            var result =  
                conn.Query<ProjectExtraFieldsModel>(sql, new { @projectuid = projectuid}).Single();
            return result;
        }
        
        public void Insert()
        {
            var vals = csom.FetchData();
            var sql1 = @"IF  NOT EXISTS (SELECT * FROM sys.objects 
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
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]";
            var sql2 = @"truncate table ProjectExtraFields";
            var sql3 = "INSERT INTO ProjectExtraFields (Title, ProjectUID, Progress_Activity, Planned_Activity, Created) VALUES ( @param0, @param1, @param2, @param3, @param4)";
            conn.Query(sql1);
            conn.Query(sql2);

            foreach (var item in vals)
            {
                conn.Query(sql3, new
                {
                    @param0 = item.Title,
                    @param1 = item.ProjectUID,
                    @param2 =  item.Progress_Activity,
                    @param3 = item.Planned_Activity,
                    @param4 =  item.Created
                });
            }
            // return result;
        }
    }
}