using DAL.Contexts;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repositories.Implementations
{
    internal class OrderItemRepository : IOrderItemRepository
    {
        private readonly EShopContext _context;

        public OrderItemRepository(EShopContext context)
        {
            _context = context;
        }

        public void CreateAsync(OrderItem orderItem)
        {
            _context.OrdersItem.Add(orderItem);
            _context.SaveChangesAsync();
        }

        public void DeleteAsync(OrderItem orderItem)
        {
            _context.OrdersItem.Remove(orderItem);
            _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderItem>> FindAsync(Expression<Func<OrderItem, bool>> predicate)
        {
            return await _context.OrdersItem.Where(predicate).AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            var ordersItems = await _context.OrdersItem.AsNoTracking()
                .ToListAsync();

            return ordersItems;
        }

        public async Task<OrderItem> GetByIdAsync(int id)
        {
            var orderItem = await _context.OrdersItem.AsNoTracking()
                .FirstOrDefaultAsync(OrderItem => OrderItem.OrderId == id);

            return orderItem;
        }

        public void UpdateAsync(OrderItem orderItem)
        {
            _context.OrdersItem.Update(orderItem);
            _context.SaveChangesAsync();
        }
    }
}
