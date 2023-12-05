using Microsoft.EntityFrameworkCore;
using ShareLibrary.Models;

namespace BlazorApp3.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set;}
    }
}
