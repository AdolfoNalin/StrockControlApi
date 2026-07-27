using StockControlApi.Models;

namespace StockControlApi.Service
{
    public interface IStockMovementService
    {
        public Task<List<StockMovement>> GetAll();
        public Task<StockMovement> GetById(Guid id);
        public Task<List<StockMovement>> GetByProductId(Guid id);
        public Task<List<StockMovement>> GetSmartSearch(string value);
        public Task<List<StockMovement>> GetByDate(DateTime? startDate, DateTime? endDate);
        public Task<bool> Create(StockMovement stockMovement);
        public Task<bool> Update(StockMovement stockMovement);
    }
}
