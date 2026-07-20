using StockControlApi.Models;

namespace StockControlApi.Service
{
    public interface IUserService
    {
        public Task<List<User>> GetAll();
        public Task<List<User>> GetByStatus(bool value);
        public Task<User> GetById(Guid id);
        public Task<String> Create(User user);
        public Task<String> Update(User user);
        public Task<String> ChangeStatus(Guid id);
    }
}