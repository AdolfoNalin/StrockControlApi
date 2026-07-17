using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockControlApi.Data;
using StockControlApi.Libiries;
using StockControlApi.Models;

namespace StockControlApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApiStockControlContext _context;

        public UserController(ApiStockControlContext context)
        {
            _context = context;
        }

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
                List<User> users = await _context.User.OrderBy(u => u.Name).ToListAsync();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(MessageException.MessageBadRequest(ex));
            }
        }
        #endregion

        #region Post
        /// <summary>
        /// Function responsible for insert user in database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("Usuário inválido");
                }
                else if(await _context.User.AnyAsync(u => u.Id == user.Id || u.Name.ToUpper() == user.Name.ToUpper()))
                {
                    return BadRequest("Usuário já existe");
                }
                else
                {
                    _context.User.Add(user);
                    int value = await _context.SaveChangesAsync();

                    if (value == 1)
                    {
                        return Ok("Usuário foi cadastrado com sucesso");
                    }
                    else
                    {
                        return BadRequest("Algo deu errado");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(MessageException.MessageBadRequest(ex));
            }
        }
        #endregion

        #region Put
        /// <summary>
        /// Function responsible for update user in database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Put([FromBody] User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("Usuário inválido");
                }
                else if(await _context.User.AnyAsync(u => u.Id == user.Id || u.Name.ToUpper() == user.Name.ToUpper()))
                {
                    return BadRequest("Usuário já existe");
                }
                else
                {
                    _context.User.Add(user);
                    int value = await _context.SaveChangesAsync();

                    if (value == 1)
                    {
                        return Ok("Usuário foi cadastrado com sucesso");
                    }
                    else
                    {
                        return BadRequest("Algo deu errado");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(MessageException.MessageBadRequest(ex));
            }
        }
        #endregion

        #region IsActive
        /// <summary>
        /// Function responsible for active or deasactivate
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("IsActive/{id}")]
        public async Task<IActionResult> IsActive([FromRoute] Guid id)
        {
            try
            {
                if(id == Guid.Empty)
                {
                    return BadRequest("Usuário sem id");
                }
                else
                {
                    User user = await _context.User.Where<User>(u => u.Id == id).FirstAsync();

                    user.Active = !user.Active;
                    string status = user.Active == true ? "Ativado" : "Desativado";
                    _context.User.Update(user);
                    int value = await _context.SaveChangesAsync();  

                    if (value == 1)
                    {
                        return Ok($"Usuário {status} com sucesso");
                    }
                    else
                    {
                        return BadRequest("Algo deu errado");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(MessageException.MessageBadRequest(ex));
            }
        }
        #endregion
    }
}
