namespace TestApi.Core.Domain
{
    public abstract class Entity<TKey>
    {
        protected Entity(TKey key)
        {
            Key = key;
        }

        protected Entity()
        {
        }

        public TKey Key { get; }
    }
}