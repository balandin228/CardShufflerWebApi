using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestApi.Core.Domain.Card;
using TestApi.Core.Domain.Deck;

namespace TestApi.Core.Infrastructure
{
    public class TestApiDbContext : DbContext
    {
        public TestApiDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Card> Cards;
        public DbSet<Deck> Decks;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TestApiDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
