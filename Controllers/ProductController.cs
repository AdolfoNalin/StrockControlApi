using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockControlApi.Data;
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
        [HttpGet("active/bool:{value}")]
        public async Task<IActionResult> GetByStatus([FromRoute] bool value)
        {
            return Ok(await _productService.GetByStatus(value));
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
            return Ok(await _productService.GetAll());
        }
        #endregion

        #region GetId
        /// <summary>
        /// Function responsible for Get product in database
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return Ok(await _productService.GetById(id));
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
            return Ok(await _productService.Post(product));
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
            return Ok(await _productService.Put(product));
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
            return Ok(await _productService.ChangeStatus(id));
        }
        #endregion
    }
}