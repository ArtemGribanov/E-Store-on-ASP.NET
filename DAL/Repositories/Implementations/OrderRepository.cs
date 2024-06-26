using DAL.Contexts;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repositories.Implementations
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly EShopContext _context;

        public OrderRepository(EShopContext context)
        {
            _context = context;
        }

        public void CreateAsync(Order order)
        {
            _context.Orders.Add(order);
        }

        public void DeleteAsync(int id)
        {
            _context.Orders.Remove(new Order { Id = id });
        }

        public async Task<IEnumerable<Order>> FindAsync(Expression<Func<Order, bool>> predicate)
        {
            return await _context.Orders.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            var orderss = await _context.Orders.AsNoTracking()
                .ToListAsync();
            return orderss;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var orders = await _context.Orders.AsNoTracking()
                .FirstOrDefaultAsync(Orders => Orders.Id == id);
            return orders;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
        }
    }
}
