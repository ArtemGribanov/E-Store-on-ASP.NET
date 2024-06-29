using DAL.Entities;
using System.Linq.Expressions;

namespace DAL.Repositories.Interfaces;

public interface IOrderItemRepository
{
	Task<IEnumerable<OrderItem>> GetAllAsync();
	Task<OrderItem> GetByIdAsync(int orderId, int productId);
	Task<IEnumerable<OrderItem>> FindAsync(Expression<Func<OrderItem, bool>> predicate);
	void CreateAsync(OrderItem orderItem);
	void UpdateAsync(OrderItem item);
	void DeleteAsync(OrderItem item);
}
