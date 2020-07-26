using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestApi.Core.Domain;

namespace TestApi.Core.Infrastructure.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>, IReadOnlyRepository<TEntity> where TEntity : Entity<long>
    {
        protected TestApiDbContext Context { get; }
        private DbSet<TEntity> _items { get; }
        public virtual IQueryable<TEntity> Items => _items;
        protected Repository(TestApiDbContext context)
        {
            Context = context;
            _items = Context.Set<TEntity>();
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var entry = await _items.AddAsync(entity);
            return entry.Entity;
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            return _items.AddRangeAsync(entities);
        }

        public Task RemoveAsync(TEntity entity)
        {
            _items.Remove(entity);
            return Task.CompletedTask;
        }

        public Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            _items.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public Task<TEntity[]> ListAsync()
        {
            return Items.ToArrayAsync();
        }

        public Task<TEntity> FirstAsync()
        {
            return Items.FirstAsync();
        }

        public Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> options)
        {
            return Items.FirstAsync(options);
        }

        public Task<TEntity> FirstOrDefaultAsync()
        {
            return Items.FirstOrDefaultAsync();
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> options)
        {
            return Items.FirstOrDefaultAsync(options);
        }
    }
}
