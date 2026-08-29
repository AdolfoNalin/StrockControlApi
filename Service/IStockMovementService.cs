using StockControlApi.Models;

namespace StockControlApi.Service
{
    public interface IStockMovementService
    {
        public Task<List<StockMovement>> GetAll();
        public Task<StockMovement> GetById(Guid id);
        public Task<List<StockMovement>> GetByProductId(Guid id);
        public Task<List<StockMovement>> GetByMovementType(MovimentType value);
        public Task<List<StockMovement>> GetByDate(DateOnly? startDate, DateOnly? endDate);
        public Task<bool> Create(StockMovement stockMovement);
        public Task<bool> Update(StockMovement stockMovement);
    }
}