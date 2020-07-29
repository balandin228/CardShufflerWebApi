using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TestApi.Core.DeckBuilder;
using TestApi.Core.Domain;
using TestApi.Core.Domain.Deck;
using TestApi.Core.Infrastructure.Repositories;
using TestApi.Web.Dtos;

namespace TestApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeckController : ControllerBase
    {
        private readonly ICardInDeckRepository _cardInDeckRepository;
        private readonly ICardRepository _cardRepository;
        private readonly IDeckBuilder _deckBuilder;
        private readonly IDeckRepository _deckRepository;
        private readonly IMapper _mapper;
        private const string NotFoundMessege = "Deck is not found";

        public DeckController(IDeckRepository deckRepository, ICardInDeckRepository cardInDeckRepository,
            IDeckBuilder deckBuilder,
            ICardRepository cardRepository, IMapper mapper)
        {
            _deckRepository = deckRepository;
            _deckBuilder = deckBuilder;
            _cardInDeckRepository = cardInDeckRepository;
            _cardRepository = cardRepository;
            _mapper = mapper;
        }



        /// <summary>
        /// Удалить колоду
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Decks/{id}/Delete")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteDeck(long id)
        {
            var deck = await _deckRepository.FirstOrDefaultAsync(x => x.Key == id);
            if (deck is null)
                return NotFound(NotFoundMessege);
            await _deckRepository.RemoveAsync(deck);
            await _deckRepository.Context.SaveChangesAsync();
            return Ok();
        }

        
        /// <summary>
        ///     Показать карты колоды
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Decks/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<DeckDto>> GetDeckById(long id)
        {
            var deck = await _deckRepository.FirstOrDefaultAsync(x => x.Key == id);
            if (deck is null)
                return NotFound(NotFoundMessege);
            return  _mapper.Map<DeckDto>(deck);
        }

        /// <summary>
        ///     Перетасовать и сохранить колоду
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Decks/{id}/Shuffle")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<DeckDto>> ShuffleDeck(long id)
        {
            var deck = await _deckRepository.FirstOrDefaultAsync(x => x.Key == id);
            if (deck is null)
                return NotFound(NotFoundMessege);
            var notShuffled = deck.CardInDecks;

            var shuffledIndexes = _deckBuilder.Shuffle(notShuffled.Select(x => x.NumberInDeck));
            var i = 0;
            foreach (var cardInDeck in deck.CardInDecks)
            {
                cardInDeck.NumberInDeck = shuffledIndexes[i];
                ++i;
            }
            await _cardInDeckRepository.Context.SaveChangesAsync();
            return _mapper.Map<DeckDto>(deck);
        }

        /// <summary>
        ///     Посмотреть список доступных колод
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Decks")]
        public async Task<ActionResult<List<GetDecksDto>>> GetDecks()
        {
            var result = await _deckRepository.ListAsync();
            return _mapper.Map<List<GetDecksDto>>(result);
        }

        /// <summary>
        ///     Создать новую колоду
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateDeck")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> CreateDeck(string name)
        {
            var deck = new Deck(name);
            try
            {
                var deckInMemory = _deckBuilder.CreateDeck();
                await _deckRepository.AddAsync(deck);
                await _deckRepository.Context.SaveChangesAsync();
                var i = 1;
                var toAdd = new List<CardInDeck>();
                foreach (var cardInMemory in deckInMemory)
                {
                    var card = await _cardRepository.FirstAsync(x =>
                        x.Suit == cardInMemory.Suit && x.Rank == cardInMemory.Rank);
                    toAdd.Add(new CardInDeck {CardId = card.Key, DeckId = deck.Key, NumberInDeck = i});
                    i++;
                }

                await _cardInDeckRepository.AddRangeAsync(toAdd);
                await _cardInDeckRepository.Context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateException)
            {
                return base.BadRequest($"Deck {name} already exist");
            }
            catch (Exception)
            {
                await _deckRepository.RemoveAsync(deck);
                return StatusCode(StatusCodes.Status500InternalServerError, "Sorry");
            }
        }
    }
}