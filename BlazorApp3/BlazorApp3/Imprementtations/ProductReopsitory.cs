using BlazorApp3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ShareLibrary.Models;
using ShareLibrary.ProductRepositories;

namespace BlazorApp3.Imprementtations
{
    public class ProductReopsitory : IProductRepository
    {
        private readonly AppDbContext appDbContext;

        public ProductReopsitory(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Product> AddProductAsync(Product model)
        {
            if (model is null) return null;

            // Check if the product name already exists
            var chk = await appDbContext.Products.Where(_ => _.Name.ToLower().Equals(model.Name.ToLower())).FirstOrDefaultAsync();
            if (chk is not null) return null;

            var result = appDbContext.Products.Add(model).Entity;
            await appDbContext.SaveChangesAsync();
            return result;


        }

        public async Task<Product> DeleteProductAsync(int productId)
        {
            var result = await appDbContext.Products.FirstOrDefaultAsync(_ => _.Id == productId);
            if (result is null) return null;

            appDbContext.Products.Remove(result);
            await appDbContext.SaveChangesAsync();
            return result;


        }

        public async Task<List<Product>> GetAllProductAsync() => await appDbContext.Products.ToListAsync();
        

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var result = await appDbContext.Products.FirstOrDefaultAsync(_ => _.Id == productId);
            if (result is null) return null;

            return result;
        }

        public async Task<Product> UpdateProductAsync(Product model)
        {
            var result = await appDbContext.Products.FirstOrDefaultAsync(_ => _.Id == model.Id);
            if (result is null) return null;

            result.Name = model.Name;
            result.Quality   = model.Quality;

            //save changes
            await appDbContext.SaveChangesAsync();

            return result;
        }
    }
}
