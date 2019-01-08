using mhetrika.core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace mhetrika.Infrastructure.Data.Mappings
{
    public class FibrosisMap : EntityTypeConfiguration<Fibrosis>
    {
        public FibrosisMap()
        {
            ToTable("Fibrosis");
            Property(p => p.Age).IsRequired();
            Property(p => p.AST).IsRequired();
            Property(p => p.ALT).IsRequired();
            Property(p => p.IMC).IsRequired();
            Property(p => p.Platelets).IsRequired();
            Property(p => p.Albumin).IsRequired();
            Property(p => p.Diabetic).IsRequired();
        }
    }
}
