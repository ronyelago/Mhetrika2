using mhetrika.core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace mhetrika.Infrastructure.Data.Mappings
{
    public class ResponseMap : EntityTypeConfiguration<Response>
    {
        public ResponseMap()
        {
            ToTable("Responses");
            HasKey(p => p.Id);
            Property(p => p.Description)
                .HasColumnType("varchar")
                .HasMaxLength(8)
                .IsRequired();
        }
    }
}
