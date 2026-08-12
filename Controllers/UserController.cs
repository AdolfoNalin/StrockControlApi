using Microsoft.AspNetCore.Mvc;
using StockControlApi.Libiries;
using StockControlApi.Models;
using StockControlApi.Service;

namespace StockControlApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #region GetById
        [HttpGet("ById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                User user = await _userService.GetById(id);

                return Ok(user);
            }
            catch (ArgumentException ae)
            {
                return NotFound(ae.ParamName);
            }
            catch (Exception ex)
            {
                return BadRequest(MessageException.MessageBadRequest(ex));
            }
        }
        #endregion

        #region GetByStatus
        /// <summary>
        /// Function responsible for search by status users in database
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpGet("ByStatus/{value}")]
        public async Task<IActionResult> GetByStatus([FromRoute] bool value)
        {
            try
            {
                List<User> users = await _userService.GetByStatus(value);

                return Ok(users);
            }
            catch (ArgumentException ae)
            {
                return NotFound(ae.ParamName);
            }
            catch (Exception ex)
            {
                return BadRequest(MessageException.MessageBadRequest(ex));
            }
        }
        #endregion

        #region GetAll
        /// <summary>
        /// Fuinction responsible for get all users in database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<User> users = await _userService.GetAll();

                return Ok(users);
            }
            catch(NullReferenceException nre)
            {
                return NotFound(nre.Message);
            }
            catch(ArgumentException ae)
            {
                return NotFound(ae.ParamName);
            }
            catch (Exception ex)
            {
                return BadRequest(MessageException.MessageBadRequest(ex));
            }
        }
        #endregion

        #region Create
        /// <summary>
        /// Function responsible for insert user in database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            try
            {
                string message = await _userService.Create(user);
                return Ok(message);
            }
            catch(NullReferenceException are)
            {
                return NotFound(are.Message);
            }
            catch(ArgumentException ae)
            {
                return NotFound(ae.ParamName);
            }
            catch (Exception ex)
            {
                return BadRequest(MessageException.MessageBadRequest(ex));
            }
        }
        #endregion

        #region Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLogin login)
        {
            try
            {
                UserResponse response = await _userService.Login(login);
                return Ok(response);
            }
            catch(ArgumentNullException ane)
            {
                return NotFound(ane.ParamName);
            }
            catch(ArgumentException ae)
            {
                return NotFound(ae.ParamName);
            }
            catch (Exception ex)
            {
                return BadRequest(MessageException.MessageBadRequest(ex));
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// Function responsible for update user in database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            try
            {
                string result = await _userService.Update(user);
                return Ok(result);
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
        /// Function responsible for active or deasactivate
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("ChangeStatus/{id}")]
        public async Task<IActionResult> ChangeStatus([FromRoute] Guid id)
        {
            try
            {
                string result = await _userService.ChangeStatus(id);

                return Ok(result);
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
    }
}
