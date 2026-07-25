using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockControlApi.Data;
using StockControlApi.Models;

namespace StockControlApi.Service
{
    public class CategoryService : ControllerBase, ICategoryService
    {
        private readonly ApiStockControlContext _context;

        public CategoryService(ApiStockControlContext context)
        {
            _context = context;
        }

        #region ChangeStatus
        public async Task<string> ChangeSatus(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    throw new ArgumentNullException("Identidade da categoria está vazia");
                else
                {
                    Category category = await _context.Category.FirstOrDefaultAsync(c => c.Id == id)
                        ?? throw new ArgumentNullException("Nenhuma categoria foi encontrada");

                    category.Active = !category.Active;

                    _context.Category.Update(category);
                    int value = await _context.SaveChangesAsync();

                    if (value == 1)
                    {
                        string status = category.Active == true ? "Ativada" : "Desativada";
                        return $"Categpria {category.Name} foi {status} com êxito";
                    }
                    else
                    {
                        return "Algo deu errado";
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

        #region Create
        public async Task<string> Create(Category category)
        {
            try
            {
                if (category == null)
                    throw new ArgumentNullException("Os campos da categoria está vazio");
                else if (await _context.Category.AnyAsync(c => c.Id == category.Id || c.Name.Equals(category.Name)))
                    throw new ArgumentException("Categoria já foi cadastrada");
                else
                {
                    await _context.Category.AddAsync(category);
                    int value = await _context.SaveChangesAsync();

                    if (value == 1)
                        return $"Categoria {category.Name} foi cadastrada com êxito";
                    else
                        return "Algo deu errado";
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
        public async Task<List<Category>> GetAll()
        {
            try
            {
                List<Category> list = await _context.Category.OrderBy(c => c.Name).ToListAsync();

                if (list.Count == 0)
                    throw new ArgumentNullException("Nenhuma categoria encontrada");
                else
                {
                    return list;
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

        #region GetById
        public async Task<Category> GetById(Guid id)
        {
            try
            {
                Category category = await _context.Category.FirstOrDefaultAsync(c => c.Id == id)
                    ?? throw new ArgumentNullException("Nenhuma categoria encontrada");

                return category;
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

        #region GetByStatus
        public async Task<List<Category>> GetByStatus(bool value)
        {
            try
            {
                List<Category> list = await _context.Category.Where(c => c.Active == value).OrderBy(c => c.Name).ToListAsync()
                   ?? throw new ArgumentNullException("Nenhuma categoria encontrada");

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

        #region Update
        public async Task<string> Update(Category category)
        {
            try
            {
                if (category is null)
                    throw new ArgumentNullException("Categoria está vazia");
                else
                {
                    _context.Category.Update(category);
                    int value = await _context.SaveChangesAsync();

                    if (value == 1)
                    {
                        return $"Categpria {category.Name} foi Atualizada com êxito";
                    }
                    else
                    {
                        return "Algo deu errado";
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
    }
}
