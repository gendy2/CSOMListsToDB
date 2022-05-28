using System.Data.Entity;
using System.Reflection;

namespace ProjectExtraFieldsApp.EF
{
    public class DataEF : DbContext
    {
        public DataEF() : base("name=Default")
        {
            
        }
        public DbSet<ProjectExtraFieldsModel> Projects { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // bypass entity framework metadata check, no need for migration
            Database.SetInitializer<DataEF>(null);
            
            //Map entity to table
            modelBuilder.Entity<ProjectExtraFieldsModel>().ToTable("ProjectExtraFields");
            // Map Columns
            modelBuilder.Entity<ProjectExtraFieldsModel>().Property(p => p.PlannedActivity)
                .HasColumnName("Planned_Activity").IsOptional();
            modelBuilder.Entity<ProjectExtraFieldsModel>().Property(p => p.ProgressActivity)
                .HasColumnName("Progress_Activity").IsOptional();

        }
    }
}