namespace TestApi.Core.Domain.Deck
{
    public interface IDeck
    {
        long Key { get; }

        string Name { get; }
    }
}