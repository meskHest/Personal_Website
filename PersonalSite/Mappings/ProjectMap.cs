using FluentNHibernate.Mapping;
using PersonalSite.Entities;

namespace PersonalSite.Mappings
{
    public class ProjectMap: ClassMap<Project>
    {
        public ProjectMap()
        {
            Table("Project");
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Client);
            Map(x => x.Description);
            Map(x => x.Ingress);
            Map(x => x.Created);
            Map(x => x.Caption);
            Map(x => x.Url);
            Map(x => x.CoverImg);
            References(x => x.User);
            HasMany(x => x.Gallery);
        }
    }
}