using System.Linq.Expressions;

namespace CodeHero.YouTubeDislikeCounter.Domain.Repositories
{
    public interface IRepository<T>
    {
        public Task AddAsync(T entity);
        public Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        public Task<IEnumerable<T>> ListAsync();
        Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> predicate);
        void Update(T entity);
        public void Delete(T entity);
        public Task SaveChangesAsync();
    }
}
