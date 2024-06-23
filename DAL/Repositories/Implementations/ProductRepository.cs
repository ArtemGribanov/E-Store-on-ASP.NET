using DAL.Contexts;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implementations
{
    internal class ProductRepository : IProductRepository
    {
        private readonly EShopContext _context;

        public ProductRepository(EShopContext context)
        {
            _context = context;
        }

        public void CreateAsync(Product entity)
        {
            _context.Product.Add(entity);
        }

        public void DeleteAsync(int id)
        {
            _context.Product.Remove(new Product { Id = id });
        }

        public async Task<IEnumerable<Product>> FindAsync(Func<Product, bool> predicate)
        {
            return await Task.Run(() => _context.Product.Where(predicate).ToList());
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var Products = await _context.Product
                .ToListAsync();

            return Products;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var Product = await _context.Product
                .FirstOrDefaultAsync(Product => Product.Id == id);

            return Product;
        }

        public async Task SaveChangesAsync(Product entity)
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateAsync(Product entity)
        {
            _context.Product.Update(entity);
        }
    }
}
