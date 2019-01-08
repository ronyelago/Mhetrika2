using mhetrika.core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace mhetrika.Infrastructure.Data.Mappings
{
    class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("Users");
            HasKey(p => p.Id);

            Property(p => p.Name)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.Email)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Password)
                .HasColumnType("varchar")
                .HasMaxLength(50);

        }
    }
}
