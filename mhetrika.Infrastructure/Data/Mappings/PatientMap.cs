using mhetrika.core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace mhetrika.Infrastructure.Data.Mappings
{
    public class PatientMap : EntityTypeConfiguration<Patient>
    {
        public PatientMap()
        {
            ToTable("Patients");
            HasKey(p => p.Id);

            Property(p => p.Name)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.Gender)
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();

            Property(p => p.BirthDate)
                .HasColumnType("datetime2");

            Property(p => p.Cpf)
                .HasColumnType("varchar")
                .HasMaxLength(20);

            Property(p => p.Email)
                .HasColumnType("varchar")
                .HasMaxLength(32);

            Property(p => p.Phone)
                .HasColumnType("varchar")
                .HasMaxLength(20);

        }
    }
}
