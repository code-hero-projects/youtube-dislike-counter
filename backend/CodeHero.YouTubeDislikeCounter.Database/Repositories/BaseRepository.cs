using CodeHero.YouTubeDislikeCounter.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CodeHero.YouTubeDislikeCounter.Database.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly DbContext _dbContext;

        public BaseRepository(DbSet<T> dbSet, DbContext dbContext)
        {
            _dbSet = dbSet;
            _dbContext = dbContext;

            _dbContext.Database.EnsureCreated();
        }

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public void Delete(T entity) => _dbSet.Remove(entity);

        public async Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> predicate) => await _dbSet.AsNoTracking().Where(predicate).ToListAsync();

        public Task<T> GetAsync(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).FirstOrDefaultAsync();

        public async Task<IEnumerable<T>> ListAsync() => await _dbSet.AsNoTracking().ToListAsync();

        public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();

        public void Update(T entity) => _dbSet.Update(entity);
    }
}
