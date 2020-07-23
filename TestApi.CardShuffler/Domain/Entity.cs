using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Web.Domain
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

        public TKey Key { get; private set; }
    }
}
