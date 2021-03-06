﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApi.Core.Domain.Deck;

namespace TestApi.Core.Infrastructure.Configurations
{
    public class DeckTypeConfiguration : IEntityTypeConfiguration<Deck>
    {
        public void Configure(EntityTypeBuilder<Deck> builder)
        {
            builder.ToTable("Decks");
            builder.HasKey(x => x.Key);
            builder.Property(x => x.Key).HasColumnName("Id");
            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}