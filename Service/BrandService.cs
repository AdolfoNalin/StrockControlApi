using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockControlApi.Data;
using StockControlApi.Models;

namespace StockControlApi.Service
{
    public class BrandService : ControllerBase, IBrandService
    {
        private readonly ApiStockControlContext _context;

        public BrandService(ApiStockControlContext context)
        {
            _context = context;
        }

        #region ChangeStatus
        /// <summary>
        ///  Method responsible for change status 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> ChangeSatus(Guid id)
        {
            try
            {
                Brand brand = await _context.Brand.Where(b => b.Id == id).FirstOrDefaultAsync();

                if (brand == null)
                    throw new ArgumentNullException("Nenhuma marca foi encontrado");

                brand.Active = !brand.Active;

                string status = brand.Active == true ? "Ativado" : "Desativado";

                _context.Brand.Update(brand);
                await _context.SaveChangesAsync();

                return $"Marca foi {status} com êxito";
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
        /// Method responsible for Create brand in database
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public async Task<string> Create(Brand brand)
        {
            try
            {
                if (brand == null)
                    throw new ArgumentNullException("Marca está vazia");
                else if (await _context.Brand.AnyAsync(b => b.Id == brand.Id || b.Name.Equals(brand.Name)))
                    throw new ArgumentException("Marca já existe");
                else
                {
                    await _context.Brand.AddAsync(brand);
                    await _context.SaveChangesAsync();

                    return $"Marca {brand.Name} foi cadastrado com êxito";
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

        #region GetAll
        /// <summary>
        /// Method responsible for get all Brand in database
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<List<Brand>> GetAll()
        {
            try
            {
                List<Brand> brands = await _context.Brand.OrderBy(b => b.Name).ToListAsync();

                if(brands.Count == 0)
                {
                    throw new ArgumentException("Nenhuma Marca foi encontrada");
                }
                else
                {
                    return brands;
                }
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

        #region GetById
        /// <summary>
        /// Method responsible for search Brand for id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<Brand> GetById(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    throw new ArgumentException("Identidade está vazia");

                Brand brand = await _context.Brand.FirstOrDefaultAsync(b => b.Id == id)
                    ?? throw new ArgumentNullException("Nenhum marca encontrada");

                return brand;
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
        /// Method responsible for search brands where Active for equals Value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<List<Brand>> GetByStatus(bool value)
        {
            try
            {
                List<Brand> brands = await _context.Brand.Where(b => b.Active == value).ToListAsync();

                if(brands.Count == 0)
                {
                    string status = value == true ? "Ativado" : "Desativado";
                    throw new ArgumentNullException($"Nenhum marca com statatus {status} foi encontrado");
                }
                else
                {
                    return brands;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// Methdo responsible for update brand in database
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public async Task<string> Update(Brand brand)
        {
            try
            {
                if (brand == null)
                    throw new ArgumentNullException("Preencha todos os campos da Marca");
                else if(!await _context.Brand.AnyAsync(b => b.Name.Equals(brand.Name)))
                        throw new ArgumentException("Marca não existe no banco de dados");
                else
                {
                    _context.Brand.Update(brand);
                    int value = await _context.SaveChangesAsync();

                    if (value == 1)
                        return $"Marca {brand.Name} foi atualizada com êxito";
                    else
                        return "Algo deu errado, verifique o banco";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
