using System;

namespace ProjectExtraFieldsApp
{
    public class ProjectExtraFieldsModel
    {
        public string Title { get; set; }
        public Guid? ProjectUID { get; set; }
        public string Progress_Activity { get; set; }
        public string Planned_Activity { get; set; }
        public DateTime? Created { get; set; }
        
        
    }
}