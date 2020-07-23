﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Core.Domain.Card;

namespace TestApi.Core.Domain
{
    public interface ICard
    {
        long Key { get; }
        CardRank Rank { get; }
        CardSuit Suit { get; }
    }
}
