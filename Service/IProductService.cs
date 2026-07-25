using StockControlApi.Models;

namespace StockControlApi.Service
{
    public interface IProductService
    {
        public Task<List<Product>> GetAll();
        public Task<List<Product>> GetByStatus(bool value);
        public Task<Product> GetById(Guid id);
        public Task<String> Create (Product product);
        public Task<String> Update(Product product);
        public Task<bool> UpdateStock(Guid productId, int stockQuantity);
        public Task<String> ChangeStatus(Guid id);
    }
}
