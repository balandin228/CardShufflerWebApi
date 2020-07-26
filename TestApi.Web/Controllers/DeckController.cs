using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        //[HttpGet]
        //[Route("Decks")]
        //public async Task<ActionResult<List<string>>> GetDecksNames()
        //{
        //    var result = await _deckRepository.ListAsync();
        //    return result.Select(d=>d.Name).ToList();
        //}

        [HttpPost]
        public async Task<ActionResult> CreateDeckByName(string name)
        {
            var cards = _deckBuilder.Cards;
            var deck = new Deck(name);
            await _deckRepository.AddAsync(deck);
            await _cardInDeckRepository.AddRangeAsync(cards.Select(c => new CardInDeck(deck.Key, c.Key)));
            await _deckRepository.Context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Card>>> GetAllCards()
        {
            var result = await _cardRepository.ListAsync();
            return result.ToList();
        }
}
}
