using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestApi.Core.Domain;

namespace TestApi.Core.Infrastructure.Repositories
{
    public interface IReadOnlyRepository<TEntity> where TEntity : Entity<long>
    {
        Task<TEntity[]> ListAsync();
        Task<TEntity> FirstAsync();
        Task<TEntity> FirstOrDefaultAsync();
    }
}
