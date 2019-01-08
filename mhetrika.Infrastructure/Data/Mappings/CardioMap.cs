using mhetrika.core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace mhetrika.Infrastructure.Data.Mappings
{
    public class CardioMap : EntityTypeConfiguration<Cardio>
    {
        public CardioMap()
        {
            ToTable("Cardio");
            Property(p => p.Pas).IsRequired();
            Property(p => p.Ldl_c).IsRequired();
            Property(p => p.Hdl_c).IsRequired();
            Property(p => p.Ct).IsRequired();
            Property(p => p.Status).IsRequired();
            Property(p => p.Smokes).IsRequired();
            Property(p => p.Statin).IsRequired();
        }
    }
}
