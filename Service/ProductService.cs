using Microsoft.EntityFrameworkCore;
using StockControlApi.Data;
using StockControlApi.Models;

namespace StockControlApi.Service
{
    public class ProductService : IProductService
    {
        private readonly ApiStockControlContext _context;

        public ProductService(ApiStockControlContext context)
        {
            _context = context;
        }

        #region GetByStatus
        /// <summary>
        /// Function responsible for Get product Active or deasactivate in database
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> GetByStatus(bool value)
        {
            try
            {
                List<Product> products = await _context.Product.Where(p => p.IsActive == value).ToListAsync();

                if (products.Count == 0)
                {
                    string status = value == true ? "Ativado" : "Desativado";
                    throw new ArgumentNullException("Nenhum produto com o status {status} foi encontrado");
                }
                else
                    return products;
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

        #region GetAll
        /// <summary>
        /// Function responsible for get all porduct 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> GetAll()
        {
            try
            {
                List<Product> products = await _context.Product.OrderBy(p => p.Description).ToListAsync();

                if (products.Count == 0)
                    throw new ArgumentNullException("Nenhum produto encontrado");
                else
                    return products;
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

        #region GetId
        /// <summary>
        /// Function responsible for search the product in database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<Product> GetById(Guid id)
        {
            try
            {
                Product product = await _context.Product.FirstOrDefaultAsync(p => p.Id == id)
                    ?? throw new ArgumentNullException("Nenhum peroduto foi encontrado");

                return product;
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

        #region ChangeStatus
        /// <summary>
        /// Method responsible for Active or deasactivate
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> ChangeStatus(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentNullException("Produto vazio. Por favor, preencha todos os camposs");
                }
                else if (await _context.Product.AnyAsync(p => p.Id == id))
                {
                    Product product = await _context.Product.Where(p => p.Id == id).FirstAsync();

                    product.IsActive = !product.IsActive;

                    string result = product.IsActive == true ? "Ativado" : "Desativado";

                    _context.Product.Update(product);
                    int value = await _context.SaveChangesAsync();

                    if (value == 1)
                    {
                        return $"Produto foi {result} com Sucesso";
                    }
                    else
                    {
                        throw new Exception("Algo deu errado");
                    }
                }
                else
                {
                    throw new Exception("Algo deu errado no banco");
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

        #region Create
        /// <summary>
        /// Function responsible for insert product in database
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<string> Create(Product product)
        {
            try
            {
                if (product is null)
                {
                    throw new ArgumentNullException("Produto vazio. Por favor, preencha todos os camposs");
                }
                else if (await _context.Product.AnyAsync(p => p.Id == product.Id || p.Description.ToUpper() == product.Description.ToUpper()))
                {
                    throw new ArgumentException("Produto já existe no banco!");
                }
                else
                {
                    if (product.IsActive)
                    {
                        _context.Product.Add(product);
                        int value = await _context.SaveChangesAsync();

                        if (value == 1)
                        {
                            return $"Produto {product.Description} cadastrado com sucesso";
                        }
                        else
                        {
                            throw new Exception("Algo deu errado");
                        }
                    }
                    else
                    {
                        throw new Exception("Impósivel cadastrar produto Desativado");
                    }
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

        #region Update
        /// <summary>
        /// Function responsible for update the prudoct in database
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<string> Update(Product product)
        {
            try
            {
                if (product == null)
                    throw new NullReferenceException("Produto não encontrado.");

                _context.Product.Update(product);

                await _context.SaveChangesAsync();

                return "Produto atualizado.";
            }
            catch(NullReferenceException nre)
            {
                throw nre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region UpdateStock
        /// <summary>
        /// Function responsible for update stockQauntity
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<bool> UpdateStock(Guid productId, int stockQuantity)
        {
            try
            {
                if (productId == Guid.Empty)
                    throw new NullReferenceException("Produto não encontrado.");

                Product product = await _context.Product.FirstOrDefaultAsync(p => p.Id == productId)
                    ?? throw new ArgumentNullException("Nenhum produto encontrado");

                product.StockQuantity = stockQuantity;

                _context.Product.Update(product);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (NullReferenceException nre)
            {
                throw nre;
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
    }
}
