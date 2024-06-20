using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace DAL.EF
{
    public class EShopContext:DbContext
    {
        private readonly IConfiguration _configuration;

        public EShopContext(DbContextOptions<EShopContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        public DbSet<User> User { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrdersItem { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
            base.OnConfiguring(optionsBuilder);
        }
    }

   
}
