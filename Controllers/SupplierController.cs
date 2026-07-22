using Microsoft.AspNetCore.Mvc;
using StockControlApi.Models;
using StockControlApi.Service;

namespace StockControlApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        #region GetAll
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           return Ok(await _supplierService.GetAll());
        }
        #endregion

        #region GetById
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return Ok(await _supplierService.GetById(id));
        }
        #endregion

        #region GetByStatus
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpGet("ByStatus/bool:{value}")]
        public async Task<IActionResult> GetByStatus([FromRoute] bool value)
        {
            return Ok(await _supplierService.GetByStatus(value));
        }
        #endregion

        #region Create
        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Supplier supplier)
        {
            return Ok(await _supplierService.Create(supplier));
        }
        #endregion

        #region Update
        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Supplier supplier)
        {
            return Ok(await _supplierService.Update(supplier));
        }
        #endregion

        #region ChangeStatus
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("ChangeStatus/{id}")]
        public async Task<IActionResult> ChangeStatus([FromRoute] Guid id)
        {
            return Ok(await _supplierService.ChangeStatus(id));
        }
        #endregion
    }
}
