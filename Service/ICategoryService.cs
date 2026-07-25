using StockControlApi.Models;

namespace StockControlApi.Service
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetAll();
        public Task<List<Category>> GetByStatus(bool value);
        public Task<Category> GetById(Guid id);
        public Task<string> Create(Category category);
        public Task<string> Update(Category category);
        public Task<string> ChangeSatus(Guid id);
    }
}
