using DAL.Entities;

namespace DAL.Repositories.Interfaces;

public interface IOrderItemRepository
{
	Task<IEnumerable<OrderItem>> GetAllAsync();
	Task<OrderItem> GetByIdAsync(int orderId, int productId);
	Task<IEnumerable<OrderItem>> FindAsync(Func<OrderItem, bool> predicate);
	void CreateAsync(OrderItem orderItem);
	void UpdateAsync(int orderId, int productId, OrderItem item);
	void DeleteAsync(int orderId, int productId);
}
