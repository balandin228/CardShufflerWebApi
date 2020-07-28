using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi.Core.DeckBuilder;
using TestApi.Core.Domain;
using TestApi.Core.Domain.Card;
using TestApi.Core.Domain.Deck;
using TestApi.Core.Infrastructure.Repositories;

namespace TestApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeckController : ControllerBase
    {
        private readonly IDeckRepository _deckRepository;
        private readonly IDeckBuilder _deckBuilder;
        private readonly ICardInDeckRepository _cardInDeckRepository;
        private readonly ICardRepository _cardRepository;
        public DeckController(IDeckRepository deckRepository, ICardInDeckRepository cardInDeckRepository, IDeckBuilder deckBuilder,
            ICardRepository cardRepository)
        {
            _deckRepository = deckRepository;
            _deckBuilder = deckBuilder;
            _cardInDeckRepository = cardInDeckRepository;
            _cardRepository = cardRepository;
        }


        [HttpGet]
        [Route("Decks/{id}")]
        public async Task<ActionResult<List<CardInMemory>>> GetDeckById(long id)
        {
            var deck = await _deckRepository.FirstAsync(x => x.Key==id);
            return deck.CardInDecks.OrderBy(x=>x.NumberInDeck).Select(x=>x.Card).Select(x=>new CardInMemory(x.Suit,x.Rank)).ToList();
        }

        [HttpGet]
        [Route("Decks/{id}/Shuffle")]
        public async Task<ActionResult<List<CardInMemory>>> ShuffleDeck(long id)
        {
            var deck = await _deckRepository.FirstAsync(x => x.Key == id);
            var notShuffled = deck.CardInDecks;

            var shuffledIndexes = _deckBuilder.Shuffle(notShuffled.Select(x => x.NumberInDeck));
            var i = 0;
            foreach (var cardInDeck in deck.CardInDecks)
            {
                cardInDeck.NumberInDeck = shuffledIndexes[i];
                ++i;
            }

            await _cardInDeckRepository.Context.SaveChangesAsync();
            return deck.CardInDecks
                .OrderBy(x => x.NumberInDeck)
                .Select(x=>x.Card)
                .Select(x=>new CardInMemory(x.Suit,x.Rank))
                .ToList();
        }
        [HttpGet]
        [Route("Decks")]
        public async Task<ActionResult<List<string>>> GetDecksNames()
        {
            
            var result = await _deckRepository.ListAsync();
            return result.Select(d => d.Name).ToList();
        }

        [HttpPost]
        [Route("CreateDeck")]
        public async Task<ActionResult> CreateDeck(string name)
        {
            var deckInMemory = _deckBuilder.CreateDeck();
            var deck = new Deck(name);
            await _deckRepository.AddAsync(deck);
            await _deckRepository.Context.SaveChangesAsync();
            var i = 1;
            var toAdd = new List<CardInDeck>();
            foreach (var cardInMemory in deckInMemory)
            {
                var card = await _cardRepository.FirstAsync(x =>
                    x.Suit == cardInMemory.Suit && x.Rank == cardInMemory.Rank);
                toAdd.Add(new CardInDeck(){CardId = card.Key,DeckId = deck.Key,NumberInDeck = i});
                i++;
            }

            await _cardInDeckRepository.AddRangeAsync(toAdd);
            await _cardInDeckRepository.Context.SaveChangesAsync();
            return Ok();
        }
    }
}
