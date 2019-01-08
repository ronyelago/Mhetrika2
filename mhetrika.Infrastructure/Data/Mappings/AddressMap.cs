using mhetrika.core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace mhetrika.Infrastructure.Data.Mappings
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            ToTable("Addresses");
            HasKey(p => p.Id);

            Property(p => p.Cep)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Number)
                .HasColumnType("int")
                .IsRequired();

            Property(p => p.Street)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Neighbourhood)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.City)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Uf)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
