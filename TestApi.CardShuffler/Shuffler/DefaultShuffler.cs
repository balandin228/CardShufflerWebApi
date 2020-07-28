namespace TestApi.Core.Shuffler
{
    public class DefaultShuffler : Shuffler
    {
        public DefaultShuffler()
        {
        }

        public DefaultShuffler(IShuffleAlgorithm algorithm) : base(algorithm)
        {
        }
    }
}