using DAL.Contexts;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace DAL.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EShopContext _context;

        public CategoryRepository(EShopContext context)
        {
            _context = context;
        }

        public void CreateAsync(Category category)
        {
            _context.Category.Add(category);
            _context.SaveChanges();
        }

        public void DeleteAsync(Category category)
        {
            _context.Category.Remove(category);
            _context.SaveChanges();
        }

		public async Task<IEnumerable<Category>> FindAsync(Expression<Func<Category, bool>> predicate)
        {
            return await _context.Category.Where(predicate).AsNoTracking()
                .ToListAsync();
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

        public void UpdateAsync(Category category)
        {
            _context.Category.Update(category);
            _context.SaveChanges();
        }
    }
}
