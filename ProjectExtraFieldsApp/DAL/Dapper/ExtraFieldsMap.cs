using Dapper.FluentMap.Mapping;

namespace ProjectExtraFieldsApp.FluentMap
{
    public class ExtraFieldsMap : EntityMap<ProjectExtraFieldsModel>
    {
        public ExtraFieldsMap()
        {
            Map(ef => ef.PlannedActivity).ToColumn("Planned_Activity");
            Map(ef => ef.ProgressActivity).ToColumn("Progress_Activity");
        }
    }
}