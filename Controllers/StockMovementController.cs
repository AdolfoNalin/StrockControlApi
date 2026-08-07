using Microsoft.AspNetCore.Mvc;
using StockControlApi.Libiries;
using StockControlApi.Models;
using StockControlApi.Service;

namespace StockControlApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class StockMovementController : ControllerBase
    {
        private readonly IStockMovementService _stockMovement;

        public StockMovementController(IStockMovementService stockMovement)
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
        [HttpGet("ById/{id}")]
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
        [HttpGet("ByProductId/{id}")]
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

        #region GetByMovementType
        [HttpGet("ByMovementType")]
        public async Task<IActionResult> GetByMovementType([FromQuery] MovimentType value)
        {
            try
            {
                List<StockMovement> stockMovements = await _stockMovement.GetByMovementType(value);
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

        #region Update
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
