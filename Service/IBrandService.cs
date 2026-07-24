using StockControlApi.Models;

namespace StockControlApi.Service
{
    public interface IBrandService
    {
        public Task<List<Brand>> GetAll();
        public Task<List<Brand>> GetByStatus(bool value);
        public Task<Brand> GetById(Guid id);
        public Task<string> Create(Brand brand);
        public Task<string> Update(Brand brand);
        public Task<string> ChangeSatus(Guid id);
    }
}
