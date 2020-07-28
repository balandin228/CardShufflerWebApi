using Microsoft.EntityFrameworkCore;
using TestApi.Core.Domain;
using TestApi.Core.Domain.Card;
using TestApi.Core.Domain.Deck;

namespace TestApi.Core.Infrastructure
{
    public class TestApiDbContext : DbContext
    {
        public DbSet<CardInDeck> CardInDecks;

        public DbSet<Card> Cards;
        public DbSet<Deck> Decks;

        public TestApiDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForSqlServerUseIdentityColumns();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TestApiDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}