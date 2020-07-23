using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Web.Domain.Card
{
    public interface ICard
    {
        long Key { get; }
        CardRank Rank { get; }
        CardSuit Suit { get; }
    }
}
