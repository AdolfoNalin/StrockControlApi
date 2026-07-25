using Microsoft.AspNetCore.Mvc;
using StockControlApi.Libiries;
using StockControlApi.Models;
using StockControlApi.Service;

namespace StockControlApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #region GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Category> list = await _categoryService.GetAll();

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
        [HttpGet("ById/guid:{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                Category category = await _categoryService.GetById(id);

                return Ok(category);
            }
            catch (ArgumentNullException ane)
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

        #region GetByStatus
        [HttpGet("ByStatus/bool:{value}")]
        public async Task<IActionResult> GetByStatus([FromRoute] bool value)
        {
            try
            {
                List<Category> list = await _categoryService.GetByStatus(value);

                return Ok(list);
            }
            catch (ArgumentNullException ane)
            {
                return NotFound(ane.ParamName);
            }
            catch(ArgumentException ae)
            {
                return NotFound($"{ae.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest(MessageException.MessageBadRequest(ex));
            }
        }
        #endregion

        #region Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            try
            {
                string result = await _categoryService.Create(category);

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
        public async Task<IActionResult> Update([FromBody] Category category)
        {
            try
            {
                string result = await _categoryService.Update(category);

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
        [HttpPut]
        public async Task<IActionResult> ChangeStatus([FromRoute] Guid id)
        {
            try
            {
                string result = await _categoryService.ChangeSatus(id);

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
