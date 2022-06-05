using System.Configuration;
using System.Data.Entity;
using System.Reflection;

namespace ProjectExtraFieldsApp.EF
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=Default")
        {
            
        }

        public string TargetTableName { get; } = ConfigurationManager.AppSettings["TableName"];
        public DbSet<ProjectProgressUpdateModel> ProjectProgressUpdate { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // bypass entity framework metadata check, no need for migration
            Database.SetInitializer<DataContext>(null);
            
            //Map entity to table
            modelBuilder.Entity<ProjectProgressUpdateModel>().ToTable(TargetTableName);
            // Map Columns
            modelBuilder.Entity<ProjectProgressUpdateModel>().Property(p => p.PlannedActivity)
                .HasColumnName("Planned_Activity").IsOptional();
            modelBuilder.Entity<ProjectProgressUpdateModel>().Property(p => p.ProgressActivity)
                .HasColumnName("Progress_Activity").IsOptional();

        }
    }
}