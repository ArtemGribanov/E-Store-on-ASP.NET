using DAL.Contexts;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repositories.Implementations
{
    internal class ProductRepository : IProductRepository
    {
        private readonly EShopContext _context;

        public ProductRepository(EShopContext context)
        {
            _context = context;
        }

        public void CreateAsync(Product product)
        {
            _context.Product.Add(product);
        }

        public void DeleteAsync(int id)
        {
            _context.Product.Remove(new Product { Id = id });
        }

        public async Task<IEnumerable<Product>> FindAsync(Expression<Func<Product, bool>> predicate)
        {
            return await _context.Product.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await _context.Product.AsNoTracking()
                .ToListAsync();

            return products;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _context.Product.AsNoTracking()
                .FirstOrDefaultAsync(Product => Product.Id == id);

            return product;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateAsync(Product product)
        {
            _context.Product.Update(product);
        }
    }
}
