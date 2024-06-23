using DAL.Contexts;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implementations
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly EShopContext _context;

        public OrderRepository(EShopContext context)
        {
            _context = context;
        }

        public void CreateAsync(Order entity)
        {
            _context.Orders.Add(entity);
        }

        public void DeleteAsync(int id)
        {
            _context.Orders.Remove(new Order { Id = id });
        }

        public async Task<IEnumerable<Order>> FindAsync(Func<Order, bool> predicate)
        {
            return await Task.Run(() => _context.Orders.Where(predicate).ToList());
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            var Orderss = await _context.Orders
                .ToListAsync();
            return Orderss;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var Orders = await _context.Orders
                .FirstOrDefaultAsync(Orders => Orders.Id == id);
            return Orders;
        }

        public async Task SaveChangesAsync(Order entity)
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateAsync(Order entity)
        {
            _context.Orders.Update(entity);
        }
    }
}
