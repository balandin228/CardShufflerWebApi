using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using TestApi.Core.DeckBuilder;
using TestApi.Core.Infrastructure;

namespace TestApi.Tests
{
    [TestFixture]
    public class DeckBuilderTests
    {
        private DeckBuilder Builder { get; set; }

        [SetUp]
        public void SetUp()
        {
            Builder = new DeckBuilder();
        }
        [Test]
        public void DeckBuilderOptions_Should_Create_DifferentLinks()
        {
            var options = new DeckBuilderOptions(DeckType.Default);
            var cards1 = options.Deck;
            var cards2 = options.Deck;
            cards1.Equals(cards2).Should().BeFalse();
        }

        [Test]
        public void DeckBuilderProperty_Should_Give_NotLazyCollection()
        {
            var cards1 = Builder.Cards;
            cards1.Should().NotBeNullOrEmpty();
            cards1.Count.Should().Be(56);
        }

        [Test]
        public void DeckBuilderCreateDeck_Should_GiveNotLazyCollection()
        {
            var cards1 = Builder.CreateDeck();
            cards1.Should().NotBeNullOrEmpty();
            cards1.Count.Should().Be(56);
        }

        [Test]
        public void DeckBuilderShuffle_Should_GiveNotLazyCollection()
        {
            var cards1 = Builder.Shuffle();
            cards1.Should().NotBeNullOrEmpty();
            cards1.Count.Should().Be(56);
        }
    }
}
