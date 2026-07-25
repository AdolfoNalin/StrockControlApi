using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockControlApi.Data;
using StockControlApi.Models;

namespace StockControlApi.Service
{
    public class StockMovementService : ControllerBase, IStockMovement
    {
        private readonly ApiStockControlContext _context;

        public StockMovementService(ApiStockControlContext context)
        {
            _context = context;
        }

        #region Create
        public async Task<bool> Create(StockMovement stockMovement)
        {
            try
            {
                if (stockMovement == null)
                    throw new ArgumentNullException("Movimentação de estoque não preenchida");
                else
                {
                    await _context.StockMovement.AddAsync(stockMovement);
                    int value = await _context.SaveChangesAsync();

                    if (value == 1)
                        return true;
                    else
                        return false;
                }

            }
            catch (ArgumentNullException ane)
            {
                throw ane;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetAll
        public async Task<List<StockMovement>> GetAll()
        {
            try
            {
                List<StockMovement> list = await _context.StockMovement.OrderBy(s => s.MovementDate).ToListAsync();

                if (list.Count == 0)
                    throw new ArgumentNullException("Nenhuma movimentação foi encontrada");
                else
                    return list;
            }
            catch (ArgumentNullException ane)
            {
                throw ane;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetByDate
        public async Task<List<StockMovement>> GetByDate(DateTime? startDate, DateTime? endDate)
        {
            try
            {
                if((!startDate.HasValue || !endDate.HasValue) || (!startDate.HasValue && !endDate.HasValue))
                {
                    throw new ArgumentNullException("Verifique se as datas estão com os valores certos");
                }

                List<StockMovement> list = await _context.StockMovement.Where(s => s.MovementDate.Date.Date == startDate && s.MovementDate.Date.Date == endDate).OrderBy(s => s.MovementDate).ToListAsync();

                if (list.Count == 0)
                    throw new ArgumentNullException("Nenhuma movimentação foi encontrada");
                else
                    return list;
            }
            catch (ArgumentNullException ane)
            {
                throw ane;
            }
            catch (ArgumentException ae)
            {
                throw ae;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetById
        public async Task<StockMovement> GetById(Guid id)
        {
            try
            {
                StockMovement stockMovement = await _context.StockMovement.FirstOrDefaultAsync(s => s.Id == id)
                    ?? throw new ArgumentNullException("Nenhuma movimentação foi encontrada");

                return stockMovement;
            }
            catch (ArgumentNullException ane)
            {
                throw ane;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetByProductId
        public async Task<List<StockMovement>> GetByProductId(Guid id)
        {
            try
            {
                List<StockMovement> list = await _context.StockMovement.Where(s => s.ProductId == id).OrderBy(s => s.MovementDate).ToListAsync();

                if (list.Count == 0)
                    throw new ArgumentNullException("Nenhuma movimentação foi encontrada");
                else
                    return list;
            }
            catch (ArgumentNullException ane)
            {
                throw ane;
            }
            catch (ArgumentException ae)
            {
                throw ae;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetSmartSearch
        public async Task<List<StockMovement>> GetSmartSearch(string value)
        {
            try
            {
                List<StockMovement> list = await _context.StockMovement.Where(s => s.Product.Description.ToUpper().Contains(value.ToUpper())).OrderBy(s => s.MovementDate).ToListAsync();

                if (list.Count == 0)
                    throw new ArgumentNullException("Nenhuma movimentação foi encontrada");
                else
                    return list;
            }
            catch (ArgumentNullException ane)
            {
                throw ane;
            }
            catch (ArgumentException ae)
            {
                throw ae;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update
        public async Task<bool> Update(StockMovement stockMovement)
        {
            try
            {
                if (stockMovement is null)
                    throw new ArgumentNullException("Movimentação está vazia");
                else
                {
                    _context.StockMovement.Update(stockMovement);
                    int value = await _context.SaveChangesAsync();

                    if(value == 1)
                        return true;
                    else
                        return false;
                }
                    
            }
            catch (ArgumentNullException ane)
            {
                throw ane;
            }
            catch (ArgumentException ae)
            {
                throw ae;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
