using System.Linq;
using AutoMapper;
using TestApi.Core.Domain;
using TestApi.Core.Domain.Card;
using TestApi.Core.Domain.Deck;
using TestApi.Web.Dtos;

namespace TestApi.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Card, CardDto>();

            CreateMap<CardInDeck, CardDto>()
                .ForMember(x => x.Suit,
                    opt => opt.MapFrom(x => x.Card.Suit))
                .ForMember(x => x.Rank,
                    opt => opt.MapFrom(x => x.Card.Rank));

            CreateMap<Deck, DeckDto>()
                .ForMember(x => x.Id,
                    opt => opt.MapFrom(x => x.Key))
                .ForMember(x => x.Card,
                    opt => opt
                        .MapFrom((deck, deckDto, i, context) => deck.CardInDecks
                            .OrderBy(cd => cd.NumberInDeck)
                            .Select(c => context.Mapper.Map<CardDto>(c))));

            CreateMap<Deck, GetDecksDto>()
                .ForMember(x => x.Id,
                    opt => opt.MapFrom(x => x.Key));
        }
    }
}