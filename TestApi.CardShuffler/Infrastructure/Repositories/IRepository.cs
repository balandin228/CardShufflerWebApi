﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestApi.Core.Domain;

namespace TestApi.Core.Infrastructure.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity<long>
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task RemoveAsync(TEntity entity);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);
    }
}