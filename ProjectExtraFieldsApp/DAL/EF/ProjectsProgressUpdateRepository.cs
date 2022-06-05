using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace ProjectExtraFieldsApp.EF
{
    public class ProjectsProgressUpdateRepository
    {
        public string TargetTableName { get; } = ConfigurationManager.AppSettings["TableName"];
        private DataContext DataContext { get; set; } = new DataContext();
        private CSOM _csom { get; set; } = new CSOM();

        public List<ProjectProgressUpdateModel> Insert()
        {
            var result = _csom.FetchData();

            DataContext.ProjectProgressUpdate.RemoveRange(DataContext.ProjectProgressUpdate);
            DataContext.Database.ExecuteSqlCommand($"DBCC CHECKIDENT ('{TargetTableName}', RESEED, 0)");
            foreach (var item in result)
            {
                
                DataContext.ProjectProgressUpdate.Add(item);
                
            }
            DataContext.SaveChanges();
            return DataContext.ProjectProgressUpdate.ToList();

        }

    }
}