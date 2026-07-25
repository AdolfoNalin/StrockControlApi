using Microsoft.AspNetCore.Mvc;
using StockControlApi.Libiries;
using StockControlApi.Models;
using StockControlApi.Service;

namespace StockControlApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class StockController : ControllerBase
    {
        private readonly IStockMovement _stockMovement;

        public StockController(IStockMovement stockMovement)
        {
            _stockMovement = stockMovement;
        }

        #region GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<StockMovement> list = await _stockMovement.GetAll();
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
                StockMovement stockMovement = await _stockMovement.GetById(id);
                return Ok(stockMovement);
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

        #region GetByProductId
        [HttpGet("ByIdProduct/guid:{id}")]
        public async Task<IActionResult> GetByProductId([FromRoute] Guid id)
        {
            try
            {
                List<StockMovement> stockMovements = await _stockMovement.GetByProductId(id);
                return Ok(stockMovements);
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

        #region GetSmartSearch
        [HttpGet("SmartSeach")]
        public async Task<IActionResult> GetSmartSearch([FromQuery] string value)
        {
            try
            {
                List<StockMovement> stockMovements = await _stockMovement.GetSmartSearch(value);
                return Ok(stockMovements);
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

        #region GetByDate
        [HttpGet("ByDate")]
        public async Task<IActionResult> GetById([FromQuery] DateTime startDate, DateTime endDate)
        {
            try
            {
                List<StockMovement> stockMovements = await _stockMovement.GetByDate(startDate, endDate);
                return Ok(stockMovements);
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
        public async Task<IActionResult> Create([FromBody] StockMovement stockMovement)
        {
            try
            {
                bool value = await _stockMovement.Create(stockMovement);

                return Ok(value);
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
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] StockMovement stockMovement)
        {
            try
            {
                bool value = await _stockMovement.Update(stockMovement);

                return Ok(value);
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
    }
}
