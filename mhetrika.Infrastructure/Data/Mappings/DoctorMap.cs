using mhetrika.core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace mhetrika.Infrastructure.Data.Mappings
{
    public class DoctorMap : EntityTypeConfiguration<Doctor>
    {
        public DoctorMap()
        {
            ToTable("Doctors");

            Property(p => p.Crm)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            Property(p => p.Uf)
                .HasColumnType("varchar")
                .HasMaxLength(2)
                .IsRequired();

            Property(p => p.Phone)
                .HasColumnType("varchar")
                .HasMaxLength(20);

            Property(p => p.Specialty)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
