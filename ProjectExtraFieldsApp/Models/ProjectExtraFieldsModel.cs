using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectExtraFieldsApp
{
    public class ProjectExtraFieldsModel
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        
        public Guid ProjectUID { get; set; }
        
        public string ProgressActivity { get; set; }
        public string PlannedActivity { get; set; }
        public DateTime Created { get; set; }
        
        
    }
}