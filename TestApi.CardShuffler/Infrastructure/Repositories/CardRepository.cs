using System;
using System.Collections.Generic;
using System.Text;
using TestApi.Core.Domain.Card;

namespace TestApi.Core.Infrastructure.Repositories
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        public CardRepository(TestApiDbContext context) : base(context)
        {

        }
    }
}
