using System.Linq.Expressions;

namespace DAL.Repositories.Interfaces
{
    public interface IRepository<T>
    {

        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task SaveChangesAsync();
        void CreateAsync(T entity);
        void UpdateAsync(T item);
        void DeleteAsync(int id);
    }
}
