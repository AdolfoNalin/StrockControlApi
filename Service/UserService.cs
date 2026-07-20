using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockControlApi.Data;
using StockControlApi.Libiries;
using StockControlApi.Models;

namespace StockControlApi.Service
{
    public class UserService : ControllerBase, IUserService
    {
        private readonly ApiStockControlContext _context;
        public UserService(ApiStockControlContext context)
        {
            _context = context;
        }

        #region ChangeStatus
        /// <summary>
        /// Function responsible for active or deasactivate
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> ChangeStatus(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new NullReferenceException("Usuário sem id");
                }
                else
                {
                    User user = await _context.User.Where<User>(u => u.Id == id).FirstOrDefaultAsync()
                        ?? throw new NullReferenceException("Ususário não encontrado");

                    user.Active = !user.Active;
                    string status = user.Active == true ? "Ativado" : "Desativado";
                    _context.User.Update(user);
                    int value = await _context.SaveChangesAsync();

                    return $"Usuário {status} com sucesso";
                }
            }
            catch (NullReferenceException nre)
            {
                return nre.Message;
            }
            catch (Exception ex)
            {
                return MessageException.MessageBadRequest(ex);
            }
        }
        #endregion

        #region GetAll
        /// <summary>
        /// Fuinction responsible for get all users in database
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetAll()
        {
            try
            {
                List<User> users = await _context.User.OrderBy(u => u.Name).ToListAsync();

                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetById
        /// <summary>
        /// Fuinction responsible for search user for id in database
        /// </summary>
        /// <returns></returns>
        public async Task<User> GetById(Guid id)
        {
            try
            {
                User user = await _context.User.Where(u => u.Id == id).FirstOrDefaultAsync()
                    ?? throw new ArgumentNullException("Usuário não foi encontrado");

                return user;
            }
            catch(ArgumentNullException ane)
            {
                throw ane;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetByStatus
        /// <summary>
        /// Function responsible for search by status users in database
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<List<User>> GetByStatus(bool value)
        {
            try
            {
                List<User> users = await _context.User.Where(u => u.Active == value).OrderBy(u => u.Name).ToListAsync()
                    ?? throw new ArgumentNullException("Nenhum usuário foi encontrado");

                return users;
            }
            catch(ArgumentNullException ane)
            {
                throw ane;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Create
        /// <summary>
        /// Function responsible for insert user in database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<string> Create(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new NullReferenceException("Usuário inválido");
                }
                else if (await _context.User.AnyAsync(u => u.Id == user.Id || u.Name.ToUpper() == user.Name.ToUpper()))
                {
                    throw new ArgumentException("Usuário já existe");
                }
                else
                {
                    _context.User.Add(user);
                    int value = await _context.SaveChangesAsync();

                    return $"Usuário {user.Name} criado com êxito";
                }
            }
            catch (ArgumentException ae)
            {
                return ae.ParamName;
            }
            catch (NullReferenceException nre)
            {
                return nre.Message;
            }
            catch (Exception ex)
            {
                return MessageException.MessageBadRequest(ex);
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// Function responsible for update user in database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<string> Update(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new NullReferenceException("Usuário inválido");
                }
                else if (await _context.User.AnyAsync(u => u.Id == user.Id || u.Name.ToUpper() == user.Name.ToUpper()))
                {
                    _context.User.Update(user);
                    int value = await _context.SaveChangesAsync();

                    return "Usuário foi cadastrado com sucesso";
                }
                else
                {
                    throw new ArgumentException("Usuário Não existe");
                }
            }
            catch (NullReferenceException nre)
            {
                return nre.Message;
            }
            catch (Exception ex)
            {
                return MessageException.MessageBadRequest(ex);
            }
        }
        #endregion
    }
}
