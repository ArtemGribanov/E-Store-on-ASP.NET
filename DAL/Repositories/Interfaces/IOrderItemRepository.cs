using DAL.Entities;

namespace DAL.Repositories.Interfaces;

public interface IOrderItemRepository : IRepository<OrderItem>
{
	Task<int> GetProductCountByIdAsync(int productId);
}
