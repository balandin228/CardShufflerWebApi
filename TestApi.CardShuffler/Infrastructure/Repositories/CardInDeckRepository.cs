using System;
using System.Collections.Generic;
using System.Text;
using TestApi.Core.Domain;

namespace TestApi.Core.Infrastructure.Repositories
{
    public class CardInDeckRepository : Repository<CardInDeck>, ICardInDeckRepository
    {
        public CardInDeckRepository(TestApiDbContext options) : base(options)
        {
        }
    }
}
