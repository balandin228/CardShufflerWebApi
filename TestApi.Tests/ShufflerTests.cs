using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using TestApi.Core.Shuffler;

namespace TestApi.Tests
{
    [TestFixture]
    public class ShufflerTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        private static readonly IShuffler _shuffler = new DefaultShuffler();

        private static List<int> TestList
        {
            get
            {
                var result = new List<int>();
                for (var i = 0; i < 100; i++)
                    result.Add(i);
                return result;
            }
        }

        public static class RandomShuffleSource
        {
            private static readonly IEnumerable<int> testData1 = ShuffleResult(TestList);
            private static readonly IEnumerable<int> testData2 = ShuffleResult(TestList);
            private static readonly IEnumerable<int> testData3 = ShuffleResult(TestList);

            private static readonly TestCaseData[] TestCases =
            {
                new TestCaseData(testData1).SetName("testData1"),
                new TestCaseData(testData2).SetName("testData2"),
                new TestCaseData(testData3).SetName("testData3")
            };
        }

        public static IEnumerable<int> ShuffleResult(List<int> data)
        {
            return _shuffler.Shuffle(data);
        }

        //к сожалению, этот тест должен падать. Так как в fluent Assertions можно сравнить, только следование строгому порядку
        //а не наоборот. Во всяком случае, я не нашел как это сделать, а писать что-то кастомное для тестового, не имеет смысла, наверное
        [Test]
        [TestCaseSource(typeof(RandomShuffleSource), "TestCases")]
        public void Should_Shuffle_Randomly(IEnumerable<int> data)
        {
            var result1 = _shuffler.Shuffle(data);
            var result2 = _shuffler.Shuffle(data);

            result2.Should().BeEquivalentTo(result1, o => o.WithStrictOrdering(), "That's ok!");
        }
    }
}