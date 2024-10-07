using BookRepository.Common.Utils;
using BookRepository.Data;
using BookRepository.Data.Common;
using BookRepository.Services.Common.DataServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookRepository.Services.Common.DataServices
{
    public class DataService<TEntity>(BookRepositoryDbContext db) : IDataService<TEntity>
        where TEntity : class
    {
        private readonly BookRepositoryDbContext db = db;
        private readonly DbSet<TEntity> dbSet = db.Set<TEntity>();

        public async Task Add(TEntity entity)
            => await db.AddAsync(entity);

        public void Update(TEntity entity)
           => db.Update(entity);

        public void Delete(TEntity entity)
            => db.Remove(entity);

        public async Task SaveChanges()
            => await db.SaveChangesAsync();

        public async Task<bool> Exists(Expression<Func<TEntity, bool>>? filter = null)
            => await GetQuery(filter)
            .AnyAsync();

        public IQueryable<TEntity> GetByIdQuery(object id)
        {
            var filter = ExpressionBuilder.BuildEqualsFilter<TEntity>(id, nameof(BaseModel<object>.Id));

            return GetQuery(filter: filter);
        }

        public IQueryable<TEntity> GetQuery(
            Expression<Func<TEntity, bool>>? filter = null,
            Expression<Func<TEntity, object>>? orderBy = null,
            bool descending = false,
            int? skip = null,
            int? take = null)
        {
            var query = dbSet.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = descending
                    ? query.OrderByDescending(orderBy)
                    : query.OrderBy(orderBy);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        public async Task<TEntity?> OneById(object id)
            => await GetByIdQuery(id)
            .FirstOrDefaultAsync();

        public async Task<bool> ExistsById(object id)
        => await GetByIdQuery(id)
            .AnyAsync();

        public async Task<int> Count(Expression<Func<TEntity, bool>>? filter = null)
            => await GetQuery(filter)
            .CountAsync();
    }
}
