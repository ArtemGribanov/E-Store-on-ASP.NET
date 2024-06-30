using DAL.Contexts;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repositories.Implementations
{
    internal class UserRepository : IUserRepository
    {
        private readonly EShopContext _context;

        public UserRepository(EShopContext context)
        {
            _context = context;
        }

        public void CreateAsync(User user)
        {
            _context.User.Add(user);
            _context.SaveChangesAsync();
        }

        public void DeleteAsync(User user)
        {
            _context.User.Remove(user);
            _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> FindAsync(Expression<Func<User, bool>> predicate)
        {
            return await _context.User.Where(predicate).AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await _context.User.AsNoTracking()
                .ToListAsync();

            return users;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _context.User.AsNoTracking()
                .FirstOrDefaultAsync(user => user.Id == id);
                
            return user;
        }

        public void UpdateAsync(User user)
        {
            _context.User.Update(user);
            _context.SaveChangesAsync();
        }
    }
}
