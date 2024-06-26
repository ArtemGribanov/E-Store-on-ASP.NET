using DAL.Contexts;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace DAL.Repositories.Implementations
{
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly EShopContext _context;

        public CategoryRepository(EShopContext context)
        {
            _context = context;
        }

        public void CreateAsync(Category category)
        {
            _context.Category.Add(category);
        }

        public void DeleteAsync(int id)
        {
            _context.Category.Remove(new Category { Id = id });
        }

        public async Task<IEnumerable<Category>> FindAsync(Expression<Func<Category, bool>> predicate)
        {
            return await _context.Category.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categorys = await _context.Category.AsNoTracking()
                .ToListAsync();

            return categorys;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var category = await _context.Category.AsNoTracking()
                .FirstOrDefaultAsync(Category => Category.Id == id);

            return category;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateAsync(Category category)
        {
            _context.Category.Update(category);
        }
    }
}
