using Microsoft.AspNetCore.Mvc;
using StockControlApi.Libiries;
using StockControlApi.Models;
using StockControlApi.Service;

namespace StockControlApi.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        #region GetAll
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Brand> brands = await _brandService.GetAll();
                return Ok(brands);
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
        /// <returns></returns>
        [HttpGet("ById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                Brand brand = await _brandService.GetById(id);
                return Ok(brand);
            }
            catch (ArgumentNullException ane)
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
        /// <returns></returns>
        [HttpGet("ByStatus/{value}")]
        public async Task<IActionResult> GetbySatus([FromRoute] bool value)
        {
            try
            {
                List<Brand> brands = await _brandService.GetByStatus(value);
                return Ok(brands);
            }
            catch (ArgumentNullException ane)
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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Brand brand)
        {
            try
            {
                string result = await _brandService.Create(brand);
                return Ok(result);
            }
            catch(ArgumentNullException ane)
            {
                return NotFound(ane.ParamName);
            }
            catch(ArgumentException ae)
            {
                return NotFound(ae.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(MessageException.MessageBadRequest(ex));
            }
        }
        #endregion

        #region Update
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Brand brand)
        {
            try
            {
                string result = await _brandService.Update(brand);
                return Ok(result);
            }
            catch (ArgumentNullException ane)
            {
                return NotFound(ane.ParamName);
            }
            catch (ArgumentException ae)
            {
                return NotFound(ae.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(MessageException.MessageBadRequest(ex));
            }
        }
        #endregion

        #region ChangeStatus
        [HttpPut("ChangeStatus/{id}")]
        public async Task<IActionResult> ChangeStatus([FromRoute] Guid id)
        {
            try
            {
                string result = await _brandService.ChangeSatus(id);
                return Ok(result);
            }
            catch (ArgumentNullException ane)
            {
                return NotFound(ane.ParamName);
            }
            catch (ArgumentException ae)
            {
                return NotFound(ae.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(MessageException.MessageBadRequest(ex));
            }
        }
        #endregion
    }
}
