using DAL.Entities;

namespace DAL.Repositories.Interfaces;

public interface IOrderRepository : IRepository<Order>
{
	Task<IEnumerable<Order>> GetOrdersByUserAsync(User user);
	Task<IEnumerable<Product>> GetProductsByOrderIdAsync(int orderId);
}

