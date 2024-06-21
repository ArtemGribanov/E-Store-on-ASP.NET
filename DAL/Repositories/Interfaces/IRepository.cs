namespace DAL.Repositories.Interfaces
{
    public interface IRepository<T>
    {

        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate);
        Task<int> SaveChangesAsync(T entity);
        void CreateAsync(T entity);
        void UpdateAsync(T item);
        void DeleteAsync(int id);
    }
}
