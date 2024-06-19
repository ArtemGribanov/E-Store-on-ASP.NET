using DAL.Entities;

namespace DAL.Repositories.Interfaces;
public interface IProductRepository
{
	Task<string> GetDescriptionByIdAsync(int id);
	Task<IEnumerable<Product>> GetProductsByCategoryAsync(Category category);
}
