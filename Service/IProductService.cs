using StockControlApi.Models;

namespace StockControlApi.Service
{
    public interface IProductService
    {
        public Task<List<Product>> GetAll();
        public Task<List<Product>> GetByStatus(bool value);
        public Task<Product> GetById(Guid id);
        public Task<String> Post(Product product);
        public Task<String> Put(Product product);
        public Task<String> ChangeStatus(Guid id);
    }
}
