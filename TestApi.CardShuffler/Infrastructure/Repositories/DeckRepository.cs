using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TestApi.Core.Domain.Deck;

namespace TestApi.Core.Infrastructure.Repositories
{
    public class DeckRepository : Repository<Deck>, IDeckRepository
    {
        public DeckRepository(TestApiDbContext context) : base(context)
        {

        }

        protected override IQueryable<Deck> Items => base.Items
            .Include(x => x.CardInDecks)
            .ThenInclude(x => x.Card);
    }
}
