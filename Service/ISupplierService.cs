using Microsoft.AspNetCore.Mvc;
using StockControlApi.Models;

namespace StockControlApi.Service
{
    public interface ISupplierService
    {
        public Task<IActionResult> GetAll();
        public Task<IActionResult> GetById(Guid id);
        public Task<IActionResult> GetByStatus(bool value);
        public Task<IActionResult> Create(Supplier supplier);
        public Task<IActionResult> Update(Supplier supplier);
        public Task<IActionResult> ChangeStatus(Guid id);
    }
}
