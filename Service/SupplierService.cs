using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockControlApi.Data;
using StockControlApi.Libiries;
using StockControlApi.Models;

namespace StockControlApi.Service
{
    public class SupplierService : ControllerBase, ISupplierService
    {
        private readonly ApiStockControlContext _context;
        public SupplierService(ApiStockControlContext context)
        {
            _context = context;
        }

        #region ChangeStatus
        /// <summary>
        /// Method responsible for change status of supplier
        /// </summary>
        /// <param name="id">Key for supplier</param>
        /// <returns></returns>
        public async Task<IActionResult> ChangeStatus(Guid id)
        {
            try
            {
                Supplier supplier = _context.Supplier.Where(s =>  s.Id == id).FirstOrDefault()
                    ?? throw new NullReferenceException("Nenhum fornecedor encontrado");

                supplier.Active = !supplier.Active;

                _context.Supplier.Update(supplier);
                await _context.SaveChangesAsync();

                string status = supplier.Active == true ? "Ativado" : "Desativado";

                return BadRequest($"Fornecedor {status} com êxito");
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

        #region Create
        /// <summary>
        /// Method responsible for create supplier in database
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public async Task<IActionResult> Create(Supplier supplier)
        {
            try
            {
                if (supplier == null)
                {
                    throw new ArgumentNullException("Forcedor está nulo");
                }
                else if (await _context.Supplier.AnyAsync(s => s.Id == supplier.Id || s.Name.Equals(supplier.Name) || s.TrandName.Equals(supplier.TrandName)))
                {
                    throw new ArgumentException("Forncedor já castrado");
                }
                else
                {
                    _context.Supplier.Add(supplier);
                    int value = await _context.SaveChangesAsync();

                    if(value == 1)
                    {
                        return Ok($"Fornecedor cadastrado com êxito");
                    }
                    else
                    {
                         return BadRequest($"Algo de errado");
                    }
                }
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

        #region GetAll
        /// <summary>
        /// Method responsible for Get all Suppliers
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Supplier> suppliers = await _context.Supplier.OrderBy(s => s.Name).ToListAsync();

                return Ok(suppliers);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetBeId
        /// <summary>
        /// Method responsible for Get supllier by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                Supplier supplier = await _context.Supplier.Where(s => s.Id == id).FirstOrDefaultAsync()
                    ?? throw new NullReferenceException("Fornecedor não encontrado");

                return Ok(supplier);
            }
            catch(NullReferenceException are)
            {
                return NotFound(are.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(MessageException.MessageBadRequest(ex));
            }
        }
        #endregion

        #region GetByStatus
        /// <summary>
        /// Method responsible for get Suppleir for status
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetByStatus(bool value)
        {
            try
            {
                string status = value == true ? "Ativado" : "Desativado";
                List <Supplier> suppliers = null;

                suppliers = await _context.Supplier.Where(s => s.Active == value).ToListAsync();

                if(suppliers == null)
                {
                    return NotFound($"Não existe nenhum fornecedor com o status de {status}");
                }

                return Ok(suppliers);
            }
            catch (Exception ex)
            {
                return BadRequest(MessageException.MessageBadRequest(ex));
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// Methdo responsible for update supplier in database
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public async Task<IActionResult> Update(Supplier supplier)
        {
            try
            {
                if(supplier == null)
                {
                    throw new ArgumentNullException(nameof(supplier), "Está vazio");
                }
                else if(await _context.Supplier.AnyAsync(s => s.Id == supplier.Id || s.Name.Equals(supplier.Name) || s.TrandName.Equals(supplier.TrandName)))
                {
                    _context.Supplier.Update(supplier);
                    await _context.SaveChangesAsync();

                    return Ok($"Forcenedor {supplier.TrandName} atualizado com êxito");
                }
                else
                {
                    throw new ArgumentException("Fornecedor não existe!");
                }
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
                throw ex;
            }
        }
        #endregion
    }
}
