using mhetrika.core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace mhetrika.Infrastructure.Data.Mappings
{
    public class MedicamentMap : EntityTypeConfiguration<Medicament>
    {
        public MedicamentMap()
        {
            ToTable("Medicaments");
            HasKey(p => p.Id);

            Property(p => p.Name)
                .HasColumnType("varchar")
                .HasMaxLength(64)
                .IsRequired();

            Property(p => p.Status)
                .HasColumnType("varchar")
                .HasMaxLength(32)
                .IsRequired();
        }
    }
}
