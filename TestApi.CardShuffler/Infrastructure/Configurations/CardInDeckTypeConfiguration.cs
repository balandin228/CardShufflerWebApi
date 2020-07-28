using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApi.Core.Domain;
using TestApi.Core.Domain.Card;

namespace TestApi.Core.Infrastructure.Configurations
{
    public class CardInDeckTypeConfiguration : IEntityTypeConfiguration<CardInDeck>
    {
        public void Configure(EntityTypeBuilder<CardInDeck> builder)
        {
            builder.ToTable("CardInDecks");
            builder.HasKey(x => x.Key);
            builder.Property(x => x.CardId).HasColumnName("CardId");
            builder.Property(x => x.DeckId).HasColumnName("DeckId");
            builder.Property(x => x.Key).HasColumnName("Id");
            builder.HasOne(x => x.Card)
                .WithMany(x => x.CardInDecks)
                .HasForeignKey(x=>x.CardId).HasConstraintName("Card");
            builder.HasOne(x => x.Deck)
                .WithMany(x => x.CardInDecks)
                .HasForeignKey(x => x.DeckId).HasConstraintName("Deck");
        }
    }
}
