using Assignment_3.Models;

namespace Assignment_3.Services
{
    public interface IUserService
    {
        public Task<User> CreateUser(User user);
        public Task<List<User>> GetAll();
    }
}
