using System.Collections.Generic;
using System.Threading.Tasks;
using TestApi.Core.Domain;

namespace TestApi.Core.Infrastructure.Repositories
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : Entity<long>
    {
        TestApiDbContext Context { get; }

        Task<TEntity> AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task RemoveAsync(TEntity entity);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);
    }
}