using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestApi.Core.Domain;

namespace TestApi.Core.Infrastructure.Repositories
{
    public interface IReadOnlyRepository<TEntity> where TEntity : Entity<long>
    {
        Task<TEntity[]> ListAsync();
        Task<TEntity> FirstAsync();
        // TODO: заменить на ISpecification, если успею
        Task<TEntity> FirstAsync(Expression<Func<TEntity,bool>> options);
        Task<TEntity> FirstOrDefaultAsync();
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity,bool>> options);
    }
}
