using System.Collections.Generic;

namespace TestApi.Web.Dtos
{
    public class DeckDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<CardDto> Card { get; set; }
    }
}