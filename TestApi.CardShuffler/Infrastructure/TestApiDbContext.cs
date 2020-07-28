using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestApi.Core.Domain;
using TestApi.Core.Domain.Card;
using TestApi.Core.Domain.Deck;

namespace TestApi.Core.Infrastructure
{
    public class TestApiDbContext : DbContext
    {
        public TestApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Card> Cards;
        public DbSet<Deck> Decks;
        public DbSet<CardInDeck> CardInDecks;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForSqlServerUseIdentityColumns();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TestApiDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
