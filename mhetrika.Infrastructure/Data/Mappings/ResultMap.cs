﻿using mhetrika.core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace mhetrika.Infrastructure.Data.Mappings
{
    public class ResultMap : EntityTypeConfiguration<Result>
    {
        public ResultMap()
        {
            ToTable("Results");
            HasKey(p => p.Id);
            Property(p => p.Description)
                .HasColumnType("varchar")
                .HasMaxLength(8)
                .IsRequired();
        }
    }
}
