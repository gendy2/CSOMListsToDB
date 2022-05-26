using System;

namespace ProjectExtraFieldsApp
{
    public class ProjectExtraFieldsModel
    {
        public string Title { get; set; }
        public Guid? ProjectUID { get; set; }
        public string ProgressActivity { get; set; }
        public string PlannedActivity { get; set; }
        public DateTime? Created { get; set; }
        
        
    }
}