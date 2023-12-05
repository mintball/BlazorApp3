using ShareLibrary.Models;
using ShareLibrary.ProductRepositories;
using System.Net.Http.Json;

namespace BlazorApp3.Services
{
    public class ProductService : IProductRepository
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Product> AddProductAsync(Product model)
        {
            var result = await httpClient.PostAsJsonAsync("api/Product/Add-Product", model);
            var response = await result.Content.ReadFromJsonAsync<Product>();
            return response!;
        }

        public async Task<Product> DeleteProductAsync(int productId)
        {
            var result = await httpClient.DeleteAsync($"api/Product/Delete-Product/{productId}");
            var response = await result.Content.ReadFromJsonAsync<Product>();
            return response!;
        }

        public async Task<List<Product>> GetAllProductAsync()
        {
            var result = await httpClient.GetAsync("api/Product/All-Products");
            var response = await result.Content.ReadFromJsonAsync<List<Product>>();
            return response!;
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var result = await httpClient.GetAsync($"api/Product/Single-Product/{productId}");
            var response = await result.Content.ReadFromJsonAsync<Product>();
            return response!;
        }

        public async Task<Product> UpdateProductAsync(Product model)
        {
            var result = await httpClient.PutAsJsonAsync("api/Product/Update-Product", model);
            var response = await result.Content.ReadFromJsonAsync<Product>();
            return response!;
        }
    }
}
