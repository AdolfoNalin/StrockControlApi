using Microsoft.AspNetCore.Mvc;
using StockControlApi.Models;

namespace StockControlApi.Service
{
    public interface ISupplierService
    {
        public Task<List<Supplier>> GetAll();
        public Task<Supplier> GetById(Guid id);
        public Task<List<Supplier>> GetByStatus(bool value);
        public Task<string> Create(Supplier supplier);
        public Task<string> Update(Supplier supplier);
        public Task<string> ChangeStatus(Guid id);
    }
}
