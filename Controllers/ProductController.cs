using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockControlApi.Data;
using StockControlApi.Libiries;
using StockControlApi.Models;

namespace StockControlApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ApiStockControlContext _context;

        public ProductController(ApiStockControlContext context)
        {
            _context = context;
        }

        #region GetAll
        /// <summary>
        /// Function responsible for Get product in database
        /// </summary>
        /// <returns></returns>
        [HttpGet("Product")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Product> products = await _context.Product.OrderBy(p => p.Description).ToListAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(MessageException.MessageBadRequest(ex));
            }
        }
        #endregion

        #region Post
        /// <summary>
        /// Function responsible for insert the product in database
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [HttpPost("Product")]
        public async Task<IActionResult> Post(Product product)
        {
            try
            {
                if(product is null)
                {
                    return BadRequest("Produto vazio. Por favor, preencha todos os camposs");
                }
                else if(await _context.Product.AnyAsync(p => p.Id == product.Id || p.Description.ToUpper() == product.Description.ToUpper()))
                {
                    return Conflict("Produto já existe no banco!");
                }
                else
                {
                    if (product.IsActive)
                    {
                        _context.Product.Add(product);
                        int value = await _context.SaveChangesAsync();

                        if (value == 1)
                        {
                            return Ok($"Produto {product.Description} cadastrado com sucesso");
                        }
                        else
                        {
                            return BadRequest("Algo deu errado");
                        }
                    }
                    else
                    {
                        return BadRequest("Impósivel cadastrar produto Desativado");
                    }
                }
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

        #region Put
        /// <summary>
        /// Function responsible for update the product in database
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [HttpPut("Product")]
        public async Task<IActionResult> Put(Product product)
        {
            try
            {
                if (product is null)
                {
                    return BadRequest("Produto vazio. Por favor, preencha todos os camposs");
                }
                else if (await _context.Product.AnyAsync(p => p.Id == product.Id || p.Description.ToUpper().Contains(product.Description.ToUpper())))
                {
                    _context.Product.Update(product);
                    int value = await _context.SaveChangesAsync();

                    if (value == 1)
                    {
                        return Ok($"Produto {product.Description} cadastrado com sucesso");
                    }
                    else
                    {
                        return BadRequest("Algo deu errado");
                    }
                }
                else
                {
                    return BadRequest("Produto não existe no banco!");
                }
            }
            catch (ArgumentNullException ane)
            {
                return NotFound(ane.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(MessageException.MessageBadRequest(ex));
            }
        }
        #endregion

        #region IsActive
        /// <summary>
        /// Function resposible for active or deasactivate
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPut("Product/IsActive/{id}")]
        public async Task<IActionResult> IsActive(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest("Produto vazio. Por favor, preencha todos os camposs");
                }
                else if (await _context.Product.AnyAsync(p => p.Id == id))
                {
                    Product product = await _context.Product.Where(p => p.Id == id).FirstAsync();

                    product.IsActive = !product.IsActive;

                    string result = product.IsActive == true ? "Ativado" : "Desativado";

                    _context.Product.Update(product);
                    int value = await _context.SaveChangesAsync();
                   
                    if(value == 1)
                    {
                        return Ok($"Produto foi {result} com Sucesso");
                    }
                    else
                    {
                        return BadRequest("Algo deu errado");
                    }
                }
                else
                {
                    return BadRequest("Algo deu errado no banco");
                }
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
    }
}