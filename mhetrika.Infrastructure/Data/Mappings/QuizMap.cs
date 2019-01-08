using mhetrika.core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace mhetrika.Infrastructure.Data.Mappings
{
    public class QuizMap : EntityTypeConfiguration<Quiz>
    {
        public QuizMap()
        {
            ToTable("Questions");
            HasKey(p => p.Id);

            Property(p => p.Description)
                .HasColumnType("varchar")
                .HasMaxLength(128)
                .IsRequired();
        }
    }
}
