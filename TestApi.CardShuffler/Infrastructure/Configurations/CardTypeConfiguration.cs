using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApi.Core.Domain.Card;

namespace TestApi.Core.Infrastructure.Configurations
{
    public class CardTypeConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable("Cards");
            builder.HasKey(x => x.Key);
            builder.Property(x => x.Key).HasColumnName("Id");
            builder.Property(x => x.Suit).HasColumnName("Suit");
            builder.Property(x => x.Rank).HasColumnName("Rank");
            builder.HasAlternateKey(x => new {x.Rank, x.Suit});

            builder.HasData(GetDefaultDeck().ToList());
        }

        private IEnumerable<Card> GetDefaultDeck()
        {
            var id = 1;
            for (var i = 0; i < 14; i++)
            for (var j = 0; j < 4; j++)
            {
                yield return new Card(id, (CardSuit) j, (CardRank) i);
                id++;
            }
        }
    }
}