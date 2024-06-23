using DAL.Contexts;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implementations
{
    internal class UserRepository : IUserRepository
    {
        private readonly EShopContext _context;

        public UserRepository(EShopContext context)
        {
            _context = context;
        }

        public void CreateAsync(User entity)
        {
            _context.User.Add(entity);
        }

        public void DeleteAsync(int id)
        {
            _context.User.Remove(new User { Id = id });
        }

        public async Task<IEnumerable<User>> FindAsync(Func<User, bool> predicate)
        {
            return await Task.Run(() => _context.User.Where(predicate).ToList());
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await _context.User
                .ToListAsync();

            return users;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _context.User
                .FirstOrDefaultAsync(user => user.Id == id);
                
            return user;
        }

        public async Task SaveChangesAsync(User entity)
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateAsync(User entity)
        {
            _context.User.Update(entity);
        }
    }
}
