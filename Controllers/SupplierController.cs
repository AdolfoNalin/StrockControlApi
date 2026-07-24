using Microsoft.AspNetCore.Mvc;
using StockControlApi.Libiries;
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
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Supplier> list = await _supplierService.GetAll();

                return Ok(list);
            }
            catch(ArgumentNullException ane)
            {
                return NotFound(ane.ParamName);
            }
            catch (Exception ex)
            {
                return BadRequest(MessageException.MessageBadRequest(ex));
            }
        }
        #endregion

        #region GetById
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ById/guid:{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                if(Guid.Empty == id)
                    throw new NullReferenceException("Identidade vazia");

                Supplier supplier = await _supplierService.GetById(id) as Supplier
                    ?? throw new ArgumentNullException("Nenhum Fornecedor encontrado");

                return Ok(supplier);
            }
            catch(ArgumentNullException ane)
            {
                return NotFound(ane.ParamName);
            }
            catch (Exception ex)
            {
                return BadRequest(MessageException.MessageBadRequest(ex));
            }
        }
        #endregion

        #region GetByStatus
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpGet("ByStatus/{value}")]
        public async Task<IActionResult> GetByStatus([FromRoute] bool value)
        {
            try
            {
                List<Supplier> suppliers = await _supplierService.GetByStatus(value);

                return Ok(suppliers);
            }
            catch(ArgumentNullException ane)
            {
                return NotFound(ane.ParamName);
            }
            catch (Exception ex)
            {
                return BadRequest(MessageException.MessageBadRequest(ex));
            }
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
        [HttpPut("Update")]
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
