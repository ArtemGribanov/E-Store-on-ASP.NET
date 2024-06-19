using DAL.Entities;

namespace DAL.Repositories.Interfaces;

public interface IOrderRepository
{
	Task<IEnumerable<Order>> GetOrdersByUserAsync(User user);
	Task<IEnumerable<Product>> GetProductsByOrderIdAsync(int orderId);
}

