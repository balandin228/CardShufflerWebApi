using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestApi.Core.Domain;

namespace TestApi.Core.Infrastructure.Repositories
{
    public interface IReadOnlyRepository<TEntity> where TEntity : Entity<long>
    {
        Task<TEntity[]> ListAsync();
        Task<TEntity[]> ListAsync(Expression<Func<TEntity, bool>> options);
        Task<TEntity[]> GetWithInclude(params Expression<Func<TEntity, object>>[] options);

        Task<TEntity> FirstAsync();

        // TODO: заменить на ISpecification, если успею
        Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> options);
        Task<TEntity> FirstOrDefaultAsync();
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> options);
    }
}