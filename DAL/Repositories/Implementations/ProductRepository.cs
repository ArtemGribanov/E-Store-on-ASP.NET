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
            _context.SaveChanges();
        }

        public void DeleteAsync(Product product)
        {
            _context.Product.Remove(product);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Product>> FindAsync(Expression<Func<Product, bool>> predicate)
        {
            return await _context.Product.Where(predicate).AsNoTracking()
                .ToListAsync();
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

        public void UpdateAsync(Product product)
        {
            _context.Product.Update(product);
            _context.SaveChanges();
        }
    }
}
