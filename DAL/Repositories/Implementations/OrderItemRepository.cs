using DAL.Contexts;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implementations
{
    internal class OrderItemRepository : IOrderItemRepository
    {
        private readonly EShopContext _context;

        public OrderItemRepository(EShopContext context)
        {
            _context = context;
        }

        public void CreateAsync(OrderItem entity)
        {
            _context.OrdersItem.Add(entity);
        }

        public void DeleteAsync(int id)
        {
            _context.OrdersItem.Remove(new OrderItem { OrderId = id });
        }

        public async Task<IEnumerable<OrderItem>> FindAsync(Func<OrderItem, bool> predicate)
        {
            return await Task.Run(() => _context.OrdersItem.Where(predicate).ToList());
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            var OrdersItems = await _context.OrdersItem
                .ToListAsync();

            return OrdersItems;
        }

        public async Task<OrderItem> GetByIdAsync(int id)
        {
            var OrderItem = await _context.OrdersItem
                .FirstOrDefaultAsync(OrderItem => OrderItem.OrderId == id);

            return OrderItem;
        }

        public async Task SaveChangesAsync(OrderItem entity)
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateAsync(OrderItem entity)
        {
            _context.OrdersItem.Update(entity);
        }
    }
}
