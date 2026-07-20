using Microsoft.AspNetCore.Mvc;
using StockControlApi.Models;
using StockControlApi.Service;

namespace StockControlApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #region GetById
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return Ok(await _userService.GetById(id));
        }
        #endregion

        #region GetByStatus
        /// <summary>
        /// Function responsible for search by status users in database
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetByStatus([FromRoute] bool value)
        {
            return Ok(await _userService.GetByStatus(value));
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
           return Ok(await _userService.GetAll());
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
           return Ok(await _userService.Create(user));
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
            return Ok(await _userService.Update(user));
        }
        #endregion

        #region ChangeStatus
        /// <summary>
        /// Function responsible for active or deasactivate
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("IsActive/{id}")]
        public async Task<IActionResult> ChangeStatus([FromRoute] Guid id)
        {
           return Ok(await _userService.ChangeStatus(id));
        }
        #endregion
    }
}
