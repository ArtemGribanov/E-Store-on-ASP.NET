namespace DAL.Repositories.Interfaces;

public interface IOrderItemRepository
{
	Task<int> GetProductCountByIdAsync(int productId);
}
