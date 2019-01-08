using mhetrika.core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace mhetrika.Infrastructure.Data.Mappings
{
    public class LaboratoryMap : EntityTypeConfiguration<Laboratory>
    {
        public LaboratoryMap()
        {
            ToTable("Laboratories");
            HasKey(p => p.Id);

            Property(p => p.Name)
                .HasColumnType("varchar")
                .HasMaxLength(64)
                .IsRequired();

            Property(p => p.Cnpj)
                .HasColumnType("varchar")
                .HasMaxLength(32)
                .IsRequired();

            Property(p => p.Email)
                .HasColumnType("varchar")
                .HasMaxLength(32)
                .IsRequired();
        }
    }
}
