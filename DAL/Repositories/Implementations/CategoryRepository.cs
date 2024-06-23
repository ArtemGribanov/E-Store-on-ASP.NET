using DAL.Contexts;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implementations
{
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly EShopContext _context;

        public CategoryRepository(EShopContext context)
        {
            _context = context;
        }

        public void CreateAsync(Category entity)
        {
            _context.Category.Add(entity);
        }

        public void DeleteAsync(int id)
        {
            _context.Category.Remove(new Category { Id = id });
        }

        public async Task<IEnumerable<Category>> FindAsync(Func<Category, bool> predicate)
        {
            return await Task.Run(() => _context.Category.Where(predicate).ToList());
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var Categorys = await _context.Category
                .ToListAsync();

            return Categorys;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var Category = await _context.Category
                .FirstOrDefaultAsync(Category => Category.Id == id);

            return Category;
        }

        public async Task SaveChangesAsync(Category entity)
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateAsync(Category entity)
        {
            _context.Category.Update(entity);
        }
    }
}
