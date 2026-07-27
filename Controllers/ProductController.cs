using Microsoft.AspNetCore.Mvc;
using StockControlApi.Libiries;
using StockControlApi.Models;
using StockControlApi.Service;

namespace StockControlApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService service)
        {
            _productService = service;
        }

        #region GetByStatus
        /// <summary>
        /// Function responsible for Get product Active or deasactivate in database
        /// </summary>
        /// <returns></returns>
        [HttpGet("ByStatus/{value}")]
        public async Task<IActionResult> GetByStatus([FromRoute] bool value)
        {
            try
            {
                List<Product> products = await _productService.GetByStatus(value);
                return Ok(products);
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

        #region GetAll
        /// <summary>
        /// Function responsible for Get product in database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Product> products = await _productService.GetAll();
                
                return Ok(products);
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

        #region GetId
        /// <summary>
        /// Function responsible for Get product in database
        /// </summary>
        /// <returns></returns>
        [HttpGet("ById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                Product product = await _productService.GetById(id);

                return Ok(product);
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
        /// Function responsible for insert the product in database
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            try
            {
                string message = await _productService.Create(product);

                return Ok(message);
            }
            catch(ArgumentNullException ane)
            {
                throw ane;
            }
            catch(ArgumentException ae)
            {
                throw ae;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// Function responsible for update the product in database
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            try
            {
                string message = await _productService.Update(product);
                return Ok(message);
            }
            catch(NullReferenceException nre)
            {
                return NotFound(nre.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(MessageException.MessageBadRequest(ex));
            }
        }
        #endregion
        
        #region UpdateStock
        /// <summary>
        /// Function responsible for update the product in database
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [HttpPut("UpdateStock")]
        public async Task<IActionResult> UpdateStock([FromQuery] Guid id, int stockQuantity)
        {
            try
            {
                bool value = await _productService.UpdateStock(productId: id, stockQuantity: stockQuantity);
                return Ok(value);
            }
            catch(ArgumentNullException ane)
            {
                return NotFound(ane.ParamName);
            }
            catch(NullReferenceException nre)
            {
                return NotFound(nre.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(MessageException.MessageBadRequest(ex));
            }
        }
        #endregion

        #region ChangeStatus
        /// <summary>
        /// Function resposible for active or deasactivate
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPut("ChangeStatus/{id}")]
        public async Task<IActionResult> ChangeStatus([FromRoute] Guid id)
        {
            try
            {
                string message = await _productService.ChangeStatus(id);

                return Ok(message);
            }
            catch (ArgumentNullException ane)
            {
                throw ane;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}