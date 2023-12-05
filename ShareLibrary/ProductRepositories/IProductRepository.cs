

using ShareLibrary.Models;

namespace ShareLibrary.ProductRepositories
{
    public  interface IProductRepository
    {
        Task<Product> AddProductAsync(Product model);
        Task<Product> UpdateProductAsync(Product model);
        Task<Product> DeleteProductAsync(int productId);
        Task<List<Product>> GetAllProductAsync();
        Task<Product> GetProductByIdAsync(int productId);
    }
}
