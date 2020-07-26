﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Core.Domain.Deck
{
    public class Deck : Entity<long>, IDeck
    {
        public IQueryable<CardInDeck> CardInDecks { get; }

        public Deck()
        {
        }
    }
}
